# Animation and UI implementation report

Implemented 29–30 October 2026 from [the approved plan](../../ANIMATION_UI_IMPLEMENTATION_PLAN.md). Changes are local and uncommitted.

## Delivered

- Installed shared interaction behavior across all **49 scenes**: **2,678 controls**, **669 existing dialog instances**, and **48 reduced-motion settings toggles**. These counts include inactive pages and dialogs, not just controls visible at once.
- Added event-driven focus outlines and restrained hover/press motion where existing animation bindings permit it. Existing button Animator clips remain in use; button focus no longer needs per-frame polling.
- Added modal input ownership, focus containment/restoration, reviewed Cancel actions, explicit canvas ordering, and world-input blocking in both laboratory selection controllers and apparatus dragging. Opening/closing remains driven by the existing Animator states and button events.
- Added **Kurangkan gerakan** to the settings panels. It removes the new decorative movement, suppresses audited ambient artwork animation, and shortens UI transitions while preserving scientific experiment timing and apparatus animation. Test changes to the preference were restored.
- Replaced the fixed scene-navigation wait with a short asynchronous transition, duplicate-load protection, and a loading label when a load takes longer.
- Added explicit drop acceptance, occupied-slot rejection, source-slot cleanup, correct placement across different parents/anchors, animated invalid-drop return, and click/keyboard pickup-and-place through the same slot logic. Rapid pickup and hiding a page during return preserve the valid origin and raycast state.
- Added a consistent quiz question/result header outside the question content. All question types use the existing answer array for Betul/Salah feedback. Editing an answer clears stale result styling; repeated scoring remains idempotent.
- Replaced progress polling with Animator state completion notifications in all six laboratories. Combined Activity 2 states now report their completed range correctly. Activity 3's 75% mismatch is fixed; Activity 6/7 endpoints now match actual final steps 26/28 instead of outdated or nonexistent milestones. The progress label also shows the current step.
- Refined the activity menu surface, laboratory progress HUD, worksheet surfaces and input ink, and score-review labels. Settings use readable paper surfaces, Malay labels, blue audio controls, and light text on action buttons. Anatomical leader lines use the guidance colour while organ artwork remains intact.
- Score review distinguishes loading/unavailable data from a genuine zero; missing authentication or a failed response no longer manufactures `0/10`.

Existing art, fonts, teaching content, scoring weights, scientific clips, scene names, and public button entry points remain in use. No tween dependency or input-backend migration was added.

## Verification

- **22 Unity EditMode tests passed**, including existing scoring/plate/offline-chat tests and new progress, modal, safe-area, drag, and persisted prefab-instance checks. See [AnimationUIBehaviourTests.cs](../../Assets/Tests/Editor/AnimationUIBehaviourTests.cs).
- All 49 scenes were audited: **zero missing scripts** and **zero invalid modal screen roots**. [Scene audit](scene-audit.tsv).
- A comparison against the starting commit confirms every existing scene object ID and persistent event target/method/argument field was preserved. [Asset preservation results](asset-preservation.json).
- All **15 tested palette-token contrast pairs** meet their specified 4.5:1 text or 3:1 control thresholds. These are token checks, not a claim that every tinted sprite/text combination has been measured. [Contrast results](token-contrast.json).
- Reviewed 49 edit-time scene previews and representative menu, quiz, worksheet, plate, and login layouts at 1920×1080, 1366×768, 1280×720, 1920×1200, 1024×768, and 2560×1080. Temporary full-scene/resolution captures are under ignored `Temp/AnimationUIReview`.
- Live Play Mode checks verified settings pointer raycasts, initial focus, modal input locking/restoration, the reduced-motion toggle, quiz submission feedback and edit reset, rapid/interrupted drag return, and the actual Activity 2 `step13-14` completion callback (50% label and slider).
- Runtime captures used `ScreenCapture` to include overlay UI. Laboratory edit-time previews use a temporary camera and do not establish runtime camera/framing acceptance.
- Reviewed the quiz feedback under grayscale and approximate protanopia/deuteranopia/tritanopia simulation. Words remain available when the feedback hues change. The simulation uses the published [Machado et al. colour-vision model](https://pubmed.ncbi.nlm.nih.gov/19834201/) and is an aid to review, not an accessibility certification.
- Changed C#/Markdown/assembly-definition files pass whitespace checks. Unity-generated YAML retains Unity's normal empty-field formatting.
- **Windows 64-bit build succeeded with zero errors and zero warnings** after a clean script import and incremental verification. Output: `Builds/AnimationUIReview/BioNutri-MM.exe` with its adjacent data/runtime files (523.88 MB total). [Build results](build-results.json). The build is local and ignored by Git.

## Captures

- [Activity menu before](activities-before.png) and [after](activities-after.png).
- [Quiz before](quiz-before.png), [question header](quiz-after.png), and [runtime feedback](quiz-feedback-after.png).
- [Runtime settings](settings-runtime-after.png) and [settings layout](settings-after.png).
- [Worksheet](worksheet-after.png) and [score-review loading state](score-review-after.png).
- [Laboratory dialog](lab-dialog-after.png) and [laboratory HUD](lab-hud-after.png).
- [Colour-vision review](quiz-feedback-after-colour-review.png).

## Remaining validation and dependencies

The runtime checks were scripted smoke checks, not full manual playthroughs of every lesson and experiment. Full apparatus interactions, every hidden explanation page, long worksheet scrolling, replay/skip paths, and successful online score/chat flows still need release QA. Controller hardware and portrait/mobile layouts were not tested; laboratory apparatus retains its existing mouse and rotation controls.

Locked/in-progress/completed activity badges remain deferred until trustworthy per-user progress data is available. No local completion system, hosted login restoration, backend deployment, or publication was introduced.

`Assets/Editor/BioAnimationUIInstaller.cs` provides the repeatable scene installation. It preserves prefab overrides explicitly and checks inactive nested canvases against their actual outer canvas. It refuses to overwrite a loaded scene with unsaved changes. The existing `BioNutriUIReview.Capture` now also supports an explicit overlay path for inspecting inactive dialogs without changing the user's active scene.
