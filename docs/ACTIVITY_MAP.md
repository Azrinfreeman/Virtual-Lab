# Scene and activity map

This index follows the enabled entries in [EditorBuildSettings.asset](../ProjectSettings/EditorBuildSettings.asset). It is a source-navigation guide: build order does not establish the route taken by menu buttons or prove that an activity works.

## Entry and menu scenes

| Build index | Scene |
| --- | --- |
| 0 | [StartMenu](../Assets/Scenes/StartMenu.unity) |
| 1 | [Login](../Assets/Scenes/Login.unity) |
| 2 | [Register](../Assets/Scenes/Register.unity) |
| 3 | [MainMenu](../Assets/Scenes/MainMenu.unity) |
| 4 | [MainMenuObjektif](../Assets/Scenes/MainMenuObjektif.unity) |
| 5 | [MainMenuAktiviti](../Assets/Scenes/MainMenuAktiviti.unity) |
| 6 | [MainMenuSemakan](../Assets/Scenes/MainMenuSemakan.unity) |

## Activity groups

Scene filenames are kept as recorded. No lesson titles or topic assignments are inferred from their numbers.

| Group | Enabled scenes | Source scenes in build order |
| --- | --- | --- |
| Aktiviti1 | 7 | [1.0](../Assets/Scenes/Aktiviti1/1.0.unity), [1.1](../Assets/Scenes/Aktiviti1/1.1.unity), [1.2](../Assets/Scenes/Aktiviti1/1.2.unity), [1.3](../Assets/Scenes/Aktiviti1/1.3.unity), [1.4](../Assets/Scenes/Aktiviti1/1.4.unity), [1.5](../Assets/Scenes/Aktiviti1/1.5.unity), [1.6](../Assets/Scenes/Aktiviti1/1.6.unity) |
| Aktiviti2 | 5 | [2.0](../Assets/Scenes/Aktiviti2/2.0.unity), [2.1](../Assets/Scenes/Aktiviti2/2.1.unity), [2.2](../Assets/Scenes/Aktiviti2/2.2.unity), [2.3](../Assets/Scenes/Aktiviti2/2.3.unity), [2.4](../Assets/Scenes/Aktiviti2/2.4.unity) |
| Aktiviti3 | 5 | [3.0](../Assets/Scenes/Aktiviti3/3.0.unity), [3.1](../Assets/Scenes/Aktiviti3/3.1.unity), [3.2](../Assets/Scenes/Aktiviti3/3.2.unity), [3.3](../Assets/Scenes/Aktiviti3/3.3.unity), [3.4](../Assets/Scenes/Aktiviti3/3.4.unity) |
| Aktiviti4 | 5 | [4.0](../Assets/Scenes/Aktiviti4/4.0.unity), [4.1](../Assets/Scenes/Aktiviti4/4.1.unity), [4.2](../Assets/Scenes/Aktiviti4/4.2.unity), [4.3](../Assets/Scenes/Aktiviti4/4.3.unity), [4.4](../Assets/Scenes/Aktiviti4/4.4.unity) |
| Aktiviti5 | 5 | [5.0](../Assets/Scenes/Aktiviti5/5.0.unity), [5.1](../Assets/Scenes/Aktiviti5/5.1.unity), [5.2](../Assets/Scenes/Aktiviti5/5.2.unity), [5.3](../Assets/Scenes/Aktiviti5/5.3.unity), [5.4](../Assets/Scenes/Aktiviti5/5.4.unity) |
| Aktiviti6 | 5 | [6.0](../Assets/Scenes/Aktiviti6/6.0.unity), [6.1](../Assets/Scenes/Aktiviti6/6.1.unity), [6.2](../Assets/Scenes/Aktiviti6/6.2.unity), [6.3](../Assets/Scenes/Aktiviti6/6.3.unity), [6.4](../Assets/Scenes/Aktiviti6/6.4.unity) |
| Aktiviti7 | 5 | [7.0](../Assets/Scenes/Aktiviti7/7.0.unity), [7.1](../Assets/Scenes/Aktiviti7/7.1.unity), [7.2](../Assets/Scenes/Aktiviti7/7.2.unity), [7.3](../Assets/Scenes/Aktiviti7/7.3.unity), [7.4](../Assets/Scenes/Aktiviti7/7.4.unity) |
| Aktiviti8 | 5 | [8.0](../Assets/Scenes/Aktiviti8/8.0.unity), [8.1](../Assets/Scenes/Aktiviti8/8.1.unity), [8.2](../Assets/Scenes/Aktiviti8/8.2.unity), [8.3](../Assets/Scenes/Aktiviti8/8.3.unity), [8.4](../Assets/Scenes/Aktiviti8/8.4.unity) |

There are 49 enabled scenes in total: seven entry/menu scenes and 42 activity scenes. The project enters through `StartMenu`; verify subsequent navigation against scene wiring and [SceneController](../Assets/SceneController.cs).

Before a functional walkthrough, follow the [demo checklist](DEMO_CHECKLIST.md) and the README backend setup instructions. Account and results operations need an isolated test service and disposable data. Unity import, full activity routes, and builds have not been tested in this documentation pass.
