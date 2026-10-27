# BioNutri-MM implementation plan

Status: Local implementation completed after approval. Scoring, plate validation, Activity 5 text, and the authenticated Unity chatbot client are updated. PHP backend source and setup instructions are supplied under `Backend/`. Hosted login integration, deployment, credential rotation, and Unity visual/Play Mode verification remain pending; see implementation report below.

## Implementation report

- Repeated-score and changed-answer checks pass against the actual controller sources using a standalone harness with minimal Unity stubs.
- Plate validation passes all 2,401 tested combinations, accepts exactly four valid arrangements, and handles case/whitespace normalization.
- Changed C# scripts compile against the installed Unity engine/UI assemblies in an isolated compiler check. This is not a complete Unity project build.
- All five PHP files pass syntax checks; 43 request-policy/context checks pass without API calls.
- Unity MCP reports `Unity session not available`; EditMode test execution, Play Mode flows, and Activity 5 visual layout have not been verified in the editor. Regression tests are included in `Assets/Tests/Editor`.
- PHP hosting was selected by the user. `Backend/php` supplies the authenticated endpoint, MySQL schema, private config example, and login-session helper. `Backend/README.md` describes deployment and integration. The actual hosted `LoginUser.php` is absent, so the existing login bypass has not been replaced by an invented server contract. Chat deliberately requires real authenticated sessions before use.
- The embedded credential was removed from the chatbot source. The credential owner must still revoke it, review usage, configure a replacement only on the server, and rebuild distributed clients. No account changes, history rewrite, live API call, or deployment were performed.

The sections below retain the approved implementation specification and acceptance criteria.

## 1. Scope and approach

Fix repeat scoring, Healthy Plate validation, and the Activity 5 procedure. Separately replace direct chatbot API access with a backend that keeps credentials private. Preserve existing Unity button method names and serialized references. The workspace already contains substantial edits; preserve those changes and review narrowly scoped diffs.

## 2. Quiz and worksheet scoring

### Confirmed problem

- `Assets/KuizController.cs`: `checkAnswers()` and `checkAnswers5Q()` increment the existing `scores` value.
- `Assets/KeputusanController.cs`: `CheckAnswer()` increments the existing `score` value.
- Repeating submission can therefore count the same correct answers again.

### Proposed changes

Recalculate from the current answer array on every call. Start a local total at zero, count correct entries, and assign the final total once. Preserve the current weighting: one point per answer for the standard quiz and worksheet; two points per answer for the five-question quiz.

Illustrative method body for the standard quiz:

```csharp
int total = 0;
foreach (bool correct in soalanAnswer)
{
    if (correct) total++;
}
scores = total;
```

Use `total += 2` in `checkAnswers5Q()` and iterate `Jawapan` before assigning `score` in `CheckAnswer()`. Retain existing initialization assumptions rather than silently treating uninitialized answer arrays as successful submissions.

Inspect the scene UnityEvents to confirm answer evaluation happens before calculation, display, and saving. Preserve existing public method signatures. Do not alter weighting or previously saved backend results as part of this fix.

`KeputusanController.Start()` currently marks one answer true automatically. Preserve it for this patch, but inspect which worksheet section it represents before considering a separate marking-rule change.

### Acceptance checks

| Case | Expected result |
|---|---|
| Standard quiz: three correct answers, submitted repeatedly | Always 3 |
| Five-question quiz: three correct answers, submitted repeatedly | Always 6 |
| Worksheet: four true entries, submitted repeatedly | Always 4 |
| Change an answer from correct to incorrect, then submit again | Score decreases accordingly |
| No correct answers | 0 |
| All five weighted answers correct | 10 |

Add focused Unity EditMode regression tests for repeated calls and changed answers. Verify representative quiz/worksheet scenes in Play Mode, including saved/displayed scores and event ordering. Previously inflated stored scores need a separate correction policy; do not guess their true values.

## 3. Healthy Malaysian Plate validation

### Confirmed problem

`Assets/PingganSihatMalaysiaController.cs` mixes `&&` and `||` without parentheses. A single matching alternative can satisfy the expression while other sections are incorrect.

### Proposed rule

Based on the existing intended alternatives, sections 0 and 1 must contain one `IKAN` and one `NASI`, in either order. Sections 2 and 3 must contain one `BUAH` and one `SAYUR`, in either order. Confirm these section indices against the scene layout before implementation.

Read each name once and normalize using `(value ?? "").Trim().ToUpperInvariant()`. Evaluate two explicit pairs:

```csharp
bool firstPair =
    (a == "IKAN" && b == "NASI") ||
    (a == "NASI" && b == "IKAN");
bool secondPair =
    (c == "BUAH" && d == "SAYUR") ||
    (c == "SAYUR" && d == "BUAH");
bool correct = firstPair && secondPair;
```

