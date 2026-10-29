# BioNutri-MM gameplay teaser and showcase plan

Status: **Proposed only — no production executed.** This pass inspected existing source, documentation, assets, and the requested skills. No gameplay recording, audio generation, dependency installation, video code, or rendering was performed.

## 1. Creative brief

Create a cinematic, gameplay-led showcase that makes BioNutri-MM feel inviting, interactive, and worth exploring. The viewer should understand that this is a virtual nutrition/science learning game within the opening seconds, then see genuine actions produce understandable results.

**Recommended direction:** curious, hands-on, uplifting. Use the real 3D laboratory as the visual lead, alternate interaction with observation, and close on a successful learning interaction followed by the existing brand.

| Decision | Proposed default |
|---|---|
| Audience | Students, educators, and people discovering the project |
| Purpose | Gameplay teaser and project showcase; suitable for a presentation or landscape video upload |
| Duration | 60 seconds, with readable pacing rather than a rapid feature list |
| Master | 1920×1080, 60 fps, H.264 MP4 with AAC stereo |
| Capture | Prefer native 3840×2160 at 60 fps for reframing if the smoke test supports it; otherwise native 1080p60 |
| Language | Short Malay captions matching the game; no voiceover by default |
| Music | Original instrumental at a proposed 96 BPM, supported by selected gameplay sounds |
| Closing copy | BioNutri-MM · “Belajar. Eksperimen. Fahami.” |
| CTA | “Terokai BioNutri-MM”; no invented release date, store link, or availability claim |

These are proposed production choices, not preferences already confirmed by the user. Portrait/social cutdowns and an English-caption version are optional later adaptations.

## 2. Production mode and use of the three skills

The video-shotcraft skill provides three modes:

1. **Ink Press template:** useful for a close recreation of its existing page/card presentation. Its structure would require substantial adaptation for a Unity game with moving apparatus and scientific observations.
2. **Autonomous custom creation — recommended:** derive the film from this game's actual footage, colours, artwork, and mechanics. After approval of this plan, make routine creative/engineering decisions and carry production through to a reviewable preview.
3. **Guided custom creation:** use the same gameplay direction, with separate reviews of the brief, visual direction, shot mapping, and storyboard. This suits a user who wants to choose each creative stage.

