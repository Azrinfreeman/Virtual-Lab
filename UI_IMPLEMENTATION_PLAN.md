# BioNutri-MM UI refinement implementation plan

Status: Implementation started after approval. See `Documentation/UIReview/IMPLEMENTATION_REPORT.md` for delivered changes, captures, verification, and remaining work. The specification below remains the reference for subsequent refinements.

## 1. Objective and theme boundaries

Make the existing interface easier to understand, click, navigate, and read while preserving its identity. Refine arrangement and behaviour before adding controls.

Preserve the existing BioNutri-MM branding, science/laboratory artwork, backgrounds, colour palette, fonts, button sprites, panel shapes, educational illustrations, Malay language, audio character, and learning sequence. Use existing visual assets for any necessary additions. Do not introduce a new theme, replace backgrounds, commission new artwork, migrate to a different UI framework, or redesign the game as a dashboard.

Small additions are justified only when they solve a clear problem: a short instruction, a visible selected state, a close control, a loading message, or an otherwise missing navigation label. Avoid new badges, achievements, animation effects, or progress claims unsupported by saved data.

## 2. Inspection findings and limits

Reviewed representative scene serialization for StartMenu, Login, MainMenu, MainMenuAktiviti, MainMenuSemakan, Activity 2's entry/lab, Activity 5's worksheet, Activity 4's quiz, and Activity 8's plate. Reviewed existing background/panel artwork and relevant UI/drag scripts.

| Evidence | Implication for implementation |
|---|---|
| Most inspected screen canvases use a 1920×1080 reference resolution and width-only scaling match. | Test resizing and anchors; do not assume the original layout fits 16:10 or 4:3. |
| The lab also has constant-pixel-size canvases. | Identify screen UI versus apparatus/world labels before changing scaling. |
| Many controls use automatic navigation. | Verify keyboard traversal through visible controls and dialogs. |
| Activity selection includes separate confirmation panels for individual activities; activity pages also contain many confirmation panels. | Keep confirmations for leaving unfinished work; assess whether ordinary navigation needs an extra step. |
| Worksheet serialization includes font sizes around 13–17 alongside larger body text; other scenes use many individual sizes. | Check actual rendered sizes and parent scales, then unify comparable text roles. Serialized size alone does not prove unreadability. |
| Representative scenes contain many raycast-enabled UI graphics and nested scroll views. | Inspect blockers and wheel/drag routing. Counts include inactive objects and do not by themselves prove a bug. |
| `DragScript` locates a canvas by name and uses its scale factor; several scripts use child indices and animation names. | Preserve names/hierarchy and validate drag coordinates before changing parents or scaling. |
| The screenshot attempt returned the camera background without the overlay UI. | No complete before/after visual evaluation has been performed. Obtain reliable Game View captures during implementation before judging alignment, contrast, or clipping. |

No scene was opened, played, or saved for this review. The active StartMenu remained unchanged. A temporary capture was written under ignored `Temp/UIReview`.

## 3. Common layout rules

Use the existing 1920×1080 reference as the initial design baseline. The values below are starting targets, to be checked against the actual artwork and available space.

- Apply consistent outer margins of roughly 48–64 reference units, panel padding of 24–32, and related-control gaps of 12–24. Choose a small spacing scale and use it consistently.
- Align headings, panel edges, fields, and actions to shared guides. Avoid centring long instructional paragraphs; keep them left-aligned with clear line spacing.
- Establish a restrained text hierarchy using the current font: approximately 44–60 for screen titles, 32–40 for section titles, and 26–32 for body text. Use smaller text only for secondary information that remains legible in the rendered view. Keep existing appropriate sizes rather than changing every label.
- Give related buttons consistent heights and padding. Aim for a rendered hit area around 44×44 pixels or greater at the smallest supported desktop viewport, without overlapping neighbours. Larger invisible hit areas may be used where they do not conflict with drag targets.
- Fit long Malay labels by wrapping into sensible lines or widening controls. Do not rely on unlimited auto-shrink or stretched text.
- Anchor headers, back controls, and footer actions to their intended edges. Let reading content scroll when needed; do not shrink the whole page to fit.
- Evaluate a balanced CanvasScaler match for screen canvases at alternate aspect ratios. Do not apply one value globally to world-space labels or animation-driven content.