This fixes precedence and prevents duplicate-food combinations, which grouping independent per-slot alternatives alone would still allow.

Inspect the four actual `winAndFail` references: the declaration allocates two entries while the code accesses indices 2 and 3. Verify serialized scene array size and prompt purpose before adjusting visibility. On each evaluation, show only the appropriate feedback for the current answer. Incomplete placements must not retain a success message from an earlier attempt. Preserve the distinction between current correctness and the historical `pernahjawab` completion flag; set completion only after a fully valid arrangement.

### Acceptance checks

- All four valid arrangements pass (two orderings for each pair).
- Duplicate fish/rice, duplicate fruit/vegetable, wrong groups, empty slots, and unknown names fail or remain incomplete.
- A previously valid arrangement changed to an invalid one no longer shows success.
- Existing completed users can still follow the replay/explanation flow.
- Focused EditMode tests cover pair validation; Play Mode verifies drag/drop and all feedback references.

## 4. Activity 5 results procedure

### Confirmed problem

`Assets/Scenes/Aktiviti5/5.3.unity` contains a procedure about water baths, lipase, and phenolphthalein. Activity 5 is about food energy using cashews and peanuts.

### Proposed replacement text

The following Malay draft follows the Activity 5 simulation's equipment and learning objective. Check it against scene `5.2`, animation instructions, result-table units, and the BioNutri-MM teaching module before finalizing exact measurement wording.

1. Timbang kacang gajus dan rekodkan jisimnya dalam jadual keputusan.
2. Sukat 20 ml air suling menggunakan silinder penyukat dan masukkan air ke dalam tabung didih.
3. Catat suhu awal air menggunakan termometer.
4. Cucukkan kacang gajus pada jarum yang dipasang pada plastisin.
5. Nyalakan kacang gajus menggunakan penunu Bunsen, kemudian letakkan kacang yang masih menyala di bawah tabung didih mengikut susunan radas dalam simulasi.
6. Apabila nyalaan padam, catat suhu akhir air dan hitung kenaikan suhu air.
7. Ulang eksperimen menggunakan kacang tanah dan 20 ml air suling yang baharu. Rekodkan jisim kacang serta suhu awal dan suhu akhir air. Kekalkan susunan radas dan keadaan eksperimen yang sama untuk perbandingan.
8. Hitung nilai tenaga bagi setiap sampel makanan menggunakan rumus yang diberikan dan bandingkan keputusan.

For any formula review, use consistent units: energy transferred to water in kJ = mass of water in g × 4.2 × temperature rise in degrees C / 1000; divide by food mass in g for kJ/g. Confirm whether the module uses initial sample mass or measured mass burned before changing any calculation or answer key. Do not invent observed temperatures, masses, or expected answers.

### Implementation and validation

- Replace only the relevant TextMeshPro procedure text; inspect for duplicate displayed copies.
- Preserve scene object IDs, event wiring, fonts, and unrelated content.
- Check text wrapping, font size, scrolling, and clipping in the results page at its intended aspect ratios.
- Verify that the procedure matches the lab sequence and results table. Avoid unrelated scene reserialization.
- No new automated tests are needed for this text-only correction; inspect the scene diff and render the page in Unity.

## 5. Secure chatbot implementation

### Current state and immediate remediation plan

The chatbot implementation in `Assets/Samples/OpenAI Unity/0.2.2/ChatGPT/ChatGPT.cs` embeds an OpenAI credential and sends requests directly from Unity. Do not reproduce the credential in documents, logs, examples, or commits.

When implementation is authorized:

1. The credential owner should revoke the exposed key and inspect usage for unexpected activity. Removing source text alone does not invalidate a leaked key.
2. Create a replacement dedicated project credential and store it only on the backend with the minimum needed permissions.
3. Remove embedded credentials from source and inspect tracked files, history, release archives, and built clients using redacted or filenames-only reports.
4. Rebuild affected clients. Handle any Git history rewrite as a separate coordinated operation; it changes commit IDs and cannot invalidate existing copies of the key.

No key revocation, account action, history rewrite, or deployment is authorized by this planning document.

