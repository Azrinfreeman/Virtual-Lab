using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustUIPosition : MonoBehaviour
{
    public RectTransform uiElement;

    private bool isVisible;

    void Start()
    {
        isVisible = gameObject.activeInHierarchy;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy != isVisible)
        {
            isVisible = gameObject.activeInHierarchy;
            if (isVisible)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                uiElement.anchoredPosition = new Vector2(screenPos.x, screenPos.y);
            }
        }
    }
}