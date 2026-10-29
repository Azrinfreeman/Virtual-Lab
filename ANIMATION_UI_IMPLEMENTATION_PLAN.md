# BioNutri-MM animation and UI implementation plan

Status: Implementation delivered after approval on 29–30 October 2026. See [the implementation report](Documentation/AnimationUIReview/IMPLEMENTATION_REPORT.md) for changes, verification, captures, and remaining release QA. The specification below remains the reference.

## 1. Goal and existing work

Finish the interface and interaction revamp across the game, using motion to explain actions, state changes, and experiment progression. Preserve the Malay learning content, BioNutri-MM artwork, scientific observations, answer keys, and established semantic palette.

This plan applies `unity-animation`, `game-ui-ux`, `game-designer`, and `color-theory`. It extends [UI_IMPLEMENTATION_PLAN.md](UI_IMPLEMENTATION_PLAN.md) and [COLOR_IMPLEMENTATION_PLAN.md](COLOR_IMPLEMENTATION_PLAN.md). The older UI plan's restriction on additional effects is replaced here by the purposeful motion specified below. Existing implementation reports remain evidence of what was actually delivered.

Repository inspection on 29 October 2026 established:

- The working tree was clean at `1a7cf36` before creating this document.
- The project targets Unity **6000.6.7f1**, uses uGUI/TextMeshPro, and has 49 scenes under `Assets/Scenes`.
- `Assets` contains 29 Animator controllers and 345 standalone `.anim` files. Animation already exists extensively; those counts do not establish runtime coverage or quality.
- The earlier UI pass delivered a two-column activity grid, Expand scaling on applicable screen canvases, scrolling adjustments, invalid-drop return, and some keyboard feedback. See [the UI report](Documentation/UIReview/IMPLEMENTATION_REPORT.md).
- `ButtonReactionController` already plays `hover`/`idle`; `SceneController` guards duplicate navigation but waits one second before loading. Lab controllers depend on named Animator states, child paths, and normalized animation time.
- `ProgressController` polls lab Animator states. Its Activity 3 `step15` branch assigns slider value 50 while displaying 75%; this mismatch is confirmed in source.
- `KuizController` creates post-check Betul/Salah badges. Earlier notes establish badge creation, but placement and a complete real submission flow remain unverified.
- Saved scores are fetched by `LoadUserScore`/`LoadUserEks`. A score alone does not establish a lock, an unfinished activity, or completion; unavailable server data must not be presented as a completed or zero-score attempt.

This pass inspected source, scene settings, assets, and existing reports. It did not open scenes, run Play Mode, or verify their present appearance.

## 2. Design direction

Retain the science illustration style, existing backgrounds, fonts, button artwork, and topic identities. Create a stronger hierarchy through alignment, spacing, readable content areas, and consistent actions. Use the palette already implemented rather than starting another theme.

The learning loop should remain clear: choose a topic, understand the task, perform it, inspect the result, and retry or continue. Keep one obvious primary action per state. Leave apparatus and diagrams unobstructed; disclose supplementary explanations on demand. Do not add points, streaks, achievements, timers, or decorative status labels without a learning purpose.

Feedback acknowledges the actual action immediately. A placement cue means an item was placed, not that its answer was correct. Correctness appears only at the lesson's existing evaluation point. Educational timing and results remain authoritative.

## 3. Screen coverage and layout

The rollout must account for all 49 scenes. Use the build scene list to track review status; a shared component update alone does not count as a scene walkthrough.

| Screen family | Layout and interaction changes | Relevant motion |
|---|---|---|
| StartMenu, Login, Register | Preserve branding; align fields and actions; visible focus; inline request/error states | Retain purposeful entrance animation; short press feedback; loading only during an actual operation |
| MainMenu, MainMenuAktiviti, MainMenuObjektif | Consistent Back/help placement; refine existing grid; readable objectives and topic labels | Focus/selection response and a brief panel transition |
| MainMenuSemakan | Align marks and activity labels; separate loading, unavailable, unattempted when known, and genuine zero | One reveal when data arrives; no fake progress counting |
| Activity 1, scenes 1.0–1.6 | Preserve anatomy/absorption illustrations; separate labels, diagrams, and reading areas; audit callout lines | Explain an intentional diagram selection; preserve instructional sequences |
| Activities 2–7, entry and theory (.0/.1) | Consistent section order and navigation; readable paragraphs and proportional illustrations | Brief section change without moving text while it is being read |
| Activities 2–7, laboratories (.2) | Apparatus owns the central workspace; stable step instructions and progress; optional history/help at the edge | Selection, accepted interaction, step change, and existing experiment animation |
| Activities 2–7, worksheets (.3) | Aligned fields, units, and rows; one main vertical scroll; reachable Submit/footer | Field focus and submission state; no animated answer values |
| Activities 2–7, quizzes (.4) | Clear question/answer/navigation regions; reserve feedback space; derive question counts from real pages | Option response; post-check feedback; one result reveal |
| Activity 8, scenes 8.0–8.4 | Inspect each scene's actual role; align plate/pyramid answer trays and targets; preserve explanation and replay | Pickup, placement, return, and evaluated result |
| Chatbot, sidebar, help, and confirmation overlays wherever present | Stable access, readable bounds, close/back control, correct input blocking and focus restoration | Interruptible open/close; no permanent floating or pulsing distraction |

