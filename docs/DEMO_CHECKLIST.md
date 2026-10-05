# Virtual Lab demo verification

These checks are pending. Source review used base commit `819df8273ced9788eca0cc1e62241722c222a75a`; the documentation branch does not change scripts, scenes, packages, or project settings.

## Prepare an isolated environment

- [ ] Obtain the complete project and import it with Unity 2022.3.60f1. Record import/compilation errors and missing resources.
- [ ] Check all serialized `Domain` values in scenes and prefabs and all `UnityWebRequest` call sites. Point network operations at an isolated test backend before Play mode.
- [ ] Prepare disposable accounts, email addresses, and passwords. Review the backend request/response contract and database schema; the included PHP sample is not a complete service deployment.
- [ ] Verify the 49 enabled scene entries and the expected object, tag, animation, and Inspector references on the intended platform.

## Exercise representative activities

- [ ] Start from `StartMenu`, then test registration, invalid login, valid login, and logout against the isolated service only.
- [ ] Visit all eight activity groups and verify that their menu routes load the correct scenes.
- [ ] Complete a digestive-system text-entry task with correct, incorrect, and then cleared answers.
- [ ] Complete one lab experiment from initial object selection through dragging, collision detection, animation milestones, and results entry. Check repeated interactions and early/incorrect actions.
- [ ] Verify quiz scoring after the first submission and repeated submissions. Score-counting methods increment the existing score value, so check scene wiring and reset behavior explicitly.
- [ ] Check input and answer restoration when revisiting a scene or switching test accounts. Some local activity values use shared `PlayerPrefs` keys rather than user-specific keys.
- [ ] Exercise valid and invalid food-pyramid and healthy-plate arrangements, including all feedback objects and scene references.
- [ ] Submit and retrieve quiz/experiment results against the isolated backend; check unavailable service, unexpected response text, and UI recovery. Login currently parses non-error responses as integers, so include malformed responses.
- [ ] Verify audio, rendering, UI layout, input, progress indicators, and scene navigation on the intended build target.

## Prepare portfolio evidence

- [ ] Have the learning content and expected results reviewed before making curriculum or educational-effectiveness claims.
- [ ] Review bundled component attribution and artwork/model/font/audio redistribution rights before distributing a build.
- [ ] Capture actual screenshots or a short walkthrough with disposable accounts and no real learner information.
- [ ] Record the tested editor, target, build outcome, backend setup, and remaining limitations alongside the demo.

No production-service requests, Unity runtime tests, or builds were executed during the documentation pass.
