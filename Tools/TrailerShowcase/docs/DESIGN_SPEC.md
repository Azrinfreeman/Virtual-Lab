# BioNutri-MM showcase

Approved production mode: autonomous custom, selected by the user's PROCEED after the implementation plan. Scope and storyboard: `../../../TRAILER_SHOWCASE_IMPLEMENTATION_PLAN.md`.

Audience: learners and educators; a 60-second, Malay, landscape gameplay teaser. Core promise: explore nutrition, see guided experiments, manipulate food, and check understanding. No accounts, online scores, live AI, release date or availability claim.

## Direction decision

Considered: (1) an editorial laboratory film, (2) a kinetic feature reel, (3) a classroom walkthrough. Selected (1): the game supplies the environment, apparatus, anatomy, plate and quiz. Use deliberate framing, a connected experiment, quiet observation, then real placement and answer feedback. A kinetic reel would compromise reading; a full walkthrough would exceed the teaser length.

Use the product's existing navy #14103F, purple #221C5C, paper #F6F1E4, white #F4F2FF and guidance cyan #5CC8FF. Preserve experiment colours without grading. Purple Smile is the existing playful display face; Liberation Sans is the existing readable body face. Caption 42px/1.2, brand 88px, title 64px. Keep captions outside gameplay in a 116px navy lower band: footage retains its full original 16:9 bounds at 1680×945, no obstruction or crop. This slightly reduces on-screen UI size; review at 720p.

Motion: curious, calm, welcoming. Native camera beauty reveal 5s; full-screen holds for mechanics. Caption entry 0.35s ease-out, 10px travel, no spring. No camera shake, beat pumping or flashing. Clean cuts on absolute 96 BPM grid; no speed-up/reversed/looped reactions. Caption blocks ≥4s. Close uses the exact `logo-shrink-wordmark-lockup` source, time-scaled 30→60fps, retaining scale5.4→1, 6% brake, upright actual logo, stagger and 1.2s settled motto hold. Disable optional grain to preserve clean product artwork.

## Requirement → execution

| Requirement | Implementation / evidence |
|---|---|
| Gameplay | Recapture current Unity, full-frame end-of-frame including UI; native60fps |
| Meaningful experiment | Named authored-animation transfer/observation inserts disclosed as simulation; no manual3D-input claim |
| Hands-on actions | Actual pointer EventSystem drag/drop and toggles; acceptance and answer markers logged |
| Vibe | Original96BPM instrumental; restrained editorial camera; real game click sample |
| Branding | Existing logo/fonts/palette; one signature closing recipe |
| Privacy | No accounts/chat/score network during capture; preferences restored |
| Review | Studio preview, per-shot stills, short draft renders; full final render awaits approval |

## Feature → shot mapping

Laboratory → native beauty tracking; menu → full-screen focus/selection; transfer → real guided demonstration; observation/vitaminC → disclosed authored simulation inserts at normal speed; anatomy → full-screen readable view; plate → real drag/drop; quiz → real toggles and truthful single-question feedback; brand → logo-shrink-wordmark-lockup. No other recipe is necessary for actual gameplay. This intentionally adapts the generic promo-energy-arc: moving gameplay opens immediately, with reading/observation replacing interstitial title cards.

The implementation timeline is the single source for frame boundaries, captions and sound cues. Native take manifests disclose setup and action paths. Each moving gameplay take must pass a contact-sheet review before selection. The previous trailer was reviewed in a 5-second-interval contact sheet and is retained only as a pacing reference: its old UI, silent gameplay and chat segment are excluded from this cut.

Capture adaptation: editor end-of-frame coroutines stalled with the Game View obscured. The verified smoke test routes overlay roots reversibly through a native capture camera; it includes the modal/HUD. Laboratory inserts retain instruction panels but omit their full-screen dim backdrop for editorial visibility. They are labelled animation excerpts, not a recorded manual experiment. Actual manipulation proof comes from the plate's real BeginDrag/OnDrag/OnDrop/EndDrag and the quiz's real toggle/check paths. This replaces the proposed unverified 3D drag proof; caption now truthfully says follow the experiment step by step. No pointer or invented click sound is added to the animation excerpts.
