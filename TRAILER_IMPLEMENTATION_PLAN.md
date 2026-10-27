# BioNutri-MM — 60-second gameplay trailer plan

Status: Implemented after approval. The offline demo, editor-only recorder, edit recipe, and trailer deliverables are documented in `Deliverables/Trailer/README.md`. The following sections retain the original production plan.

## 1. Intended result

Produce a polished, exactly 60-second gameplay trailer centred on the actual 3D virtual laboratory. Show equipment interaction, experimental observations, learning activities, and the chatbot demonstration. Preserve the game's existing science theme, logo, artwork, fonts, and colour palette in both footage and titles.

Default delivery: landscape 1920×1080, 30 fps, MP4 with H.264 video and AAC audio. The final video contains 1,800 frames. Use Malay captions to match the game, with no mandatory voiceover. Capture real moving gameplay; do not build the trailer from static editor screenshots or generated laboratory imagery.

## 2. Exact running order

| Time | Duration | Footage and action | Suggested caption |
|---|---:|---|---|
| 00:00–00:04 | 4 s | Open immediately on the strongest functioning 3D lab view; a gentle camera move reveals the bench and apparatus. Brief BioNutri-MM branding over footage. | “Terokai sains melalui pengalaman” |
| 00:04–00:09 | 5 s | Show the improved activity menu and select an experiment. Keep cursor movement deliberate and readable. | “8 aktiviti pembelajaran interaktif” |
| 00:09–00:20 | 11 s | Carbohydrate lab: select and drag a reagent/measuring cylinder, transfer into a test tube, show the instruction and the resulting animation. | “Kendalikan eksperimen dalam makmal 3D” |
| 00:20–00:29 | 9 s | Close view of iodine/Benedict observations or the clearest verified reaction. Cut from action to the visible result. | “Perhati perubahan. Fahami tindak balas.” |
| 00:29–00:36 | 7 s | A second visually distinct experiment: burning a food sample to investigate energy, or DCPIP decolourisation if its runtime sequence records more clearly. | “Daripada nutrien kepada penemuan” |
| 00:36–00:43 | 7 s | Show one digestive-system interaction, then a Healthy Plate food placement. Use actual input and feedback. | “Kenali tubuh. Amalkan pemakanan sihat.” |
| 00:43–00:49 | 6 s | Open chat, enter a short relevant question, and display the offline demonstration reply. Keep the demo label visible. | “Bantuan pembelajaran — demo luar talian” |
| 00:49–00:55 | 6 s | Answer a short quiz or complete a worksheet field, then show real local feedback/score without a long wait. | “Uji kefahaman anda” |
| 00:55–01:00 | 5 s | Finish on the best lab view, then the existing logo and title. Hold final branding long enough to read. | “BioNutri-MM” / “Belajar. Eksperimen. Fahami.” |

These intervals include transitions; transitions must not add extra runtime. Lab-centred footage occupies at least 32 seconds including opening/closing shots. Do not spend trailer time on credentials, registration, loading screens, or a lengthy menu tour. If an experiment is unreliable, replace it with another genuine working sequence within the same duration.

## 3. Offline chatbot demonstration

The current client uses an authenticated PHP backend and intentionally refuses requests without its configured endpoint/session. For recording, introduce a separate local demonstration mode. It does not need a ChatGPT account, application login, provider credential, or network connection. The live backend path remains separate.

### Behaviour

- Add an explicit serialized demo-mode switch to the existing `ChatGPT` component. Default it to OFF in normal game prefabs/scenes.
- Enable it only in the recording setup or a clearly separate demo build/profile. Restore and verify the normal setting afterwards.
- Branch into the local reply path before endpoint/session validation. Never insert a fake session token or restore the exposed API key.
- Reuse the existing message bubbles, scrolling, input field, and Send control. Preserve serialized UI references and `ChangePrompt()` compatibility.
- Display “DEMO LUAR TALIAN — jawapan contoh” visibly inside the chat panel, including the recorded segment. This is a scripted demonstration, not a live AI response.
- Match a small set of normalized Malay questions/keywords, with lesson context where useful, to reviewed sample answers. Add a short 0.6–1.0 second response delay and a simple “Sedang menaip…” state using existing visual styling.
- Handle empty messages, unknown questions, repeated Send clicks, lesson changes, and panel closing gracefully. Restore controls after completion/cancellation.
- Unknown questions receive an honest fallback: “Ini ialah demo luar talian. Cuba tanya tentang amilase, vitamin C atau Pinggan Sihat Malaysia.”
- In demo mode, make zero HTTP calls and perform no online score-saving operations as a side effect of recording.

### Example recording exchange

Student: “Apakah fungsi amilase?”