Official OpenAI guidance says application keys must stay out of client code and be loaded on the server from an environment variable or secret manager. It also recommends promptly revoking compromised keys. See [API authentication](https://developers.openai.com/api/reference/overview) and [safety best practices](https://developers.openai.com/api/docs/guides/safety-best-practices).

### Recommended architecture

```text
Unity chat UI
  -> HTTPS application backend /api/chat
     -> validate application session, request, and quotas
     -> choose trusted lesson prompt and bounded conversation
     -> call OpenAI using a server-only credential
     -> return answer text and a safe request identifier
```

The current Unity scripts already call PHP endpoints. An HTTPS PHP endpoint using server-side HTTP requests is a practical option if that hosting supports protected configuration, outbound HTTPS, authentication, and rate limiting. A managed serverless function is an alternative if it provides those capabilities. Backend source and hosting configuration have not been established in this workspace; inspect them before choosing deployment details.

### Server requirements

- Load `OPENAI_API_KEY` through hosting secrets or server environment configuration. If local server development uses a `.env` file, keep it outside the public web directory, exclude it from Git, and commit only an example containing placeholders.
- Never put the replacement key in Unity `PlayerPrefs`, Inspector fields, ScriptableObjects, Resources, StreamingAssets, client-side environment files, or an encrypted string with a bundled decryption key. These approaches still distribute a recoverable secret.
- Require a server-validated application session. `LoginController` currently bypasses login and `PlayerPrefs.id_user` is client-controlled; neither can authenticate paid chatbot requests. Restore real server authentication and issue expiring/revocable sessions before public chatbot rollout. Never ship a shared backend access secret in the client.
- Apply per-user and per-IP throttling, concurrent-request limits, bounded message/history lengths, bounded output tokens, and a server-enforced usage quota. Initial limits should be configurable and verified against expected classroom usage.
- Accept an allowlisted lesson/context ID. Choose the educational instructions on the server; do not accept arbitrary client-provided system/developer prompts, model names, upstream URLs, or API parameters.
- Keep model selection server-side. The current code uses `gpt-4o-mini`; preserve it if available to the account, with compatibility verified during implementation. No model upgrade is part of these fixes.
- Bind stored conversations to the authenticated user. Changing lessons should explicitly update the server prompt or start a new conversation; the present client adds its prompt only on the first message.
- Avoid sending student passwords, names, email addresses, or unrelated account data to the model. Document any chat retention policy and minimize stored chat content.
- Use HTTPS with certificate validation. For WebGL, allow only intended origins where feasible, but do not rely on CORS as authentication.
- Return safe errors and request IDs; do not expose authorization headers, credentials, upstream debug dumps, or full student messages in routine logs.
- Bound upstream execution time and handle failures without unbounded retries. Use request IDs to deduplicate repeated submissions where needed.

### Proposed application contract

```http
POST /api/chat
Authorization: Bearer <short-lived application session token>
Content-Type: application/json
```

```json
{
  "contextId": "2.2",
  "message": "Apakah fungsi enzim amilase?",
  "conversationId": null,
  "requestId": "<unique request identifier>"
}
```

```json
{
  "reply": "<educational answer>",
  "conversationId": "<server-owned conversation identifier>",
  "requestId": "<request identifier>"
}
```

The application session token is not an OpenAI key. Authenticate and authorize conversation IDs on every request. Use HTTP 400 for invalid input, 401/403 for session/access failures, 429 for quotas, and a sanitized 5xx response for upstream failures. This contract is proposed, not an existing endpoint.

### Planned Unity changes

- Preserve the `ChatGPT` MonoBehaviour identity, serialized UI references, and `ChangePrompt()` entry point so existing scenes and prefabs remain wired.
- Replace direct `OpenAIApi` calls with `UnityWebRequest` to the application backend.
- Keep only non-secret endpoint configuration and the minimum session/context data in the client. Send context IDs rather than authoritative prompt text.
- Restore input/button state in a `finally` path after success, timeout, cancellation, or error. Prevent simultaneous duplicate submissions.
- Show helpful Malay messages for offline mode, expired sessions, exhausted quotas, and temporary service failure.
- Audit other OpenAI package consumers before removing dependencies; do not remove the package merely because this component stops using it.

### Verification before release

- Backend tests: missing/expired sessions, another user's conversation, invalid contexts, oversized input, throttling/quota exhaustion, duplicate requests, and upstream timeouts.
- Unity checks: successful reply, context change, offline mode, error recovery, and input/button recovery.
- Inspect source and a built client for embedded provider credentials without printing matches.
- Confirm that the replacement credential exists only in protected backend configuration.
- Use mocked provider calls first. Any live API smoke test must use the secured backend and a deliberately small request.

## 6. Proposed delivery order

1. Review this document.
2. Implement the three local fixes and run their focused checks.
3. Confirm backend hosting and authentication details; implement the chatbot proxy and client migration.
4. Coordinate credential rotation and release verification with the credential owner before enabling public chatbot traffic.
5. Report changed files, verification evidence, and any remaining hosting/account tasks.

Completion means repeated submissions produce stable scores, the plate accepts only valid full arrangements, Activity 5 displays the correct readable procedure, and the distributed game contains no OpenAI credential while chatbot access is authenticated and bounded by the server.