## 4. Screen-specific changes

### Start, login, and registration

Retain the existing artwork and title treatment. Align the primary start action clearly beneath the branding. Centre the login/register form as a coherent group with equal field widths, consistent labels and spacing, and error text reserved near the relevant field. Keep exit/back actions secondary and visually distinct from submission.

Use logical Tab order and an obvious focus state. Enter submits only when a form is ready. Show a loading state during a real request and prevent duplicate submissions. These UI states must reflect actual authentication; this work does not restore the missing hosted login implementation.

### Main menu and activity selection

Align existing menu items with equal sizes and gaps. Keep the main task, choosing an activity, easiest to find through placement and the existing selected/hover styling.

For eight activities, prototype a regular 4-column × 2-row arrangement at 16:9 inside the existing panel, with a readable alternative arrangement or vertical scroll for narrower views. Keep each activity's existing visual identity. If currently only a number is visible, add its short Malay topic using the existing font so students can choose without opening every activity.

Place Back consistently. Leave help and chatbot access in stable secondary positions outside the main content. Do not add a search field or category filter for eight items.

### Activity entry and theory

Arrange existing Theory, Virtual Lab, Results, and Quiz choices in a consistent order across Activities 2–7. Indicate the active section with an existing colour or sprite state. Keep Activity 1 and Activity 8's distinct structures intact.

Separate objectives, explanations, and illustrations into readable regions within existing panels. Use one clear scroll direction for long content, visible scroll affordances where appropriate, and consistent Previous/Next placement. Check that illustrations retain their proportions.

### Virtual laboratory

Give the apparatus the largest uninterrupted working region. Keep the existing instruction panel at a predictable edge, with the current step and progress visible. Group instruction history, equipment information, and help together; use existing collapsible panels so optional detail does not cover the experiment.

Keep essential labels readable against the lab using existing panel treatments where needed. Show which equipment is selected using the established outline/highlight. Add a short first-use drag/click hint only where the current instruction is insufficient.

During a drag, emphasize the relevant destination only if it supports the existing lesson logic. An invalid drop should return the item to its valid origin or last valid slot. Do not create a second item or overwrite another occupied answer silently. Avoid auto-performing experiment steps or changing results.

### Results worksheets and quizzes

Use consistent headings, field widths, row heights, and units. Align numeric values and their labels. Keep answer fields separated from explanatory text and ensure focus/placeholder text is legible.

For long worksheets, prefer one main vertical scroll region. Keep Submit in a predictable footer without covering the final row. Preserve all required questions, answer keys, scoring, and saved data.

For quizzes, clearly separate the question, options/answer bank, and navigation. Use a text label such as “Soalan 3 daripada 10” only when it can be derived correctly from the actual question sequence. Preserve existing learning feedback timing; highlighting a drop target must not reveal the correct answer before submission.

On submission, show one coherent result state with score and clear next actions. Avoid stacking duplicate success/failure panels. Retrying must reset the visible interaction state without reintroducing the previously fixed scoring issue.

### Healthy Plate and Food Pyramid

Keep the plate/pyramid artwork. Arrange answer items in an aligned tray with adequate separation. Make empty slots and valid drag regions evident using existing borders, labels, or highlight colours.

Provide clear pickup/drop feedback and readable failure/retry messages. Consider click-item then click-slot as a fallback only if drag remains difficult after the layout fixes; retain drag support. Verify slot assignments, uniqueness validation, replay, and explanation flows after any change.

### Score review

Align existing quiz and experiment marks in a table-like layout with consistent activity labels, columns, and score formatting. Use scrolling for space constraints. Distinguish loading, unavailable data, and a genuine zero score; do not manufacture completion statuses.

### Chatbot and dialogs

Place chatbot access at a consistent edge where it cannot cover Back, Submit, or apparatus controls. Keep its existing visual treatment. Constrain the expanded panel, make Close obvious, and prevent scroll input leaking into the underlying page. Keep configuration/session failures readable within the chat panel.

