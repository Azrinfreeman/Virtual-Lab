# Virtual Lab

**A Unity science-learning application with Malay-language activities, interactive laboratory sequences, quizzes, and results review.**

Virtual Lab brings lesson content and practical interactions into a scene-based learning experience. Its activities include digestive-system identification, a carbohydrate food-sample experiment, and food-pyramid/healthy-plate tasks. The project combines object selection and dragging, animation-driven instructions, answer evaluation, and a PHP-backed account and score flow.

## What the project demonstrates

- **A structured activity collection:** 49 enabled scenes, comprising seven menu/account scenes and 42 scenes grouped under `Aktiviti1` through `Aktiviti8`.
- **Interactive lab sequences:** raycast-based selection, object dragging, collision checks, and animation states guide experiment steps.
- **Different answer interactions:** text input, multiple-choice buttons, and drag/drop matching support quizzes and results activities.
- **Step feedback:** instruction text and progress indicators reflect configured animation milestones.
- **Nutrition activities:** food-pyramid matching and Pinggan Sihat Malaysia interaction logic are included.
- **Account and results integration:** login, registration, score submission, and results retrieval use Unity coroutines and `UnityWebRequest`.

The checked-in configuration uses **Unity 2022.3.60f1**, **C#**, **Universal Render Pipeline 14.0.12**, **TextMesh Pro 3.0.7**, and **Unity UI**. The Unity product name is `VirtualLab`, version **1.1**.

## Learning flow

1. Start from the entry menu and use the account flow with an isolated test backend.
2. Choose an activity from the activity menu.
3. Explore the configured theory, laboratory, discussion, results, or quiz scenes for that activity. Activity routes vary; not every group follows an identical sequence.
4. Select and move objects or provide answers as prompted.
5. Review feedback and, where configured, submit or retrieve results through the backend.

This describes the source design. It does not establish a tested standalone demo or a measured learning outcome.

## Explore the implementation

| Area | Source |
| --- | --- |
| Scene navigation and logout | [SceneController](Assets/SceneController.cs) |
| Object selection and lab dragging | [TouchController](Assets/TouchController.cs), [TouchController2](Assets/TouchController2.cs), and [DragController](Assets/DragController.cs) |
| Experiment instructions and animation coordination | [ObjectController](Assets/ObjectController.cs) and [ObjectController2](Assets/ObjectController2.cs) |
| Progress display | [ProgressController](Assets/ProgressController.cs) |
| UI answer dragging and drop targets | [DragScript](Assets/DragScript.cs) and [ItemSlot](Assets/ItemSlot.cs) |
| Multiple-choice and text-entry quizzes | [KuizController](Assets/KuizController.cs), [ButtonAnswers](Assets/ButtonAnswers.cs), and [Kuiz1Controller](Assets/Kuiz1Controller.cs) |
| Food-pyramid and healthy-plate tasks | [PiramidJawapanController](Assets/PiramidJawapanController.cs) and [PingganSihatMalaysiaController](Assets/PingganSihatMalaysiaController.cs) |
| Local answer values | [setUserData](Assets/setUserData.cs) |
| Accounts and score integration | [LoginController](Assets/LoginController.cs), [WebController](Assets/WebController.cs), [StoreDataController](Assets/StoreDataController.cs), and [StoreEksController](Assets/StoreEksController.cs) |

## Open the project

1. Clone or download the **complete repository**, including `Assets`, `Packages`, `ProjectSettings`, and Unity `.meta` files. A source-only checkout is sufficient for reading code but not for importing or running the application.
2. Add the repository root in Unity Hub and open it with **2022.3.60f1**, as recorded in [ProjectVersion.txt](ProjectSettings/ProjectVersion.txt). Avoid an editor upgrade during the first inspection.
3. Let Unity import assets and resolve the versions in [manifest.json](Packages/manifest.json) and [packages-lock.json](Packages/packages-lock.json).
4. Before Play mode, inspect the serialized `Domain` fields on network components in scenes and prefabs. Configure an isolated test service and disposable accounts before exercising any network feature.
5. Open [StartMenu.unity](Assets/Scenes/StartMenu.unity), the first enabled scene in [EditorBuildSettings.asset](ProjectSettings/EditorBuildSettings.asset).
6. Preserve the existing scene list and order. Menus lead into eight activity groups; scripts also depend on scene names, configured object hierarchies, tags, animation states, and Inspector references.

Import, build, input handling, and rendering must be validated on the intended target before sharing a demo. This documentation pass did not open Unity or execute the app.

## Backend requirements

The inspected login and registration scenes contain an external `Domain` value of `https://barangbest2u.com/unity/`; results-review components also contain `/kuiz/` and `/eks/` paths under that service. Other activity scenes and prefabs must be reviewed independently for their configured values. No requests were sent to these services during this documentation pass.

| Client operation | Script and endpoint suffix |
| --- | --- |
| Registration | [WebController](Assets/WebController.cs): `InsertUser.php` |
| Login | [LoginController](Assets/LoginController.cs): `LoginUser.php` |
| Initialize quiz/experiment records | [LoginController](Assets/LoginController.cs): `InsertKuizAndEks.php` |
| Submit quiz/experiment scores | [StoreDataController](Assets/StoreDataController.cs): `insertKuiz2.php`; [StoreEksController](Assets/StoreEksController.cs): `insertEks.php` |
| Retrieve quiz/experiment results | [LoadUserScore](Assets/LoadUserScore.cs): `fetchKuiz.php`; [LoadUserEks](Assets/LoadUserEks.cs): `fetchEks.php` |

Registration sends the entered username, email, and password fields. Login sends the entered username/password and expects either the literal `login invalid` or a positive integer user ID. Score operations send the stored user ID, activity number, and score as configured by each component. `PlayerPrefs` holds the username, user ID, and some activity answers; it is not proof of secure authentication.

The repository contains a small [GetUsers.php sample](Assets/Scenes/php/GetUsers.php), not a complete deployment of the client endpoints or database schema. Backend availability, response handling, authentication, and data retention remain unverified. Use an isolated test implementation with disposable data rather than treating the existing service as a public demo backend.

## Validation and demo status

The README was checked against source files and project configuration. Unity import/compilation, platform builds, complete activity flows, backend behavior, and educational correctness were **not tested** in this documentation pass. The presence of the Unity Test Framework package is not a passing project test result.

See the [demo checklist](docs/DEMO_CHECKLIST.md) for a future validation session. Capture screenshots and a walkthrough from the actual app using disposable accounts after those checks; no simulated screenshots or performance claims are included here.

## Included components and licensing

The project includes [Quick Outline](Assets/QuickOutline/Readme.txt), credited in its included readme to Chris Nolet, and sample content under [`ZerinLabs_shaderPack_CartoonWater`](Assets/ZerinLabs_shaderPack_CartoonWater/). Unity packages and other bundled artwork, models, fonts, and audio require their own attribution and usage review.

No repository-wide license file is included in the inspected tree. Public visibility and dependency licenses do not grant reuse rights to all project content. Confirm ownership and redistribution terms before distributing a build or reusing assets.