Sample reply: “Amilase membantu menguraikan kanji kepada maltosa, sejenis gula penurun.”

Additional reviewed responses can cover why vitamin C decolourises DCPIP and the quarter-quarter-half plate concept. Keep responses short enough to read within the six-second trailer segment. Use concise questions or begin typing just before the cut; do not speed text so much that it becomes unreadable.

## 4. Recording implementation

1. Inspect the current editor state, save status, compilation errors, active cameras, and working gameplay sequences. Preserve unsaved work and existing project changes.
2. Create an isolated trailer recording setup using existing scenes and reversible helpers. Do not permanently reposition runtime cameras or alter lesson instructions to produce a shot.
3. Capture a short test at 1080p before committing to the full recording. Verify that screen-overlay UI, cursor, equipment animations, reaction colours, and audio are present.
4. Prefer a functioning existing recording capability. Unity Recorder is not listed in the current package manifest, and FFmpeg was not found on PATH during inspection. Verify available tools first; install/configure a suitable recorder or encoder only if needed after implementation approval. Do not assume a video export tool is already available.
5. Use actual Play Mode/game output rather than the editor preview camera utility; that utility does not reproduce animated laboratory camera behaviour.
6. Record longer source takes than the final edit requires. Begin experiments from reproducible starting states and record several successful actions in each take.
7. A recording-only helper may drive existing buttons/actions to make capture repeatable. It must call real gameplay paths, be excluded from normal builds, and never simulate online persistence, student performance, or provider access.
8. For lab beauty shots, use a temporary recording camera and restore the original camera setup. Gameplay shots must keep the important action and required instructions visible.
9. Capture mouse movement at a controlled pace. Keep interaction feedback visible; hide the cursor only during noninteractive establishing/closing shots.
10. Keep recording assets/helpers in a dedicated folder. Store raw takes outside runtime Assets so they do not inflate game builds.

## 5. Editing and audio

- Use the existing identity for small caption overlays and the closing title. Reuse the logo instead of creating new branding.
- Prefer clean cuts on actions and restrained fades. Avoid excessive zooms, flashes, shake, or cinematic effects that obscure experiments.
- Keep captions within roughly 5% safe margins, with one short idea per shot. Use the established light text/panel contrast where necessary without covering the apparatus or the chat demo label.
- Trim long experiment waits; any accelerated observation should be labelled “Masa dipercepat”. Do not imply that a long incubation finishes instantly in the unedited game.
- Retain selected gameplay clicks and experiment sounds. Use a low music bed from existing audio only after its redistribution rights are confirmed; otherwise use original/licensed audio or a game-sound-only mix.
- Avoid overlapping spoken instructions from multiple scenes. Use no narration by default so the edit remains focused and readable.
- Avoid unverified release dates, download links, live-AI claims, invented experiments, or unsupported multiplayer claims.

## 6. Validation

### Chat demo checks

- Correct sample reply for the recording question and supported contexts.
- Honest fallback for unsupported questions.
- Zero network requests when demo mode is enabled, even with no endpoint/session configured.
- No duplicate bubbles from repeated Send input; UI recovers after panel closing or scene change.
- Normal mode continues to require the configured authenticated backend.
- Demo is OFF in normal scenes/prefabs after recording; recording configuration remains explicitly marked.

### Video checks

- Verify exact 60.000-second video timeline and 1,800 frames at 30 fps. Account for encoder/audio padding when inspecting container duration.
- Watch the entire exported MP4, not only the editor timeline. Check opening, every cut, final frame, audio sync, clipping, missing UI, and caption readability.
- Verify at least half the trailer showcases the 3D lab, with genuine moving interactions and clear scientific observations.
- Check at both full size and a smaller playback window. The question, reply, and offline-demo disclosure must remain readable.
- Confirm no credentials, account details, desktop notifications, editor panels, debug logs, or unintended windows appear.
- Verify there are no long frozen frames, blank frames, missing textures, broken animations, or abrupt audio endings.
- Restore the original scene/camera/session settings and inspect the console after capture.

## 7. Deliverables after implementation approval

- `Deliverables/Trailer/BioNutri-MM_Gameplay_Trailer_60s.mp4`.
- A matching poster/thumbnail frame from actual footage.
- The edit recipe or timeline, shot list, and any encoder settings needed to reproduce the trailer.
- The local chatbot demonstration implementation and recording-only configuration.
- A short report identifying footage used, verification results, demo disclosure, and remaining limitations.

No trailer has been produced and no dummy chatbot has been implemented by creation of this plan. Approval of implementation will authorize local capture/editing and the scoped demo changes; it does not authorize publishing the trailer to external services.
