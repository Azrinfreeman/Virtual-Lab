# BioNutri-MM colour language — implementation plan

Status: **Proposal only. Nothing in the Unity project has been changed.** Approve (or edit) this document before any scene, prefab, or script is touched.

Scope of this document: colour only (`/color-theory`). The animation (`/unity-animation`) and layout (`/game-ui-ux`, `/game-designer`) parts of the original request are not planned here; section 9 lists where colour and motion must be coordinated so those plans can reuse the same tokens.

## 1. Relationship to the earlier UI plan

`UI_IMPLEMENTATION_PLAN.md` told implementers to *preserve the existing colour palette*. This request overrides that for colour: the palette may change, but the **identity is kept** — deep-space indigo, the cyan/violet "lab" accent, the mascot, and the planet/flask artwork. The artwork is not recoloured; the UI chrome (buttons, panels, text, feedback) around it is.

## 2. What the audit found

Evidence comes from scene serialization (StartMenu, MainMenu, MainMenuAktiviti, 2.2, 4.2), `ButtonAnswers.cs`, `SelectedController.cs`, and the screenshots in `Documentation/UIReview/`. Hex values read from screenshots are approximate (±a few units) and marked ≈.

| # | Finding | Why it hurts |
|---|---|---|
| 1 | **Selecting an answer paints the button `Color.red`** (`ButtonAnswers.cs`, 4 places, `colorBlock.normalColor`). | Red means wrong/stop. A pupil who picks an answer sees "error" before any check has happened. This is the clearest colour-language bug. |
| 2 | **Selection outline is `Color.yellow`** (`SelectedController.cs`). | Yellow is the warning hue; also yellow on the mustard worksheet panels is nearly invisible. |
| 3 | **Every `Button` uses Unity's default ColorBlock** (white / 0.96 / 0.78 grey tints): 112 buttons in 4.2, 96 in 2.2, 26 in MainMenuAktiviti. | Hover/pressed/disabled feel identical everywhere, tint dims the artwork to grey instead of signalling state, and disabled (alpha 0.5) is indistinguishable from "loading". |
| 4 | **All eight activity buttons share one teal→violet gradient with white text** (≈2.3:1 on the teal end). | Fails 4.5:1 for the label text. Nothing says which activity is next, in progress, or done. |
| 5 | **Worksheet panels are saturated mustard ≈`#D6C200`** with a second, darker mustard scrollbar. | Large field of warning-hue behind body text; white on it is 1.8:1. It reads as "caution" on a screen where nothing is wrong. |
| 6 | **Placeholder text "Masukkan jawapan.." ≈`#8A8A9A` on ≈`#D2D3E8`** is ≈2.3:1. | Fails. Pupils may not see that a field is empty and expects input. |
| 7 | **"HANTAR" (submit) is yellow on a grey-yellow bar** and looks disabled. | The primary action of the screen is the weakest element. |
| 8 | Text colours are scattered one-offs: `#000`, `#1A1A1A`, `≈#0F3EB7` blue, `#323232`, light-blue `≈#5FC7FF`. | No hierarchy rule; 3+ "dark text" values with no meaning. |
| 9 | Colour is the only signal for several states (answer chosen, correct/wrong). A tick image exists for chosen, but nothing for correct vs wrong beyond tint. | About 1 in 12 boys have red/green colour-vision deficiency; the audience is school pupils. |

## 3. Colour-meaning principles for this game