### Shared layout rules

- Keep the 1920×1080 reference and the existing Expand policy where already applied. Inspect canvas purpose before changing anything; screen HUDs and world/apparatus labels require different treatment.
- Start with 48–64 reference-unit outer margins, 24–32 panel padding, and 12–24 control gaps. Adjust to the artwork and smallest viewport, rather than imposing these values globally.
- Anchor persistent navigation to its edge; use layout groups for actual rows/grids. Preserve aspect ratios. Keep animated child transforms separate from layout-owned positioning.
- Start typography from the earlier plan: titles 44–60, section labels 32–40, body 26–32 reference units. Verify rendered text, including parent scale, at 1280×720. Use scrolling or reflow before shrinking educational text.
- Keep the current two-column activity grid unless the pilot demonstrates a clearer alternative at every supported size. Avoid rebuilding it merely to match an unused earlier four-column proposal.
- Give controls at least a 44×44 rendered-pixel hit area at the smallest target viewport where practical. Expand hit regions without overlapping adjacent controls or drag targets.
- Fit long Malay labels and changed text size by reflowing content. Reserve room for results and errors so they do not cover the question or shift the action unexpectedly.
- Apply a safe-area container to critical screen controls where needed; decorative backgrounds may extend to the edge. Reapply only when screen dimensions or the safe rectangle change.
- Desktop landscape is the baseline. Check 4:3, 16:10, and ultrawide; a portrait/mobile redesign is a separate scope if required by the shipping target.

## 4. Motion specification

These are starting values for the pilot, not a reason to replace existing clips that already work. Use restrained ease-out on entry and shorter exits. Motion must remain understandable on repeated use.

| Event | Proposed treatment | Starting duration |
|---|---|---|
| Hover or keyboard/controller focus | Persistent outline; optional visual scale from 1 to 1.02, without changing the hit region | 100–140 ms |
| Press/release | Visual child compresses to about 0.98 then returns; existing click sound fires once | 60–100 ms each |
| Selected answer/item | Persistent violet outline or fill; at most one small emphasis on change | 120–160 ms |
| Dialog/sidebar open | Fade and 12–20 reference-unit travel; text settles before reading | 160–220 ms |
| Dialog/sidebar close | Reverse toward its origin; disable input as closing begins | 120–160 ms |
| Drag pickup | Small elevation/outline on a visual child; pointer tracking stays immediate | 80–120 ms |
| Accepted drop | Settle to the accepted slot; neutral/violet cue before marking | 100–160 ms |
| Invalid drop | Return to recorded valid origin; short actionable feedback only if needed | 140–200 ms |
| New lab step | Replace instruction and update real progress; brief emphasis on the changed region | 160–220 ms |
| Evaluated correct/wrong | Stable Betul/Salah text and state; optional single small scale emphasis, no repeated flash | 140–200 ms |
| Result panel | Reveal final score and actions together; final value is available immediately | 180–240 ms |
| Scene navigation | Short fade followed by actual loading state if needed | About 120 ms out and 160 ms in |

Never delay an accepted click solely to finish a decorative animation. Replace the fixed navigation wait only after checking its audio and clip dependencies. Prevent duplicate scene loads and recover the controls if loading fails.

Provide `Kurangkan gerakan` through the existing settings/help surface, using a small local preference. Reduced motion removes travel, scaling, pulses, and decorative loops while retaining static focus, labels, and feedback. It must not skip experiment steps, shorten heating/reaction time, disable essential instruction animation, or change the observation being taught. Do not globally set Animator speed to zero or fast-forward lab clips.

## 5. Unity animation integration

### Reuse before replacement

Inventory each controller's state names, parameters, clip paths, animation events, loop settings, and script/UnityEvent callers before modifying it. The animation skill targets 6000.3; use APIs supported by this project's 6000.6.7f1 without changing the Unity version or adding a tween dependency.

