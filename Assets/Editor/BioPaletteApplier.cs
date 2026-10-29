using System.Linq;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Idempotent pass that moves legacy ad-hoc colours onto BioPalette tokens.
/// Only recognised legacy values are rewritten, so running it twice changes nothing the second time.
/// Names, hierarchy and references are untouched. Tools > BioNutri > Apply Palette.
/// </summary>
public static class BioPaletteApplier
{
    static int buttons, texts, images;

    [MenuItem("Tools/BioNutri/Apply Palette")]
    public static void ApplyAll()
    {
        buttons = texts = images = 0;
        var scenePaths = AssetDatabase.FindAssets("t:Scene", new[] { "Assets/Scenes" }).Select(AssetDatabase.GUIDToAssetPath).ToArray();
        foreach (var path in scenePaths)
        {
            var scene = EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
            int before = buttons + texts + images;
            foreach (var root in scene.GetRootGameObjects()) Apply(root);
            if (buttons + texts + images != before) EditorSceneManager.SaveScene(scene);
        }
        foreach (var guid in AssetDatabase.FindAssets("t:Prefab", new[] { "Assets/prefabs", "Assets/Scenes/prefabs" }))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var root = PrefabUtility.LoadPrefabContents(path);
            int before = buttons + texts + images;
            Apply(root);
            if (buttons + texts + images != before) PrefabUtility.SaveAsPrefabAsset(root, path);
            PrefabUtility.UnloadPrefabContents(root);
        }
        AssetDatabase.SaveAssets();
        Debug.Log($"[BioPalette] buttons={buttons} texts={texts} images={images}");
    }

    static void Apply(GameObject root)
    {
        foreach (var b in root.GetComponentsInChildren<Button>(true))
        {
            if (b.transition != Selectable.Transition.ColorTint) continue;
            b.colors = BioPalette.ActionColors();
            EditorUtility.SetDirty(b);
            buttons++;
            // Flat built-in pill buttons (white UISprite) with a text label were white-on-white or yellow-on-white:
            // promote them to the primary action style so the label is readable.
            // Gradient "button2" sprite: darken with a tint so white labels reach contrast; green/blue label colours were
            // decorative (and green wrongly implied success on Masuk).
            if (b.targetGraphic is Image grad && grad.sprite != null && grad.sprite.name == "button2"
                && b.GetComponentInChildren<TMP_Text>(true) is TMP_Text gl && !string.IsNullOrWhiteSpace(gl.text))
            {
                grad.color = new Color(0.40f, 0.58f, 0.80f, 1f);
                gl.color = BioPalette.TextPrimary;
                EditorUtility.SetDirty(grad); EditorUtility.SetDirty(gl);
                texts++;
            }
            // Quiz options: neutral "choice" surface so the violet selected state (ButtonAnswers) is the only highlight.
            else if (b.targetGraphic is Image choice && b.GetComponentInParent<ButtonAnswers>(true) != null
                && b.GetComponentInChildren<TMP_Text>(true) is TMP_Text cl)
            {
                choice.color = new Color(0.93f, 0.92f, 0.98f, 1f);
                cl.color = BioPalette.InkPrimary;
                EditorUtility.SetDirty(choice); EditorUtility.SetDirty(cl);
                texts++;
            }
            else if (b.targetGraphic is Image img && img.sprite != null && img.sprite.name == "UISprite"
                && b.GetComponentInChildren<TMP_Text>(true) is TMP_Text label && !string.IsNullOrWhiteSpace(label.text))
            {
                img.color = BioPalette.ActionPrimary;
                label.color = BioPalette.TextPrimary;
                EditorUtility.SetDirty(img); EditorUtility.SetDirty(label);
                texts++;
            }
        }
        foreach (var t in root.GetComponentsInChildren<TMP_Text>(true))
        {
            var c = t.color;
            Color? n = MapText(c);
            if (n.HasValue) { t.color = n.Value; EditorUtility.SetDirty(t); texts++; }
        }
        foreach (var i in root.GetComponentsInChildren<Image>(true))
        {
            Color? n = MapImage(i.color);
            if (n.HasValue) { i.color = n.Value; EditorUtility.SetDirty(i); images++; }
        }
        foreach (var lc in root.GetComponentsInChildren<LoginController>(true))
        {
            if (lc.errorText && lc.errorText.TryGetComponent<TMP_Text>(out var et) && et.color != BioPalette.Error)
            { et.color = BioPalette.Error; EditorUtility.SetDirty(et); texts++; }
        }
    }

    static bool Near(float a, float b) => Mathf.Abs(a - b) < 0.02f;
    static bool Near(Color a, float r, float g, float bl) => Near(a.r, r) && Near(a.g, g) && Near(a.b, bl);

    static Color? MapText(Color c)
    {
        float a = c.a;
        // Near-black / dark grey and the old dark blue -> ink on paper
        bool neutralDark = Mathf.Abs(c.r - c.g) < 0.01f && Mathf.Abs(c.g - c.b) < 0.01f && c.r < 0.35f;
        bool oldBlue = Near(c, 0.0575f, 0.2448f, 0.7170f);
        if (neutralDark || oldBlue)
            return a < 0.99f ? Alpha(BioPalette.InkPlaceholder, 1f) : BioPalette.InkPrimary;
        // Light-blue titles -> info
        if (Near(c, 0.3726f, 0.7799f, 1f)) return BioPalette.Info;
        // Yellow/amber headings (warning hue used decoratively) -> info
        if (c.r > 0.9f && c.g > 0.78f && c.b < 0.5f) return Alpha(BioPalette.Info, a);
        return null;
    }

    static Color? MapImage(Color c)
    {
        // Mustard worksheet panels -> paper
        if (c.r > 0.8f && c.g > 0.72f && c.b < 0.08f && c.a > 0.99f) return BioPalette.SurfacePaper;
        // Translucent brown-grey overlay panels -> overlay surface
        if (Near(c, 0.2736f, 0.2104f, 0.2104f) && c.a < 0.5f) return Alpha(BioPalette.SurfaceOverlay, 0.92f);
        return null;
    }

    static Color Alpha(Color c, float a) { c.a = a; return c; }
}
