using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BioSceneTransition : MonoBehaviour
{
    static BioSceneTransition active;
    CanvasGroup group;
    public static bool Load(string scene)
    {
        if (active != null || !Application.CanStreamedLevelBeLoaded(scene)) return false;
        var go = new GameObject("Scene transition", typeof(Canvas), typeof(CanvasGroup), typeof(GraphicRaycaster));
        DontDestroyOnLoad(go);
        var canvas = go.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = short.MaxValue;
        var background = new GameObject("Fade", typeof(RectTransform), typeof(Image));
        background.transform.SetParent(go.transform, false);
        var rect = (RectTransform)background.transform;
        rect.anchorMin = Vector2.zero; rect.anchorMax = Vector2.one;
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        background.GetComponent<Image>().color = BioPalette.SurfaceBase;
        active = go.AddComponent<BioSceneTransition>();
        active.group = go.GetComponent<CanvasGroup>();
        active.group.alpha = 0;
        active.StartCoroutine(active.Run(scene));
        return true;
    }
    IEnumerator Run(string scene)
    {
        yield return Fade(1, .12f);
        AsyncOperation operation = null;
        try { operation = SceneManager.LoadSceneAsync(scene); }
        catch (Exception error) { Debug.LogError("Tidak dapat membuka aktiviti: " + error.Message); }
        GameObject loading = null;
        float elapsed = 0;
        while (operation != null && !operation.isDone)
        {
            elapsed += Time.unscaledDeltaTime;
            if (loading == null && elapsed > .4f)
            {
                loading = new GameObject("Loading", typeof(RectTransform), typeof(TextMeshProUGUI));
                loading.transform.SetParent(transform,false);
                var rect = (RectTransform)loading.transform;
                rect.anchorMin = rect.anchorMax = rect.pivot = new Vector2(.5f,.5f);
                rect.sizeDelta = new Vector2(600,100);
                var label = loading.GetComponent<TextMeshProUGUI>();
                label.fontSize = 32; label.alignment = TextAlignmentOptions.Center;
                label.color = BioPalette.TextPrimary; label.text = "Memuatkan...";
                label.raycastTarget = false;
            }
            yield return null;
        }
        if (loading != null) loading.SetActive(false);
        yield return Fade(0, .16f);
        Destroy(gameObject);
    }
    IEnumerator Fade(float target, float duration)
    {
        float from = group.alpha;
        if (!BioMotion.Reduced) for (float t = 0; t < duration; t += Time.unscaledDeltaTime)
        {
            group.alpha = Mathf.Lerp(from, target, BioMotion.Ease(t / duration));
            yield return null;
        }
        group.alpha = target;
    }
    void OnDestroy() { if (active == this) active = null; }
}