- Use Animator controllers for existing authored sequences and meaningful multi-state visual behavior. New controllers should expose typed parameters such as `Highlighted`/`Selected` bools and one-shot triggers where justified; cache parameter hashes.
- Use a small coroutine/value transition for simple fades and position/scale changes where a controller would add complexity. Do not create a second animation owner for the same property.
- Keep existing direct `Animator.Play` lab callers until their state dependencies have been mapped. Migrate a caller and its controller together only where the change improves reliability and can be verified.
- New responsive interaction transitions should not wait for exit time. Preserve exit-time requirements on instructional sequences. Do not blend between scientific observation states if that would show a misleading intermediate result.
- Do not force humanoid rigs, IK, locomotion blend trees, or root motion onto apparatus/UI. Use those mechanisms only if an actual relevant rig is identified.
- Stop or replace an in-flight UI transition from its current value. Reset visual state and pending callbacks on disable, scene exit, and reuse; opening/closing rapidly must not strand invisible input blockers.
- Animate a dedicated visual transform only after checking bindings. Keep drag coordinates, colliders, raycast regions, and layout transforms authoritative. A wrapper or hierarchy change requires rebinding all affected clips and verifying them.

### Lab progression and HUD

Pilot on `2.2` before changing the other five laboratories. Preserve the existing action gates and named steps in `ObjectController`, `bstepsController`, and related scripts.

Introduce one reliable notification when an existing step actually completes. It may come from the authoritative step owner or a small state behavior. Entering a state, exiting because of cancellation, or a decorative clip ending must not falsely complete a step. States that finish and remain parked need explicit completion detection; state exit alone is insufficient. Handle looping clips, transitions, replay, and skip separately.

Have the instruction/progress UI consume this notification once instead of repeatedly assigning labels from `Update`. Verify the existing step-to-progress mapping with each experiment before replacing it. Correct the confirmed Activity 3 slider/text mismatch as part of that migration. These values describe the current lab session; they do not create persisted activity-completion records.

## 6. Input, drag/drop, and modal behavior

- Keep existing mouse input and the current input backend. Do not install or migrate to the Input System solely for this revamp.
- Set initial focus on screen/overlay entry. Provide visible focus independent of answer selection. Use event callbacks for selection changes instead of polling `EventSystem` in every button.
- Test keyboard traversal and controller menu navigation against the configured input axes. Define explicit neighbors only where automatic navigation fails; inactive/disabled controls must be skipped.
- While a modal is open, block underlying pointer, keyboard/controller, and world-object actions. Trap focus inside it and restore the previous valid control on close. Escape/Back dismisses only an allowed overlay; it never submits or discards work automatically.
- Keep confirmations for meaningful loss or exit. Remove navigation-only prompts only after verifying what that navigation resets.
- Route drag completion through an explicit accepted/rejected result from the slot. Merely releasing over an `ItemSlot` does not prove the drop was accepted. Return rejected items to a valid origin; preserve occupancy and source/target bookkeeping.
- During a drag, show only interaction-compatible destinations, not correct-answer hints. Keep existing uniqueness, grading, and replay rules.
- Add select-item then select-slot as a keyboard/click alternative for answer trays, routed through the same validation path as drag/drop. Verify it on quizzes and plate/pyramid separately.
- For lab apparatus, inspect existing selection/rotation controls before adding a focusable equivalent for essential actions. Do not claim full controller playability based on menu navigation alone.

## 7. Colour meaning and feedback

`Assets/UI/Theme/BioPalette.cs` remains the colour source of truth:

- Navy/purple surfaces organize layers; paper surfaces support long reading and forms.
- Blue denotes the primary action; violet denotes an ungraded selection.
- Green and red denote evaluated success/error, always accompanied by words or a recognizable non-colour indicator.
- Amber denotes a real warning or incomplete requirement; cyan denotes neutral guidance.
- Topic stripes identify subjects and never imply success, failure, or availability.

Use existing on-paper versus on-dark tokens according to the actual surface. Reserve space for the existing quiz badge and check it on every question layout; avoid a second competing feedback panel. Review feedback reset on retry and on any allowed post-check answer edit so a stale badge cannot contradict the current answer.

Check contrast in rendered context, including tinted gradient sprites and text over lab art: target 4.5:1 for ordinary text and 3:1 for large text and essential control boundaries. Review grayscale plus protanopia, deuteranopia, and tritanopia simulations. Words, focus outlines, and selection markers must remain useful with colour removed.

Inspect the red anatomy callout lines in `1.1` and `1.6`: preserve scientific colour coding if it has meaning; otherwise use a neutral readable callout colour so it is not confused with error feedback. Do not recolour reagents, food, apparatus, or reaction outcomes as interface state.

