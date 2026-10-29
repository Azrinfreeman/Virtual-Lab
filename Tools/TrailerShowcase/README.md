# BioNutri-MM gameplay showcase

60 seconds / 1920×1080 / native60fps / Malay / no VO. This is a project showcase, combining labelled authored experiment animations with actual menu, plate and quiz interaction paths.

## Preview

`npm ci`, then `npm run dev -- --port=3100`. Composition: **BioNutriShowcase**. The `bgm` prop switches music off while retaining SFX. Full final exports require preview approval, as specified in the approved implementation plan.

The source timeline is `src/data/timeline.ts`; it drives the composition, sounds and Shotcraft workbench manifest. All nine scenes fill exactly3600 frames. No fake30→60fps conversion, action looping, reversing, game UI recreation, online-account footage or perfect-score fabrication.

## Capture and reproduction

`Assets/Trailer/ShowcaseCapture.cs` is an editor-only, temporary rig. Enter Play Mode and call `ShowcaseCapture.Begin(scene,id,seconds,profile)` through the Unity editor tools. Set Game View to1920×1080. Profiles: overview/menu/transfer/observation/vitamin/anatomy/plate/quiz/smoke. It does not modify saved scenes or prefabs. Completion manifests accompany each take in `docs/`.

The end-of-frame screenshot coroutine stalled when the Game View was obscured. The smoke-verified fallback renders the camera with reversible overlay canvas routing, capturing HUD/modal/instructions. Laboratory inserts hide only the dim backdrop, retaining the instruction text. Their starting states are staged and disclosed. Plate and quiz use the real EventSystem/controller paths and log actual outcomes.

Encode complete takes: `node scripts/encode-takes.mjs overview menu transfer observation vitamin anatomy plate quiz`. Sources: `../../Temp/TrailerShowcase/<id>/%05d.jpg`. Selected60fps MP4s go into `public/takes/`. Raw and encoded video, generated WAVs, node_modules and render outputs stay out of git. Archive selected media separately if clearing Unity Temp.

Audio reproduction: Python/numpy (`python scripts/score.py`), then FFmpeg `loudnorm=I=-14.5:TP=-1.5:LRA=9` on `public/audio/score-raw.wav` to create `score.wav` at48kHz. Music and closing sounds are original deterministic synthesis, not licensed third-party tracks. Actual project click sound source: `Assets/sounds/click_confirm.mp3`. Treat project-provided artwork/fonts/audio under the project's own distribution rights; no new third-party stock audio is included.

`python scripts/prepare-brand.py` reproduces the adapted exact closing card from the installed Shotcraft skill. Its 4.4s arc and6% brake are retained inside the5s ending. `docs/shotcraft-card.json` records the gallery variant; `docs/DESIGN_SPEC.md` records creative decisions and capture adaptations. Existing old trailer sources/deliverables are preserved.

## Verification and eventual final exports

`npm run lint`; per-shot Remotion stills; short draft motion/audio ranges; every take manifest + contact sheet; real plate acceptance and quiz feedback; font/media loads in Studio; frame/timing/loudness validation. Pending: approved full exports, full-file technical checks and independent final review.

Proposed destinations after approval:

- `../../Deliverables/TrailerShowcase/BioNutri-MM_Gameplay_Showcase_60s.mp4`
- `../../Deliverables/TrailerShowcase/BioNutri-MM_Gameplay_Showcase_60s_NoBGM.mp4`

Use the same composition; pass `--props=props-nobgm.json` for the second version. H.264/AAC48k stereo,60fps, full decode/ffprobe after render. Open Shotcraft workbench only after final delivery, following the installed skill instructions.

API references checked during implementation: [media Video](https://www.remotion.dev/docs/media/video), [media Audio](https://www.remotion.dev/docs/media/audio), [Remotion stills](https://www.remotion.dev/docs/still).
