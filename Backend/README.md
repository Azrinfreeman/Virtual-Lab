# PHP chatbot deployment and login integration

The Unity client now calls your HTTPS PHP endpoint. It no longer contains a provider credential. The service is not deployed or enabled automatically.

## Hosting setup

1. Revoke the previously embedded OpenAI key in your account and review usage. Create a replacement project key only for the server. Removing source text does not invalidate the old key.
2. On PHP 8.1+ hosting, enable PDO MySQL, cURL, and mbstring. Import `php/schema.sql` into your application's MySQL database using InnoDB.
3. Copy `config.example.php` to a private directory **outside public_html**, fill its database credentials and server-only OpenAI key using hosting secrets, and set `BIONUTRI_CHAT_CONFIG` to its absolute path. If your host cannot set environment variables, set the private absolute config path in `chat.php` on the server. Never put the private config inside this repository or Unity Assets.
4. Upload only `chat.php` and `chat-policy.php` into the public API directory. Example URL: `https://your-host.example/api/chat.php`. Do not upload the example config, schema, test file, or login helper as public routes. Require HTTPS and ensure PHP does not display errors.
5. Configure the exact game's origin for WebGL. Ensure your host forwards the Authorization header to PHP. Rate limiting uses the real peer IP; behind a CDN or reverse proxy, configure trusted IP handling at the server. Do not simply trust all X-Forwarded-For headers.
6. Use a database account restricted to the chatbot tables. Named MySQL locks must be supported. Start with 50 attempts/user/day, 500 attempts globally/day, 30 requests/IP/minute, and one paid call/user at a time. Failed provider calls count against daily quotas. Tune these deliberately for classrooms sharing one IP.

## Existing login backend must issue application sessions

The existing `LoginUser.php` source and actual hosting credentials are absent from this repository. The current Unity login bypass remains unchanged. Do not enable chatbot requests by trusting `PlayerPrefs.id_user` or by giving every client a shared secret.

After the existing server has verified the user's password against its own database, include `session-integration.php` privately and call `issue_chat_session($db, $verifiedUserId)`. Add its returned fields to your authenticated JSON login response. The helper stores only a SHA-256 hash of a random 256-bit token and expires it after one hour. Use server-validated user IDs only. Include the helper after setting PDO's exception mode; it uses the same chatbot database/tables.

In Unity's successful authenticated login handler, pass that returned token to the active chatbot:

```csharp
chatGpt.SetSessionToken(loginResponse.chatSessionToken);
```

Keep the token in memory, and supply it again to a newly instantiated chatbot when scenes change. On logout, call `chatGpt.SetSessionToken(null)`, clear your in-memory session, and have your existing authenticated logout endpoint call `revoke_chat_session`. Do not persist it in PlayerPrefs. Login restoration requires adapting the real server response; no fabricated endpoint or automatic token issuer has been added.

Set `backendUrl` on the existing ChatGPT prefab/component to the HTTPS endpoint above. Empty URL or missing session deliberately leaves chat unavailable with a Malay explanation. Existing UI component references and `ChangePrompt()` remain compatible.

## Behaviour and data

The server validates allowlisted lesson IDs and constructs its own trusted prompt. The client cannot choose the provider URL, model, system instructions, or arbitrary history. Existing `gpt-4o-mini` model selection remains on the server. History retains only the latest four exchanges per conversation, and conversations are owned by the authenticated user. A context change starts a new conversation.

Quotas and request IDs are stored in MySQL and survive PHP worker restarts. Matching successful retries return the cached reply; conflicting/in-progress or failed request IDs return 409 instead of repeating a paid call. A new intentional submission gets a new request ID. Provider timeouts are bounded at 25 seconds, and output is capped at 500 tokens.

Conversation content and cached replies are retained for at most one hour logically. Schedule deletion of expired rows from all four tables every few minutes for physical cleanup (the endpoint also cleans usage, requests, and conversations on authenticated requests). Set private database access, encrypted transport/backups as supported by hosting, and an appropriate classroom privacy/retention policy. Never log tokens or message contents routinely.

## Verification

Run `php -l` on each PHP file and `php Backend/php/policy-test.php`. Policy tests need no API key and make no network requests. Before release, use a staging database and a mocked provider to verify session expiry/revocation, ownership, concurrent calls, quotas, request deduplication, timeout handling, and cleanup. Then perform one small live smoke test through the authenticated service. These database/hosting tests require your actual environment and are not covered by policy tests alone.

Run Unity EditMode tests in `BioNutri.RegressionTests`, then verify the plate prompts, score display/save, results-page layout, and chatbot errors in Play Mode. Rebuild the distributed game; older builds may still contain the old credential. Do not upload existing Publish artifacts unchanged. History rewriting, if needed, must be coordinated separately after credential revocation.

Official guidance: [keep API keys on the server](https://developers.openai.com/api/reference/overview), [revoke compromised keys](https://developers.openai.com/api/docs/guides/safety-best-practices).