## 8. Implementation order and likely files

1. **Baseline and inventory:** obtain complete Game View captures, including overlay UI and runtime result states. Record controller bindings and scene coverage. Check unsaved editor work before scene changes. Reuse `BioNutriUIReview` for edit-time previews, while clearly distinguishing previews from runtime evidence.
2. **Shared interaction pilot:** refine MainMenuAktiviti and one dialog. Establish focus, press feedback, interrupted transitions, reduced motion, and input blocking using existing assets.
3. **Lab pilot:** implement the `2.2` HUD arrangement and verified step notifications. Play through the full sequence before copying the approach.
4. **Assessment pilots:** refine worksheet `5.3`, mixed-question quiz `5.4`, and the relevant Activity 8 plate/pyramid scenes. Verify submission, accepted/rejected drops, retry, and badge placement.
5. **Family rollout:** apply proven rules across Activities 2–7, then inspect the distinct Activity 1/8 flows and remaining start/login/objective/review/chat screens. Track every scene rather than assuming template equivalence.
6. **Acceptance:** finish cross-resolution/input checks, meaningful regression tests, runtime walkthroughs, and representative captures. Report remaining limitations separately from delivered work.

Likely existing files: `ButtonReactionController.cs`, `SceneController.cs`, `ProgressController.cs`, relevant lab controllers, `DragScript.cs`, `ItemSlot.cs`, `TouchController.cs`, `KuizController.cs`, palette consumers, score loaders, affected scene/prefab/controller/clip assets, and `BioNutriUIReview.cs` if capture improvements are required.

Add small reusable helpers under `Assets/UI` only where the pilots establish repetition: UI motion/preferences, modal focus/input ownership, or lab-step notification. Preserve MonoBehaviour identities, `.meta` GUIDs, public UnityEvent entry points, and serialized references. Avoid a new global framework, hierarchy rewrite, duplicate palette, or wholesale lab state-machine replacement.

## 9. Deferred dependency

Persisted locked/in-progress/completed activity states remain deferred until a trustworthy per-user progress contract is available. Do not infer them from a fetched numeric score, treat network failure as zero, or introduce a new local completion system implicitly. This dependency does not block interface work or accurate progress within an active lab session. Backend deployment and hosted login restoration are separate work.

## 10. Verification and completion criteria

- Capture representative families at 1920×1080, 1366×768, 1280×720, 1920×1200, 1024×768, and 2560×1080. Walk through every scene at the baseline and check family-specific edge cases at alternate sizes.
- Verify long Malay text, scrolling, final worksheet rows, badges, expanded chat, dialogs, safe-area insets, and enlarged text. Controls remain reachable without overlapping apparatus or mandatory content.
- Exercise mouse, keyboard, configured controller menu input, and answer pickup/place alternatives. Check modal focus trapping, restoration, world-input blocking, rapid navigation, and interrupted transitions.
- Run each laboratory from start to result, including replay and available skip/pause paths. Confirm observations, audio/events, gating, and displayed progress stay correct; inspect live Animator states and parameters.
- Exercise every question type, valid/rejected/occupied-slot drops, duplicate submission, changed answers where allowed, retry, and plate/pyramid completion. Unmarked selection must never imply correctness.
- Test reduced motion during open/close/drag/result states and confirm essential experiment sequencing is unchanged.
- Run existing `ScoringAndPlateTests` and the applicable offline-chat tests after touching shared scene/UI behavior. Add focused tests for new modal ownership, drop acceptance, completion notifications, and reset behavior; do not test fixed coordinates merely to restate the layout.
- Check modified assets for missing scripts, broken animation bindings, lost UnityEvents, duplicate EventSystems, and new console errors. Run the relevant target build before release; identify the actual target rather than guessing it from old exports.
- Use mocked score/chat states for loading, authentication failure, timeout, unavailable data, and genuine zero. Hosted success paths require a working service and cannot be claimed from mocks.

Completion means every scene is accounted for, relevant actions have coherent feedback, learning content and scientific behavior are preserved, and the above checks have recorded outcomes. Deliver changed assets, representative before/after captures, and a short verification report. If editor/runtime access is unavailable, identify precisely which checks remain unverified.

## 11. Technical references

- [Unity animation parameters](https://docs.unity3d.com/6000.0/Documentation/Manual/AnimationParameters.html): parameter types and script-driven state-machine control.
- [Unity StateMachineBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/StateMachineBehaviour.html): callbacks available for state lifecycle integration; application logic still determines valid completion.

The references describe Unity 6 fundamentals. Implementation must be compiled and verified against the project's installed 6000.6.7f1 editor. No runtime or visual acceptance is claimed by this planning document.
