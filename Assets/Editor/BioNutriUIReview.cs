using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public static class BioNutriUIReview
{
    public static void Capture(string path, string output, int width, int height)
    {
        var scene = EditorSceneManager.OpenPreviewScene(path);
        RenderTexture rt = null;
        Texture2D texture = null;
        Camera captureCamera = null;
        var previous = RenderTexture.active;
        try
        {
            var go = new GameObject("UI review camera", typeof(Camera));
            UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(go, scene);
            var camera = go.GetComponent<Camera>();
            captureCamera = camera;
            camera.overrideSceneCullingMask = EditorSceneManager.GetSceneCullingMask(scene);
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
            rt = new RenderTexture(width, height, 24);
            camera.targetTexture = rt;
            foreach (var canvas in scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<Canvas>(true))
                .Where(c => c.isRootCanvas && c.renderMode != RenderMode.WorldSpace))
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camera;
                canvas.planeDistance = 100;
            }
            Canvas.ForceUpdateCanvases();
            camera.Render();
            RenderTexture.active = rt;
            texture = new Texture2D(width, height);
            texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            texture.Apply();
            Directory.CreateDirectory(Path.GetDirectoryName(output));
            File.WriteAllBytes(output, texture.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            if (captureCamera != null) captureCamera.targetTexture = null;
            if (texture != null) Object.DestroyImmediate(texture);
            if (rt != null) Object.DestroyImmediate(rt);
            EditorSceneManager.ClosePreviewScene(scene);
        }
    }

    public static int RefineForms()
    {
        int updated = 0;
        foreach (var guid in AssetDatabase.FindAssets("t:Scene", new[] { "Assets/Scenes" }))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            // Reading/answer screens only: do not change apparatus canvases or lab scroll behaviour.
            if (!(path.EndsWith(".3.unity") || path.EndsWith(".4.unity") ||
                path.EndsWith("Login.unity") || path.EndsWith("Register.unity") ||
                path.EndsWith("MainMenuSemakan.unity"))) continue;
            var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
            bool changed = false;
            try
            {
                foreach (var root in scene.GetRootGameObjects())
                {
                    foreach (var scroll in root.GetComponentsInChildren<ScrollRect>(true))
                    {
                        if (scroll.vertical && !scroll.horizontal)
                        {
                            scroll.movementType = ScrollRect.MovementType.Clamped;
                            scroll.scrollSensitivity = 30;
                            changed = true;
                        }
                    }
                    foreach (var input in root.GetComponentsInChildren<TMPro.TMP_InputField>(true))
                    {
                        if (input.textComponent != null) input.textComponent.raycastTarget = false;
                        var placeholder = input.placeholder as TMPro.TMP_Text;
                        if (placeholder != null) placeholder.raycastTarget = false;
                        changed = true;
                    }
                    foreach (var button in root.GetComponentsInChildren<Button>(true))
                    {
                        var labels = button.GetComponentsInChildren<TMPro.TMP_Text>(true);
                        // Keep the existing submit artwork, but lift its bottom edge into the frame.
                        if (labels.Any(t => t.text.Trim() == "HANTAR") && button.name == "Next")
                        {
                            var rect = (RectTransform)button.transform;
                            if (rect.anchoredPosition.y < -480)
                            {
                                rect.anchoredPosition += new Vector2(0, 32);
                                changed = true;
                            }
                        }
                    }
                }
                if (changed) { EditorSceneManager.MarkSceneDirty(scene); EditorSceneManager.SaveScene(scene); updated++; }
            }
            finally { EditorSceneManager.CloseScene(scene, true); }
        }
        return updated;
    }

    public static void ArrangeActivityMenu()
    {
        var path = "Assets/Scenes/MainMenuAktiviti.unity";
        var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
        try
        {
            var body = scene.GetRootGameObjects().SelectMany(g => g.GetComponentsInChildren<RectTransform>(true))
                .Single(t => t.name == "body" && t.parent.name == "aktivitiControler");
            var vertical = body.GetComponent<VerticalLayoutGroup>();
            if (vertical != null) Object.DestroyImmediate(vertical);
            var grid = body.GetComponent<GridLayoutGroup>();
            if (grid == null) grid = body.gameObject.AddComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 2;
            grid.cellSize = new Vector2(400, 140);
            grid.spacing = new Vector2(40, 24);
            grid.childAlignment = TextAnchor.MiddleCenter;
            grid.padding = new RectOffset(30, 30, 28, 28);
            string[] topics = { "Sistem Pencernaan", "Karbohidrat", "Protein", "Lipid", "Tenaga Makanan", "Vitamin C", "Suhu dan Vitamin C", "Pemakanan Sihat" };
            for (int i = 0; i < 8; i++)
            {
                var button = body.GetChild(i).GetComponentInChildren<Button>(true);
                var label = button.GetComponentInChildren<TMPro.TMP_Text>(true);
                label.text = "AKTIVITI " + (i + 1) + "\n<size=65%>" + topics[i] + "</size>";
                label.fontSize = 36;
                label.enableAutoSizing = false;
                var rect = (RectTransform)button.transform;
                rect.sizeDelta = new Vector2(390, 110);
                var navigation = button.navigation;
                navigation.mode = Navigation.Mode.Explicit;
                navigation.selectOnLeft = i % 2 == 1 ? body.GetChild(i - 1).GetComponentInChildren<Button>(true) : null;
                navigation.selectOnRight = i % 2 == 0 ? body.GetChild(i + 1).GetComponentInChildren<Button>(true) : null;
                navigation.selectOnUp = i >= 2 ? body.GetChild(i - 2).GetComponentInChildren<Button>(true) : null;
                navigation.selectOnDown = i < 6 ? body.GetChild(i + 2).GetComponentInChildren<Button>(true) : null;
                button.navigation = navigation;
            }
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
        }
        finally { EditorSceneManager.CloseScene(scene, true); }
    }
}
