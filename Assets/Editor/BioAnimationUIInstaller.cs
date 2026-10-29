using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public static class BioAnimationUIInstaller
{
    static T Ensure<T>(GameObject go) where T : Component
    {
        var component = go.GetComponent<T>();
        return component == null ? go.AddComponent<T>() : component;
    }
    static IEnumerable<T> All<T>(Scene scene) where T : Component =>
        scene.GetRootGameObjects().SelectMany(r => r.GetComponentsInChildren<T>(true));
    static bool ScreenUI(Component c)
    {
        var canvas = c.GetComponentInParent<Canvas>(true);
        if (canvas == null) return false;
        var root = canvas.GetComponentsInParent<Canvas>(true).Last();
        return root.renderMode != RenderMode.WorldSpace || root.GetComponentInParent<Camera>(true) != null;
    }
    static bool ScaleIsAnimated(Transform target)
    {
        for (var parent = target; parent != null; parent = parent.parent)
        {
            var animator = parent.GetComponent<Animator>();
            if (animator == null || animator.runtimeAnimatorController == null) continue;
            string path = AnimationUtility.CalculateTransformPath(target, parent);
            if (animator.runtimeAnimatorController.animationClips.Any(c => AnimationUtility.GetCurveBindings(c)
                .Any(b => b.path == path && b.propertyName.StartsWith("m_LocalScale")))) return true;
        }
        return false;
    }
    static void Controls(Scene scene)
    {
        foreach (var item in All<DragScript>(scene)) Ensure<Selectable>(item.gameObject);
        foreach (var slot in All<ItemSlot>(scene)) Ensure<Selectable>(slot.gameObject);
        foreach (var selectable in All<Selectable>(scene).Where(ScreenUI).ToArray())
        {
            var feedback = Ensure<BioControlFeedback>(selectable.gameObject);
            var graphic = selectable.targetGraphic;
            if (graphic == null) graphic = selectable.GetComponent<Graphic>();
            if (graphic != null)
            {
                var outline = graphic.GetComponent<UnityEngine.UI.Outline>();
                if (outline == null)
                {
                    outline = graphic.gameObject.AddComponent<UnityEngine.UI.Outline>();
                    outline.effectDistance = new Vector2(3, -3);
                    outline.effectColor = graphic.color.grayscale > .6f ? BioPalette.SelectOnPaper : BioPalette.FocusRing;
                    outline.useGraphicAlpha = false;
                    outline.enabled = false;
                    feedback.focusOutline = outline;
                }
            }
            if (selectable.GetComponentInParent<ButtonReactionController>() == null &&
                selectable.GetComponent<DragScript>() == null && selectable.GetComponent<ItemSlot>() == null)
            {
                var visual = graphic != null && graphic.transform != selectable.transform ? graphic.rectTransform :
                    selectable.GetComponentsInChildren<TMP_Text>(true).FirstOrDefault()?.rectTransform;
                if (visual != null && !ScaleIsAnimated(visual)) feedback.motionTarget = visual;
            }
            if (selectable is TMP_InputField || selectable is Slider || selectable is Scrollbar) continue;
            var navigation = selectable.navigation;
            if (navigation.mode == Navigation.Mode.None) { navigation.mode = Navigation.Mode.Automatic; selectable.navigation = navigation; }
        }
        foreach (var canvas in All<Canvas>(scene).Where(ScreenUI).ToArray())
        {
            if (canvas.GetComponentsInParent<Canvas>(true).Length > 1)
            {
                var nestedFocus=canvas.GetComponent<BioScreenFocus>();
                if (nestedFocus != null) Object.DestroyImmediate(nestedFocus);
                var backdrop=canvas.transform.Find("Panel");
                var nestedSafe=backdrop == null ? null : backdrop.GetComponent<BioSafeArea>();
                if (nestedSafe != null) Object.DestroyImmediate(nestedSafe);
                continue;
            }
            var focus = Ensure<BioScreenFocus>(canvas.gameObject);
            focus.defaultControl = canvas.GetComponentsInChildren<Selectable>()
                .FirstOrDefault(s=>s.IsInteractable() && s.GetComponentInParent<BioModal>() == null);
            var panel = canvas.transform.Find("Panel");
            if (panel != null && panel is RectTransform) Ensure<BioSafeArea>(panel.gameObject);
        }
    }
    static IEnumerable<AnimatorState> States(AnimatorStateMachine machine)
    {
        foreach (var child in machine.states) yield return child.state;
        foreach (var child in machine.stateMachines) foreach (var state in States(child.stateMachine)) yield return state;
    }
    static void Modals(Scene scene)
    {
        foreach (var animator in All<Animator>(scene).Where(ScreenUI).ToArray())
        {
            string path = AssetDatabase.GetAssetPath(animator.runtimeAnimatorController);
            if (path.Contains("/Resister_Login/") || path.Contains("/AiButtonFloat"))
                Ensure<BioDecorativeMotion>(animator.gameObject);
            if (path != "Assets/Animation/MainMenu/prompt1.controller") continue;
            var rootCanvas = animator.GetComponentsInParent<Canvas>(true).Last();
            var modal = Ensure<BioModal>(animator.gameObject);
            modal.screenGroup = Ensure<CanvasGroup>(rootCanvas.gameObject);
            modal.modalCanvas = Ensure<Canvas>(animator.gameObject);
            modal.modalCanvas.renderMode = rootCanvas.renderMode;
            modal.modalCanvas.worldCamera = rootCanvas.worldCamera;
            modal.modalCanvas.targetDisplay = rootCanvas.targetDisplay;
            modal.modalCanvas.overrideSorting = true;
            modal.modalCanvas.sortingOrder = 200;
            Ensure<GraphicRaycaster>(animator.gameObject);
            var group = animator.GetComponent<CanvasGroup>();
            group.ignoreParentGroups = true;
            group.interactable = group.blocksRaycasts = false;
            modal.cancelButton = animator.GetComponentsInChildren<Button>(true).FirstOrDefault(b=>
                (b.name.ToLowerInvariant().Contains("tidak") || b.name.ToLowerInvariant().Contains("close") ||
                 b.name.ToLowerInvariant().Contains("tutup") || b.GetComponentsInChildren<TMP_Text>(true)
                    .Any(t=>new[]{"KEMBALI","TUTUP","BATAL","TIDAK"}.Contains(t.text.Trim().ToUpperInvariant()))) &&
                !Enumerable.Range(0, b.onClick.GetPersistentEventCount()).Any(i=>
                    new[]{"ChangeScene", "QuitApplication", "Logout", "checkAnswers", "CheckAnswer", "Login"}
                    .Contains(b.onClick.GetPersistentMethodName(i))));
            modal.initialControl = modal.cancelButton != null ? modal.cancelButton : animator.GetComponentsInChildren<Button>(true)
                .FirstOrDefault(b=>b.GetComponentsInChildren<TMP_Text>(true).Any(t=>t.text.Trim() == "MULA")) as Selectable;
            StyleModal(animator.transform);
            var controller = animator.runtimeAnimatorController as AnimatorController;
            if (controller != null) foreach (var state in States(controller.layers[0].stateMachine))
            {
                if (state.name != "popupPrompt" && state.name != "PopPrompt") continue;
                var behavior = state.behaviours.OfType<BioModalState>().FirstOrDefault();
                if (behavior == null) behavior = state.AddStateMachineBehaviour<BioModalState>();
                behavior.opening = state.name == "popupPrompt";
                EditorUtility.SetDirty(behavior);
            }
            if (animator.name == "audioPrompt") AddMotionToggle(animator.transform);
        }
    }
    static void StyleModal(Transform prompt)
    {
        var image = prompt.Find("Image");
        if (image == null) return;
        var background = image.GetComponent<Image>();
        if (background != null) background.color = BioPalette.SurfacePaper;
        foreach (var label in image.GetComponentsInChildren<TMP_Text>(true))
            label.color = label.GetComponentInParent<Button>(true) != null ? BioPalette.TextPrimary : BioPalette.InkPrimary;
        foreach (var button in image.GetComponentsInChildren<Button>(true))
        {
            var graphic = button.targetGraphic as Image;
            if (graphic != null) graphic.color = BioPalette.ActionPrimary;
            button.colors = BioPalette.ActionColors();
        }
        if (prompt.name != "audioPrompt") return;
        foreach (var label in image.GetComponentsInChildren<TMP_Text>(true))
        {
            switch (label.text.Trim())
            {
                case "SETTING": label.text="TETAPAN"; break;
                case "MASTER": label.text="UTAMA"; break;
                case "BGM": label.text="MUZIK"; break;
                case "SFX": label.text="KESAN BUNYI"; break;
            }
        }
        foreach (var slider in image.GetComponentsInChildren<Slider>(true))
        {
            if (slider.fillRect != null && slider.fillRect.GetComponent<Image>() != null)
                slider.fillRect.GetComponent<Image>().color = BioPalette.ActionPrimary;
            foreach (var label in slider.GetComponentsInChildren<TMP_Text>(true)) label.color = BioPalette.TextPrimary;
        }
        foreach (var fill in image.GetComponentsInChildren<Image>(true).Where(i=>i.name == "Fill"))
            fill.color = BioPalette.ActionPrimary;
    }
    static TextMeshProUGUI Label(Transform parent, string name, TMP_FontAsset font, string text, int size)
    {
        var existing = parent.Find(name);
        var go = existing == null ? new GameObject(name, typeof(RectTransform), typeof(TextMeshProUGUI)) : existing.gameObject;
        if (existing == null) go.transform.SetParent(parent, false);
        var label = go.GetComponent<TextMeshProUGUI>();
        label.font = font;
        label.text = text;
        label.fontSize = size;
        label.color = BioPalette.TextPrimary;
        label.raycastTarget = false;
        return label;
    }
    static void Place(RectTransform rect, Vector2 anchor, Vector2 pivot, Vector2 position, Vector2 size)
    {
        rect.anchorMin = rect.anchorMax = anchor;
        rect.pivot = pivot;
        rect.anchoredPosition = position;
        rect.sizeDelta = size;
    }
    static void AddMotionToggle(Transform prompt)
    {
        var panel = prompt.Find("Image");
        if (panel == null) return;
        if (panel.Find("ReduceMotion") != null)
        {
            panel.Find("ReduceMotion/Label").GetComponent<TMP_Text>().color = BioPalette.InkPrimary;
            return;
        }
        var reference = panel.GetComponentInChildren<TMP_Text>(true);
        var go = new GameObject("ReduceMotion", typeof(RectTransform), typeof(Toggle));
        go.transform.SetParent(panel, false);
        Place((RectTransform)go.transform, new Vector2(.5f, 0), new Vector2(.5f, 0), new Vector2(0, 26), new Vector2(520, 56));
        var box = new GameObject("Box", typeof(RectTransform), typeof(Image));
        box.transform.SetParent(go.transform, false);
        Place((RectTransform)box.transform, new Vector2(0,.5f), new Vector2(0,.5f), new Vector2(0,0), new Vector2(40,40));
        box.GetComponent<Image>().color = BioPalette.SurfacePaper;
        var check = new GameObject("Check", typeof(RectTransform), typeof(Image));
        check.transform.SetParent(box.transform, false);
        var cr = (RectTransform)check.transform;
        cr.anchorMin = Vector2.zero; cr.anchorMax = Vector2.one;
        cr.offsetMin = new Vector2(8,8); cr.offsetMax = new Vector2(-8,-8);
        check.GetComponent<Image>().color = BioPalette.SelectOnPaper;
        var label = Label(go.transform, "Label", reference == null ? TMP_Settings.defaultFontAsset : reference.font, "Kurangkan gerakan", 30);
        Place(label.rectTransform, new Vector2(0,.5f), new Vector2(0,.5f), new Vector2(56,0), new Vector2(464,56));
        label.alignment = TextAlignmentOptions.MidlineLeft;
        label.color = BioPalette.InkPrimary;
        var toggle = go.GetComponent<Toggle>();
        toggle.targetGraphic = box.GetComponent<Image>(); toggle.graphic = check.GetComponent<Image>();
        Ensure<BioMotionToggle>(go);
    }
    static void Quizzes(Scene scene)
    {
        foreach (var quiz in All<KuizController>(scene))
        {
            var paper = quiz.transform.parent as RectTransform;
            if (paper == null || paper.parent == null) continue;
            var reference = quiz.GetComponentInChildren<TMP_Text>(true);
            var label = Label(paper.parent, "QuizStatus", reference == null ? TMP_Settings.defaultFontAsset : reference.font, "Soalan 1 / " + quiz.transform.childCount, 26);
            var rect = label.rectTransform;
            rect.anchorMin = paper.anchorMin; rect.anchorMax = paper.anchorMax;
            rect.pivot = new Vector2(1,0);
            rect.sizeDelta = new Vector2(400,38);
            rect.anchoredPosition = paper.anchoredPosition + new Vector2(paper.rect.width * (1-paper.pivot.x), paper.rect.height * (1-paper.pivot.y) + 12);
            label.alignment = TextAlignmentOptions.MidlineRight;
            label.color = BioPalette.TextSecondary;
            quiz.statusLabel = label;
            for (int i=0;i<quiz.transform.childCount;i++)
            {
                var page = Ensure<BioQuizPage>(quiz.transform.GetChild(i).gameObject);
                page.quiz = quiz; page.index = i;
            }
        }
    }
    static void Laboratories(Scene scene)
    {
        foreach (var progress in All<ProgressController>(scene))
        {
            var animator = All<Animator>(scene).FirstOrDefault(a=>a.name == "GameObject (1)" && a.transform.parent == null);
            if (animator == null) throw new InvalidOperationException("No main experiment Animator in " + scene.path);
            progress.mainScene = animator;
            Ensure<BioLabStepRelay>(animator.gameObject);
            var controller = animator.runtimeAnimatorController as AnimatorController;
            if (controller == null) throw new InvalidOperationException("Unsupported lab controller in " + scene.path);
            var states = States(controller.layers[0].stateMachine).ToArray();
            foreach (int step in ProgressController.Milestones(progress.no))
                if (!states.Any(s=>s.name == "step" + step || Regex.IsMatch(s.name, "^step[0-9]+-" + step + "$")))
                    throw new InvalidOperationException("Missing milestone step" + step + " in " + scene.path);
            foreach (var state in states)
            {
                var match = Regex.Match(state.name, "^step([0-9]+)(?:-([0-9]+))?$");
                if (!match.Success) continue;
                var behavior = state.behaviours.OfType<BioLabStepState>().FirstOrDefault();
                if (behavior == null) behavior = state.AddStateMachineBehaviour<BioLabStepState>();
                behavior.startStep = int.Parse(match.Groups[1].Value);
                behavior.step = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : behavior.startStep;
                EditorUtility.SetDirty(behavior);
            }
            var title = progress.transform.parent.GetComponent<TextMeshProUGUI>();
            if (title == null) continue;
            title.text = "KEMAJUAN"; title.fontSize = 28; title.alignment = TextAlignmentOptions.TopLeft;
            title.color = BioPalette.TextPrimary;
            Place(title.rectTransform, new Vector2(0,1), new Vector2(0,1), new Vector2(48,-32), new Vector2(400,130));
            var surface = title.transform.parent.Find("LabProgressSurface");
            if (surface == null)
            {
                var go = new GameObject("LabProgressSurface", typeof(RectTransform), typeof(Image));
                go.transform.SetParent(title.transform.parent, false);
                go.transform.SetSiblingIndex(title.transform.GetSiblingIndex());
                surface = go.transform;
            }
            Place((RectTransform)surface, new Vector2(0,1), new Vector2(0,1), new Vector2(36,-20), new Vector2(424,154));
            var backdrop = surface.GetComponent<Image>();
            backdrop.color = new Color(BioPalette.SurfaceRaised.r, BioPalette.SurfaceRaised.g, BioPalette.SurfaceRaised.b, .94f);
            backdrop.raycastTarget = false;
            Place((RectTransform)progress.transform, new Vector2(0,1), new Vector2(0,1), new Vector2(12,-48), new Vector2(376,26));
            progress.slider = progress.GetComponent<Slider>();
            progress.text = progress.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            progress.text.fontSize = 24;
            progress.text.color = BioPalette.TextPrimary;
            Place(progress.text.rectTransform, new Vector2(1,0), new Vector2(1,1), new Vector2(0,-8), new Vector2(80,36));
            progress.text.alignment = TextAlignmentOptions.TopRight;
            var label = Label(title.transform, "StepLabel", title.font, "Langkah 1 / " + ProgressController.Milestones(progress.no).Last(), 24);
            Place(label.rectTransform, new Vector2(0,0), new Vector2(0,0), new Vector2(12,8), new Vector2(280,36));
            progress.stepLabel = label;
        }
    }
    static void FormsAndScores(Scene scene)
    {
        if (scene.name == "1.1" || scene.name == "1.6")
            foreach (var line in All<Image>(scene).Where(i=>i.color.r > .7f && i.color.g < .4f && i.color.b < .4f &&
                i.rectTransform.rect.width > 1 && i.rectTransform.rect.height < .15f))
                line.color = BioPalette.Info;
        if (Regex.IsMatch(scene.name,"^[2-7]\\.3$"))
        {
            foreach (var scroll in All<ScrollRect>(scene).Where(s=>s.name == "Scroll View" && s.content != null && s.GetComponentInParent<BioModal>() == null))
            {
                var surface = scroll.GetComponent<Image>();
                if (surface != null) surface.color = BioPalette.SurfacePaper;
                foreach (var image in scroll.content.GetComponentsInChildren<Image>(true))
                {
                    var field = image.GetComponent<TMP_InputField>();
                    if (field != null) image.color = BioPalette.SurfaceField;
                    else if (image.name.StartsWith("1") && image.color.a > .5f) image.color = BioPalette.SurfacePaper;
                }
                var background = scroll.content.GetComponent<Image>();
                if (background != null) background.color = BioPalette.SurfacePaper;
                foreach (var input in scroll.content.GetComponentsInChildren<TMP_InputField>(true))
                {
                    if (input.textComponent != null) input.textComponent.color = BioPalette.InkPrimary;
                    var placeholder = input.placeholder as TMP_Text;
                    if (placeholder != null) placeholder.color = BioPalette.InkPlaceholder;
                }
            }
        }
        foreach (var label in All<TMP_Text>(scene).Where(t=>t.GetComponent<LoadUserScore>()!=null || t.GetComponent<LoadUserEks>()!=null))
        {
            label.text="Memuat...";
            label.fontSize=26;
            label.textWrappingMode=TextWrappingModes.Normal;
            label.alignment=TextAlignmentOptions.Center;
            label.color=BioPalette.InkPrimary;
        }
    }
    public static string ApplyScene(string path)
    {
        if (EditorApplication.isPlaying) throw new InvalidOperationException("Stop Play Mode first.");
        var scene = SceneManager.GetSceneByPath(path);
        bool loaded = scene.IsValid() && scene.isLoaded;
        if (loaded && scene.isDirty) throw new InvalidOperationException("Unsaved scene: " + path);
        if (!loaded) scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
        try
        {
            Modals(scene);
            Quizzes(scene);
            Laboratories(scene);
            FormsAndScores(scene);
            Controls(scene);
            if (path.EndsWith("MainMenuAktiviti.unity"))
            {
                var panel = All<RectTransform>(scene).First(r=>r.name == "aktivitiControler");
                panel.GetComponent<Image>().color = BioPalette.SurfaceRaised;
            }
            // Direct component assignments on prefab instances need explicit override recording.
            foreach (var component in All<Component>(scene).Where(c=>c != null && PrefabUtility.IsPartOfPrefabInstance(c)))
                PrefabUtility.RecordPrefabInstancePropertyModifications(component);
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
            return path + ": " + All<BioControlFeedback>(scene).Count() + " controls, " + All<BioModal>(scene).Count() + " dialogs";
        }
        finally { if (!loaded) EditorSceneManager.CloseScene(scene,true); }
    }
    public static string[] ApplyAll()
    {
        return AssetDatabase.FindAssets("t:Scene", new[]{"Assets/Scenes"}).Select(AssetDatabase.GUIDToAssetPath)
            .OrderBy(p=>p).Select(ApplyScene).ToArray();
    }
}