Standardize dialogs with aligned heading/body/actions, consistent button order, and sensible focus. Opening a modal blocks underlying UI and lab-object input. Closing restores focus. Escape cancels or closes a dismissible dialog; it must never confirm submission or discard work automatically.

Reduce navigation-only confirmations where no work can be lost. Preserve confirmations for application exit, logout, discarding unfinished answers, or irreversible submission. Verify what actually resets on scene navigation before removing a prompt.

## 5. Interaction polish

- Use the existing palette for hover, keyboard focus, pressed, selected, and disabled states. State changes must also be understandable through outline, shape, or text rather than colour alone.
- Preserve existing UI sounds and avoid retriggering them every frame. Keep any transition subtle and brief; do not add decorative motion.
- Restrict tab navigation to active, visible controls. Set explicit neighbours on dense menus or quizzes when automatic navigation gives unpredictable results.
- Audit decorative text/images for unnecessary raycast interception. Preserve intentional modal blockers and drag/drop targets; do not globally disable raycasts.
- Prevent double clicks during scene transitions and network requests; restore controls after errors.
- Where UI overlaps a 3D lab, verify world interactions are suppressed while the pointer is over blocking UI. Avoid disabling the whole experiment to support a small nonmodal tooltip.

## 6. Implementation approach after approval

1. Capture reliable before images at 1920×1080 and 1366×768. Record active/inactive panels, modal states, and current input behaviour. Check for unsaved editor work before switching scenes.
2. Pilot the refinement on MainMenuAktiviti. Reuse existing assets and compare the result with the baseline for theme consistency.
3. Pilot one lab (`2.2`), one worksheet (`5.3`), and one quiz (`4.4`). Resolve scaling, scrolling, drag/drop, and modal behaviour on these examples before applying shared rules.
4. Apply the proven adjustments across related scenes, then refine the distinct Activity 1 and Activity 8 interactions.
5. Prefer inspector/RectTransform and existing component changes. Introduce small reusable helpers or shared prefab elements only where repetition genuinely warrants them.
6. Preserve GameObject names, serialized IDs, button UnityEvents, animation bindings, and script assumptions. Inspect Animator/AnimationClip paths before moving a child. Avoid a wholesale hierarchy rewrite or an indiscriminate script that resizes every UI object.
7. Keep diffs limited to the reviewed UI work. Preserve existing source changes, scoring fixes, backend work, and secure credential handling.

Likely assets: `Assets/Scenes/*.unity`, the eight activity folders, affected UI prefabs including chatbot panels, and narrowly scoped UI interaction scripts. Determine the exact file list from the pilot rather than promising a global replacement.

## 7. Verification and acceptance

Test desktop landscape at 1920×1080, 1366×768, 1280×720, 1920×1200, and 1024×768. Use an ultrawide view as an additional anchor check. Portrait/mobile redesign is outside this scope unless the actual build target requires it.

Acceptance criteria:

- The game is recognizably the same theme, using its existing art, fonts, colours, and button treatment.
- Titles, text, images, inputs, and actions have no unintended overlap, clipping, stretching, or inaccessible off-screen placement at the agreed viewports.
- Main menu and activity choices have consistent alignment and spacing; long labels remain readable.
- Pointer clicks and keyboard navigation reliably reach visible controls. Modals block underlying interactions and restore focus on dismissal.
- Scroll regions respond predictably and cannot hide mandatory fields or Submit behind fixed UI.
- Lab selection, dragging, timing/animation progression, and instruction history still work. Invalid drops do not lose or duplicate answer items.
- Healthy Plate/Pyramid retry and explanation flows still work; the corrected plate and scoring regression checks continue to pass.
- Score review and chatbot distinguish loading/error/unavailable states from real data.
- No new console errors, missing references, broken UnityEvents, or animation binding warnings appear.

Verify visual changes through before/after captures and interaction walkthroughs. Add focused behavioural tests only for new navigation, modal, or drag-state logic; do not add tests that merely restate fixed coordinates. Summarize any remaining visual limitations honestly.

## 8. Delivery

After implementation approval, deliver the refined scenes/prefabs/scripts, representative before/after screenshots, a short list of behavioural changes, and verification results. No UI implementation is authorized or performed by the creation of this document.