No mode is selected by writing this document. Approval of the recommended plan would select option 2; another mode can be specified during review. Shot examples can be browsed in the [video-shotcraft gallery](https://vincentwei1021.github.io/video-shotcraft/library.html).

| Skill | Responsibility in this project |
|---|---|
| video-shotcraft | Shot design, controlled camera language, one signature brand finish, beat/SFX alignment, styleframes, and independent final review |
| remotion-marketing-video | React/Remotion scene graph, frame-driven graphics, footage composition, Studio preview, revisions, and export QA |
| game-trailer | Authentic current-game footage, readable mechanics, whole-screen context, deliberate pacing, gameplay audio, and ending on a meaningful payoff |

The game-trailer browser virtual-clock/CSS pipeline will be adapted to **Unity capture**. A browser dev server and wrestling crowd engine are not requirements for this game. Remotion is the compositor; it will not recreate the laboratory or invent gameplay UI.

## 3. Existing material and reuse

Read-only inspection found:

- An existing completed 60-second, 1080p30 trailer under `Deliverables/Trailer/`, documented in its [README](Deliverables/Trailer/README.md).
- An editor-only recording helper at `Assets/Trailer/TrailerDirector.cs`, using 1920×1080 frame capture and `Time.captureFramerate = 30`.
- An existing FFmpeg edit/original-score recipe at `Tools/Trailer/export.mjs`. Its synthesized music uses a 0.625-second beat, corresponding to 96 BPM.
- Current UI/animation implementation evidence under `Documentation/AnimationUIReview/`, including 22 passing tests and a successful Windows build. These establish the project baseline, not trailer footage acceptance.
- Existing logo/science artwork, `Purple Smile.ttf`, Arial and Liberation Sans files, and the semantic palette in `Assets/UI/Theme/BioPalette.cs`.

The old trailer is a reference/re-edit source, not the new master. Its README describes staged authored animations, music without gameplay audio, an offline-chat segment, and some capture limitations. It predates the latest UI pass. Its full video was not rewatched during this planning pass; review it before deciding which, if any, old takes can be reused.

Preserve `Deliverables/Trailer/`, the old edit recipe, and existing public recording entry points. Recapture the important moving shots from the updated project. Use the recent UI screenshots to plan compositions, not as substitutes for moving gameplay.

## 4. Visual and motion direction

### Brand treatment

- Reuse navy `#14103F`, raised purple `#221C5C`, paper `#F6F1E4`, light text `#F4F2FF`, action blue `#17508C`, and guidance cyan `#5CC8FF`.
- Keep violet selection, green success, and red error tied to actual game states. Decorative trailer transitions must not imply grading.
- Preserve the original logo's proportions, science/space illustration style, mascot, and existing font character. Identify the actual title/body font roles from the assets before producing styleframes.
- Use restrained light, depth, and camera movement. Keep reaction colours and educational diagrams faithful to the game; avoid a film grade that changes scientific observations.
- Overlay captions should be short, usually one line, and appear only when they add meaning. Establish one safe caption region per take that does not cover apparatus, instructions, answer choices, or feedback.

### Camera and editing language

- Keep at least **30 seconds of actual laboratory footage** in the proposed cut. Most of the remaining film also shows real interactive game screens.
- Open with moving gameplay immediately. Integrate the product name briefly over footage rather than starting with a long blank logo animation.
- Show an establishing/full-screen view before a detail crop. Keep input, destination, and response visible together during important actions.
- Build a clear mini-sequence: select equipment → manipulate/place it → observe the result. Do not replace that sequence with unrelated fast cuts.
- Use native in-engine camera movement for genuine 3D lab beauty shots. Use small editorial push-ins for emphasis, with full-screen holds for reading and interaction.
- Use 2.5D framing sparingly on interface showcase moments. Readable labels take priority over perspective; no heavy tilt on questions or worksheets.
- Use clean action cuts, short dissolves where helpful, and at most two broad accent moments. No repeated flashes, camera shake, or decorative particle bursts over experiments.
- Keep most individual shots around 2–5 seconds; longer story blocks may contain two related shots. Reserve at least one second of settled reading time for key information and the final brand.

### Shotcraft recipe mapping

Use one candidate signature recipe rather than applying a card effect to every feature:

| Use | Card/style | Adaptation |
|---|---|---|
| Closing brand, 55–60 s | `logo-shrink-wordmark-lockup` | Preserve the tuned contraction, braking, wordmark entrance, and settled hold. Replace Shotcraft branding/materials with the existing BioNutri-MM logo and palette. Keep the logo itself upright and undistorted. |
| Moving gameplay | Direct Unity footage, optionally framed using the reusable `ClipCard`/camera components | Preserve the real frame and action. Do not loop a reaction or placement to fabricate continuous progress. |
| Menu/detail presentation | Restrained camera framing derived from real captures | Show the screen context and a visible choice change; no fabricated cards or replacement UI. |

The closing card and its exact demo were inspected locally at `references/shots/outro/logo-shrink-wordmark-lockup.md` and `demos/outro/logo-shrink-wordmark-lockup/LogoShrinkWordmarkLockup.tsx` in the video-shotcraft skill. Its 132-frame/30-fps design lasts 4.4 seconds: preserve those seconds when adapting to 60 fps (264 frames), then use the remaining 36 frames of the five-second outro for extra hold. Verify that the finished brand/tagline has at least one second of settled visibility.

`spotlight-hero-card` was considered but is not a default choice: its complete tuned arc needs approximately 5.7 seconds, and the stronger priority here is a readable gameplay sequence. Final card adaptation must be checked against its source demo, not rewritten from the name alone.

## 5. Proposed 60-second storyboard

This is the concrete shot list for review. Captions are draft microcopy. Every reaction/interaction remains subject to a successful current-build capture smoke test.

| Time / frames at 60 fps | Picture and real action | Camera/edit and sound | Draft caption |
|---|---|---|---|
| 0–5 s / 0–299 | Strongest functioning 3D lab: an apparatus action begins immediately, with a short bench reveal and integrated product identification | Gentle native tracking/push; room tone, a real click or apparatus cue; music enters with curiosity | “Terokai nutrisi dalam makmal maya.” |
| 5–10 s / 300–599 | Current eight-activity menu; one clear activity selection leads into its laboratory | Whole screen first; restrained push toward the selected activity; one UI cue | “8 aktiviti. Pelbagai penemuan.” |
| 10–20 s / 600–1199 | Activity 2 (`2.2`): select a reagent/cylinder, perform one meaningful transfer, and show the visible response | A connected 10-second mini-sequence, primarily full-screen; cut on the real transfer action | “Kendalikan eksperimen sendiri.” |
| 20–27.5 s / 1200–1649 | The clearest verified iodine/Benedict observation from that experiment | Establish the relevant tubes, then hold the observable change; reduce music briefly to feature the action | “Perhati perubahan. Fahami tindak balas.” |
| 27.5–35 s / 1650–2099 | Visually distinct second experiment: prefer Activity 6 (`6.2`) vitamin C/DCPIP if its syringe/observation sequence reads clearly; use Activity 5 (`5.2`) food-energy simulation as fallback | One second mechanism and visible outcome; no unexplained equipment montage | “Bandingkan. Buat kesimpulan.” |
| 35–40 s / 2100–2399 | Activity 1 (`1.1`): one deliberate digestive-system view/selection with readable labels | Brief spatial change and settled view; leave diagrams and callouts unobstructed | “Kenali sistem pencernaan.” |
| 40–47.5 s / 2400–2849 | Activity 8 (`8.2`): demonstrate food pickup/placement in the healthy plate using the normal interaction path | Keep item and destination together; one or more genuine placements with time to register them | “Susun pinggan sihat anda.” |
| 47.5–55 s / 2850–3299 | A readable quiz question, a real answer interaction, and the resulting Betul/Salah feedback. Hold the positive learning payoff before leaving | Match the visible action to its sound; hold feedback rather than finishing with unrelated sizzle | “Uji kefahaman anda.” |
| 55–60 s / 3300–3599 | Existing logo/title locks into a clean brand end frame | Adapted brand contraction/lockup, then a calm hold and musical resolution | “BioNutri-MM” / “Belajar. Eksperimen. Fahami.” |

The opening and three laboratory blocks total **30 seconds**. All transitions are included inside these intervals. No added transition time may extend the master beyond 3,600 frames.

No live AI, online scores, locked/completed activity badges, or authentication screens are required in the main cut. If chat is later requested, use the existing explicitly labelled offline demo and reallocate enough reading time; never present its scripted response as a live AI service. Do not show a perfect quiz total after recording only one answer. A total may appear only if it was genuinely obtained through the captured/tested answer flow.

## 6. Unity capture plan after approval

1. Check the live editor, unsaved scene state, console, source version, capture tools, encoder availability, available disk space, and current recording helper. Do not start from old takes merely because they already exist.
2. Review the old trailer for useful pacing and capture lessons. Preserve the old deliverables and production sources.
3. Define named takes and per-take manifests containing scene, resolution, fps, source frames, action/result markers, sound cues, capture profile, and any staged setup or omitted waiting time.
4. Prefer extending the existing recorder with a separate showcase profile and parameterized fps/output rather than copying its entire pipeline. Keep old recording entry points functional. Add a small capture-only adapter if the old director's coupling makes that necessary.
5. Smoke-test one short 1080p60 take containing a pointer action, overlay UI, modal transition, apparatus movement, and reaction. Confirm captions, safe-area behavior, cursor and UI are captured correctly.
6. Capture the gameplay output at the end of a rendered frame, including overlay canvases. The old director explicitly renders a camera; do not assume that path includes overlay UI. Use a verified full-frame capture path, or reversible capture-only canvas/camera routing, before accepting a take.
7. Use frame-indexed recording actions and fixed capture timing. `Time.captureFramerate` is a foundation, not a guarantee that every physics step, unscaled UI timer, asynchronous load, or audio DSP clock follows it. Verify these in the smoke test and record a take only after its action/result markers are reproducible.
8. Drive real button, drag/drop, input, and experiment-controller paths. A staged camera/starting setup is allowed and logged. Jumping directly between Animator states is acceptable for labelled authored-animation inserts, but cannot stand in for proof of a mechanic working.
9. Retain educational instructions where they explain the action. Suppress unrelated loading/account/chat/score traffic in the recording-only setup; use no real student account or saved online performance.
10. Capture usable handles before/after actions. Keep real interactions at native speed. Omit long waits with a clear cut and, where needed, “Masa menunggu dipendekkan”; do not disguise accelerated reactions as real-time behavior.
11. Benchmark five seconds before deciding on 4K. Raw 4K frame sequences can consume tens of GB. Keep raw media outside runtime Assets, estimate the footprint, and archive selected takes separately from Unity Temp when needed for reproducibility.
12. Restore the original scene, capture timing, cameras, UI visibility, audio settings, and any local preferences/session/demo settings in both success and failure paths. Never save recording-only changes into normal scenes/prefabs.

Existing outline/mesh-readability warnings mentioned in the previous trailer report and current modal/capture behavior must be rechecked. Replace a problematic take with another genuine working action instead of hiding broken gameplay in the edit.

## 7. Remotion implementation and timing

Create a separate production workspace at `Tools/TrailerShowcase/`. No Remotion workspace was found in the existing trailer pipeline. Select compatible, version-aligned Remotion/React packages and pin them during implementation; do not assume the skill demos' historical version is the required version.

Proposed layout:

```text
Tools/TrailerShowcase/
  src/index.ts
  src/Showcase.tsx
  src/theme.ts
  src/data/timeline.ts
  src/components/                 footage, captions, brand finish
  src/workbench.ts                editable shot/transition/text/audio tracks
  public/brand/                   existing logo and approved font assets
  public/takes/                   selected current-build footage
  public/audio/                   approved music and SFX
  scripts/                        validation, encoding and QA helpers
Temp/TrailerShowcase/              raw captures, smoke tests and temporary QA
Deliverables/TrailerShowcase/       approved exports and reproduction report
```

- One scene/beat data model owns `id`, `startFrame`, `durationInFrames`, `narrativeGoal`, `visual`, `motion`, `audio`, and `assetRefs`. Keep source in/out points, capture markers and caption/transition timing alongside it.
- At 96 BPM and 60 fps, one beat is 37.5 frames. Use `beatF(n) = round(n × 60 × 60 / 96)` with absolute beat numbers; never repeatedly add a rounded beat. Ninety-six beats equal the proposed 60 seconds. The storyboard boundaries fall on whole four-beat bars.
- Use a shared frame-driven timeline for both exports. Drive graphics through Remotion frame APIs; no wall-clock timers, CSS keyframes/transitions, or unseeded randomness.
- Load real footage through the appropriate Remotion media component. Use project-local assets. Wait for fonts/media before rendering; avoid magnifying low-resolution text or pretending a 30-fps take is native 60 fps.
- Do not seamlessly loop an experiment or reverse a placement. If a take is too short, recapture or deliberately hold a meaningful result.
- Keep `src/workbench.ts` current so the final edit can be opened in the Shotcraft workbench after delivery. Workbench startup is a delivery step, not part of this planning pass.

## 8. Audio and the “vibe”

Use an original melodic/electronic score with curiosity in the opening, clearer pulse during hands-on actions, a short breathing space at the first observation, and a warm resolution under the final brand. Start from the existing original-score approach if useful, but write an arrangement for this cut rather than reusing a flat minute-long loop unchanged.

- Proposed 96 BPM provides a common grid for picture, typography and sound. If the user later supplies a track, analyse its actual tempo/phase/transients before locking the edit; do not force it onto the proposed grid.
- Preserve selected real clicks, placement cues, apparatus/reaction sounds and room tone. Capture/log them against frame markers or reconstruct them from the game's actual clips; avoid duplicated sounds when mixing footage audio with logged cues.
- Audio recorded in wall time is not automatically synchronized with slow frame-by-frame capture. Verify the time mapping or rebuild the event layer offline.
- Use a small set of subtle transition/brand sounds. No arena crowd, wrestling impacts, or unrelated combat sound design. Do not copy the Shotcraft audio directory wholesale.
- Check individual asset provenance. The Shotcraft attribution registry explicitly marks some legacy samples as unverified; exclude those unless their rights can be established. Prefer original synthesis and verified game/SFX sources.
- Target approximately −14 LUFS integrated and no more than −1 dBTP, with 48 kHz stereo audio. Duck music around important gameplay sounds; avoid masking necessary spoken game instructions.
- Render **two masters from the same timeline** using a `bgm` input prop: music + gameplay/SFX, and no music with gameplay/SFX retained. “No BGM” must not accidentally mute the whole soundtrack.

## 9. Production and approval sequence

1. **Current step:** review this implementation MD and its proposed mode, storyboard, duration, language and output locations. Stop here; no capture or video implementation is authorized by writing it.
2. After plan/mode approval, inspect the old movie and current runtime takes, create two or three representative styleframes, and record the final brand/motion spec. For autonomous mode, resolve routine refinements without repeated creative approvals.
3. Capture short smoke takes, then only the final sources required by the storyboard. Build the Remotion composition, still checks and short motion/sound drafts.
4. Run Remotion Studio and inspect the whole composition, key frames, media loading and audio. Use the T3 collaborative preview when available. Present a concrete preview with its composition name, known limitations and proposed final output paths.
5. **Before complete final export:** obtain approval of the preview and final paths. The [remotion-marketing-video skill](C:/Users/Melon/.agents/skills/remotion-marketing-video/SKILL.md) explicitly says: “Do not render the complete final video until the user approves the preview and confirms the output path.” Still frames and short QA ranges are allowed earlier. This is a final-export review, not permission to begin planning again.
6. Render the approved BGM/no-BGM versions. Have one fresh-context reviewer independently inspect the final files, keyframes, brief, storyboard, chosen shot recipe/demo, audio and technical checks. Fix findings before delivery; use a focused preview if a correction changes the approved creative result materially.
7. Deliver the movies, thumbnail, timeline/project sources, asset provenance and QA report. Open the Shotcraft workbench after delivery so the user can adjust tracks if desired. No upload, publication, commit or push is included automatically.

## 10. Acceptance and deliverables

Acceptance requires:

- A 60-second/3,600-frame master at the approved resolution and native 60-fps timeline; probe actual dimensions, codecs, frame rate, duration, audio streams and file size, accounting for container/audio padding.
- Real moving current-build footage, at least 30 seconds of lab content, one understandable action-to-result sequence, and a clear learning payoff before the brand ending.
- Readable captions, actual UI/feedback, and at least one second of settled final branding. Check full size and a small playback window.
- Whole-film playback plus contact sheets and frames around every cut; no black/unintended frozen frames, missing textures, obstructing dialogs, editor chrome, notifications, account data or stale screenshots.
- Review motion on real-time playback, not only stills. Avoid duplicate/drop-frame artifacts and verify beat/important SFX alignment to within roughly three output frames.
- Gameplay correctness and truthful disclosures: no fake online services, fabricated marks, hidden slow/fast playback, or altered scientific outcomes.
- Measured audio loudness/peaks, intelligible cues, a clean ending, and a no-BGM version with SFX intact.
- Independent final review with time/frame references, recorded fixes and explicit remaining limitations.

Proposed final outputs, subject to preview/path approval:

- `Deliverables/TrailerShowcase/BioNutri-MM_Gameplay_Showcase_60s.mp4`
- `Deliverables/TrailerShowcase/BioNutri-MM_Gameplay_Showcase_60s_NoBGM.mp4`
- `Deliverables/TrailerShowcase/BioNutri-MM_Showcase_Preview_720p.mp4` (a delivery encode after final approval; earlier QA uses stills/short ranges/Studio)
- `Deliverables/TrailerShowcase/thumbnail.jpg`
- `Deliverables/TrailerShowcase/README.md`, shot/timing manifest, audio provenance and final QA report.

Keep large raw media and rendered movies out of source control; preserve reproducible code/manifests and the existing trailer. No external publishing is part of this task.

## 11. Technical references

- [Unity captureFramerate](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Time-captureFramerate.html): fixed capture-time behavior, to be verified against this project's 6000.6.7f1 editor and capture path.
- [Remotion frame timing](https://www.remotion.dev/docs/use-current-frame): deterministic frame-driven composition.
- [Remotion OffthreadVideo](https://www.remotion.dev/docs/offthreadvideo): real source-video integration and media handling.

The browser-game capture benchmarks in the game-trailer skill do not establish render times for this Unity project. Measure smoke-take capture and a short Remotion render before estimating the full production cost.