1. **Colour = state, not decoration.** A hue is allowed to carry exactly one meaning. Reserved meanings (below) are never reused for ornament.
2. **Brand hues (indigo, cyan) are neutral.** They never indicate correct/incorrect.
3. **Feedback hues are rare and earned.** Green/red/amber only appear after the game has judged something. Selecting is not judging.
4. **Never colour alone.** Each state gets an icon or text label as well (✓ / ✕ / ! / lock) — this also matches the mascot-led, Malay-language tone ("Betul!", "Cuba lagi").
5. **No per-activity rainbow.** Eight activities cannot be given eight distinguishable hues once red/green/amber are reserved for feedback and the background is indigo; the colour would carry no meaning. Activities are differentiated by title, number, and *state*, not hue. (If a topic-specific hue is wanted later, use the colours already present in each activity's own artwork, e.g. the plate/pyramid segments in Activity 8, and keep it out of buttons.)
6. **Test in greyscale.** Hierarchy (primary action > secondary > disabled; selected > unselected) must survive with hue removed.

## 4. Palette

Defined in OKLCH-oriented steps but shipped as sRGB hex because Unity's `Color`/TMP fields are sRGB. Project colour space is expected to be Linear: confirm in Project Settings → Player before applying, because the same hex looks different in Gamma vs Linear (see section 8, risk 1). All contrast ratios below were computed (WCAG 2.x relative luminance), not estimated.

### 4.1 Surfaces (dark "space" UI) — replaces ad-hoc dark blues

| Token | Hex | Role |
|---|---|---|
| `surface.base` | `#14103F` | Behind everything; matches existing indigo backdrop |
| `surface.raised` | `#221C5C` | Panels/cards on top of base (lighter = higher; no pure black) |
| `surface.overlay` | `#2C2670` | Pop-ups, pause, confirmation dialogs |
| `surface.paper` | `#F6F1E4` | Worksheets and forms (replaces mustard); warm off-white, easy on long reading |
| `surface.field` | `#FFFFFF` | Text inputs on paper |

### 4.2 Text

| Token | Hex | On | Ratio |
|---|---|---|---|
| `text.primary` | `#F4F2FF` | `surface.base` | 16.2:1 |
| `text.secondary` | `#C9C4EE` | `surface.raised` | 9.1:1 |
| `text.muted` | `#A39DD6` | `surface.raised` | 6.0:1 |
| `text.disabled` | `#8F89C4` | `surface.raised` | 4.7:1 (disabled is conveyed by dimming + no hover, not by unreadability) |
| `ink.primary` | `#1E1B3A` | `surface.paper` | 14.6:1 |
| `ink.muted` | `#5B5780` | `surface.paper` | 6.0:1 |
| `ink.placeholder` | `#6F6A94` | `surface.field` | 5.0:1 (fixes finding 6) |

### 4.3 Interaction (brand, never feedback)

| Token | Hex | Meaning |
|---|---|---|
| `action.primary` | `#17508C` fill, `#FFFFFF` label (8.2:1) | The one main thing to do on a screen: Mula, Hantar, Seterusnya. Existing cyan→violet gradient sprite is kept, tinted into this range so white text passes. |
| `action.primary.hover` | lighter step of the same hue (+6% L) | Pointer/gamepad focus |
| `action.primary.pressed` | darker step (−8% L) | Press |
| `action.secondary` | transparent fill, `#C9C4EE` 2 px outline + label | Kembali, Batal, Tetapan |
| `focus.ring` | `#FFFFFF` 3 px | Keyboard/gamepad focus. 15.1:1 on `surface.raised`. Always visible, never removed on hover |
| `select` | `#B8A9FF` ring + filled-dot icon (7.3:1 on raised); on paper `#5B3FD1` (6.1:1) | "I chose this" — a **violet** that is distinct from success, error and warning. Replaces `Color.red` and `Color.yellow` |
| `field.border` | `#7B75AD` on paper (3.7:1) | Input outlines; meets the 3:1 non-text minimum |

### 4.4 Feedback (reserved — only after the game evaluates something)

| Token | Dark-UI colour | Paper colour | Icon + word | Used for |
|---|---|---|---|---|
| `feedback.success` | `#3DDC97` (8.6:1 on raised; ink `#062B1A` on fill 8.7:1) | `#0F7A4A` (4.8:1) | ✓ "Betul" | Correct answer, activity completed, valid plate |
| `feedback.error` | `#FF6B6B` (5.5:1; ink `#3A0A0A` on fill 6.2:1) | `#B3261E` (5.8:1) | ✕ "Salah / Cuba lagi" | Wrong answer, failed login, invalid input |
| `feedback.warning` | `#FFB020` (8.3:1; ink `#2B1A00` on fill 9.2:1) | `#8A5A00` (5.3:1) | ! | Unsaved progress, leaving an unfinished activity (the existing confirmation panels) |
| `feedback.info` | `#5CC8FF` (8.0:1) | — | i | Hints, mascot tips, instructions (matches the current light-blue titles) |

Red/green pairs differ in lightness as well as hue and always carry ✓/✕, so they stay distinguishable under deuteranopia/protanopia. Verify with a simulator (section 7).

### 4.5 Progress/state ramp for the activity grid

| State | Treatment | Meaning |
|---|---|---|
| Locked / not yet available | `surface.raised`, `text.disabled`, lock icon | Cannot open yet |
| Available | `action.primary` | Ready |
| In progress | `action.primary` + `select`-violet progress bar | Started, not finished |
| Completed | `action.primary` + `feedback.success` ✓ badge (badge only, button stays blue) | Done |

Locked/in-progress/completed must be backed by saved data. If the game does not persist per-activity completion, build only "available" for now and do not invent progress (consistent with `UI_IMPLEMENTATION_PLAN.md` §1).

### 4.6 Proportions (60 / 30 / 10)

- 60 % `surface.base` + existing artwork
- 30 % `surface.raised`/`paper` panels
- 10 % `action.primary` and the single accent per screen; feedback colours fill only the element they judge

## 5. Implementation steps (to run after approval)

### Step 1 — Central palette asset (no visual change yet)

1. Add `Assets/UI/Theme/BioPalette.cs`: a `ScriptableObject` exposing every token above as a `Color`, plus helper `static Color Hex(string)`. Add one asset `BioPalette.asset`.
2. Add `Assets/UI/Theme/BioButtonColors.cs`: builds the shared `ColorBlock` (normal/highlighted/pressed/selected/disabled, `colorMultiplier = 1`, `fadeDuration = 0.1`) for `action.primary`, `action.secondary`, `choice`.
3. Add an editor window/menu `Tools ▸ BioNutri ▸ Apply Palette` that applies colours to scenes in a repeatable, idempotent pass (used in Steps 3–5). Reuse the existing `Assets/Editor/BioNutriUIReview.cs` conventions.

### Step 2 — Fix the semantic bugs in code (highest value, lowest risk)

| File | Change |
|---|---|
| `ButtonAnswers.cs` | Replace `Color.red` with `palette.select`; keep the existing tick image. Remove duplicated copy-pasted `ButtonClicked1..4` colour logic into one helper (`SetSelected(int index)`), leaving the public method names for the existing Button OnClick references. |
| `SelectedController.cs` | Outline colour `Color.yellow` → `palette.select`. |
| Answer-check scripts (`KuizController`, `Kuiz1Controller`, `CorrectAnswer`, `PingganIsiController`, `PiramidJawapanController`) | After evaluation, set `feedback.success` / `feedback.error` plus ✓ / ✕ icon and the Malay word. No colour before evaluation. (Inspect these first; do not assume their structure.) |
| `LoginController.cs` | Error text and field border → `feedback.error` + message text. |

### Step 3 — Buttons

Apply `BioButtonColors` to every `Button` via the editor tool, grouped by role:

- Primary: Mula, Hantar, Seterusnya, Semak
- Secondary: Kembali, Home, Settings, Batal
- Choice (quiz options): normal surface, selected = `select`, evaluated = success/error
- Activity cards in MainMenuAktiviti

Set `Image` tint to white and rely on ColorBlock for states so the gradient sprite is not double-tinted. Text becomes `text.primary` on primary, `text.secondary` on secondary.

### Step 4 — Text and panels

1. TMP `fontColor` values: map `#000`, `#1A1A1A`, `#323232` → `ink.primary` on paper; `≈#0F3EB7` → `ink.primary` (it currently doubles as a heading colour; headings are distinguished by size/weight, not a second dark blue); light-blue titles → `feedback.info`-family `#5CC8FF` kept as the *screen title* colour so titles are consistent.
2. Worksheet/mustard panels (2.2, 4.2 and similar) → `surface.paper`; scrollbar track `surface.raised` at low alpha, handle `field.border`.
3. Placeholder text → `ink.placeholder`; field outline → `field.border`.
4. Greyscale-translucent overlay panels (`≈{0.27,0.21,0.21,0.39}` alpha used 45–58 times) → `surface.overlay` with a defined alpha (0.92) so text behind never bleeds through.

### Step 5 — Confirmation panels

Use `feedback.warning` header strip + icon for "leave unfinished work" prompts; primary action there is the safe one (stay), the destructive one is `action.secondary` with warning outline. Never red here — red is for wrong answers.

### Step 6 — Scene coverage order

Edit and verify scene by scene, committing after each group: Start/Login/Register → MainMenu + Objektif/Aktiviti/Semakan → Activity 4 (quiz-heavy, proves feedback colours) → Activity 2 (worksheet-heavy, proves paper surface) → remaining activities 1, 3, 5, 6, 7, 8. Keep GameObject names and hierarchy unchanged (`DragScript` and several scripts rely on names/child indices, per the earlier plan).

## 6. Acceptance criteria

- No `Color.red`, `Color.yellow`, or other literal colours left in gameplay scripts; all colours come from `BioPalette`.
- Selecting an answer never shows success or error colours.
- Every text/background pair in section 4 meets its ratio (≥4.5:1 text, ≥3:1 large text/UI components).
- Every button shows distinct normal / hover / pressed / focus / disabled states.
- Feedback states are readable in greyscale and under protanopia/deuteranopia/tritanopia simulation.
- Placeholder, scrollbar and field borders are visible on `surface.paper`.
- Layout, names, serialized references, and button method names are unchanged (diff review per scene).

## 7. Verification

1. Contrast: a small editor script (or Python) that reads `BioPalette` and asserts the pairs in section 4 — run it in CI/editor so token edits cannot silently regress.
2. Game View captures per scene before/after at 1920×1080, 1366×768 and 2560×1440 (the `Documentation/UIReview` capture approach; earlier notes say overlay UI was missed once, so confirm the canvas is captured).
3. Colour-blindness and greyscale: apply a simulation filter to the captures (or the Unity Device Simulator / a post-process in the capture tool only) and review the answer-feedback screens.
4. Play Mode pass through one full activity per type (quiz, worksheet, drag-drop, plate), checking each state transition.
5. Unity MCP/Editor was unavailable in previous runs; if it is unavailable again, the tool-driven edits in Steps 3–4 cannot be verified and should not be claimed as done.

## 8. Risks and mitigations

1. **Linear vs Gamma colour space** — hex values will render differently if the project is in the other mode. Check `ProjectSettings/ProjectSettings.asset` (`m_ActiveColorSpace`) first and compare a swatch screenshot against the hex.
2. **Baked-in colour in sprites.** Button and panel sprites already contain gradients; tinting multiplies, so very dark tints will go muddy. Prefer redrawing only the few sprites that fight the palette, or use near-white sprite + tint.
3. **Hundreds of copy-pasted buttons and prefabs.** Do the sweep with the idempotent editor tool, not by hand, and exclude world-space lab apparatus colours.
4. **Mustard worksheets are part of the current look.** Changing them is the most visible change; capture a before/after for approval before applying to all worksheet scenes.
5. **Red/green accessibility** — mitigated by icon+word+lightness difference, but still verify.
6. **Persisted-progress UI states** — only build locked/in-progress/completed if the save data supports it.

## 9. Hooks for the animation and layout plans

- State transitions should tween between palette tokens (Animator colour curves or code lerp in OKLCH-like steps), not between arbitrary colours: selection pulse = `select`, correct = brief `feedback.success` flash + ✓ scale-in, wrong = `feedback.error` with a small shake + ✕, hint = `feedback.info`.
- Reduced-motion / no-colour fallback: keep icon and text feedback even when the colour animation is off.
- Layout plan should use the same elevation order (`base < raised < overlay`) for panel stacking.

## 10. Open decisions for you

1. Replace the mustard worksheet panels with off-white `surface.paper` (recommended), or keep a toned-down warm panel?
2. Confirm "Colour = state": no per-activity hues (recommended), or do you want topic hues limited to small tags using colours from each activity's own artwork?
3. Is per-activity progress (in-progress / completed) already saved anywhere that the UI can read?
4. OK to remove the duplicated `ButtonClicked1..4` logic while fixing the red selection, keeping the public method names?

## 11. Implementation status (applied)

Approved choices: paper worksheets, small topic tags, per-activity progress allowed, `ButtonClicked1..4` refactor allowed.

Done:
- `Assets/UI/Theme/BioPalette.cs` — static token class (used instead of a ScriptableObject; no asset to keep in sync). Includes `TopicTags`.
- `ButtonAnswers.cs` — selection is violet (`BioPalette.Select`); duplicated `ButtonClicked1..4` collapsed into `SetSelected(int)`, public method names kept. `SelectedController.cs` outline is violet.
- `Assets/Editor/BioPaletteApplier.cs` (`Tools > BioNutri > Apply Palette`) applied across all scenes under `Assets/Scenes` and the prefab folders: button colour states, ink/info text mapping, mustard panels → paper, overlay panels, gradient `button2` and flat `UISprite` buttons → readable primary style, quiz options → neutral choice surface, login error text → error colour.
- Topic stripes on the eight activity cards in `MainMenuAktiviti` (pastel, with the topic name always shown).
- Visual checks (captured with the existing `BioNutriUIReview.Capture`): StartMenu, Login, MainMenu, MainMenuAktiviti, 4.1, 4.4, 5.4.

Not done / needs your eyes:
- Per-activity progress badges: the code only stores progress on the server (`LoadUserScore`/`LoadUserEks`, hosted login absent), so locked / in-progress / completed states were not built.
- Correct/wrong feedback colours: no script currently shows per-answer correctness, so success/error tokens exist but are not wired to any UI yet.
- Scenes not visually reviewed: Activities 1–3, 6–8, Register, settings overlays, 3D-lab HUDs. Text colour mapping is value-based and may be wrong where dark text sat on dark artwork.
- No Play Mode run or colour-blindness simulation was done.

### 11.1 Feedback build and review pass

- `ButtonAnswers.ShowResult()` + `KuizController.checkAnswers/checkAnswers5Q` now mark the right option green with "- Betul" and a wrongly chosen option red with "- Salah" once the quiz is checked (idempotent, works for hidden pages). Verified by calling it in edit mode on 5.4 (colours and labels as expected; scene not saved with test state). Not run through a real Play Mode submission.
- Not covered by feedback: drag-and-drop (`ItemSlot`, pyramid/plate) and typed-answer (`InputBehaviour`, `MultiAnswer`) questions.
- Reviewed additionally: Register, MainMenuSemakan, 1.1, 3.4, 7.4 (captures in `Temp/ColorReview/r_*.png`). Layout and text contrast look correct there.
- Open: red leader lines in the 1.1/1.6 anatomy diagram (decorative callouts, not judged state) still use red; the 3D-lab HUD scenes and 6.4/8.x/Objektif were captured but not individually inspected.

### 11.2 Feedback for all question types

`KuizController.ShowResults()` now adds a "Betul" (green) / "Salah" (red) badge at the top-right of every question page after `checkAnswers`/`checkAnswers5Q`, driven by `soalanAnswer`, so drag-and-drop, typed-answer and tick-box questions get feedback too (multiple-choice also keeps its per-option colouring). Verified in Play Mode on 5.4: badges were created on all 8 questions with the expected text. Visual placement/size of the badge was not seen (Game View capture does not include the overlay UI in this project), so check it in the Editor.
