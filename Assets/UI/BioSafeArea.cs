using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class BioSafeArea : MonoBehaviour
{
    RectTransform rect;
    Rect lastArea;
    Vector2Int lastSize;
    Vector2 originalMin, originalMax;
    public static Rect Normalize(Rect area, Vector2Int size)
    {
        if (size.x <= 0 || size.y <= 0) return new Rect(0,0,1,1);
        float left=Mathf.Clamp(area.xMin,0,size.x), right=Mathf.Clamp(area.xMax,0,size.x);
        float bottom=Mathf.Clamp(area.yMin,0,size.y), top=Mathf.Clamp(area.yMax,0,size.y);
        if (right<=left || top<=bottom) return new Rect(0,0,1,1);
        return Rect.MinMaxRect(left/size.x,bottom/size.y,right/size.x,top/size.y);
    }
    void Awake()
    {
        rect = (RectTransform)transform;
        originalMin = rect.anchorMin;
        originalMax = rect.anchorMax;
    }
    void Update()
    {
        var size = new Vector2Int(Screen.width, Screen.height);
        var area = Screen.safeArea;
        if (size == lastSize && area == lastArea) return;
        lastSize = size; lastArea = area;
        if (size.x <= 0 || size.y <= 0) return;
        var normalized=Normalize(area,size);
        Vector2 min = normalized.min;
        Vector2 max = normalized.max;
        rect.anchorMin = min + Vector2.Scale(originalMin, max - min);
        rect.anchorMax = min + Vector2.Scale(originalMax, max - min);
    }
}
