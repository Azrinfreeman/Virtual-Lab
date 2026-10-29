using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,
    IEndDragHandler, IDragHandler, IPointerClickHandler, ISubmitHandler, ICancelHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] BoxCollider2D colider;
    public List<GameObject> slots;
    public string Answer;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Transform dragOriginParent;
    Vector2 dragOriginPosition, originAnchorMin, originAnchorMax, originPivot;
    int dragOriginIndex;
    float restAlpha;
    bool restRaycasts, dragging, accepted, bridge;
    Coroutine returning;
    public ItemSlot CurrentSlot { get; private set; }
    public static DragScript PickedItem { get; private set; }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }
    void BeginPickup()
    {
        bool resumingReturn = returning != null;
        if (returning != null) { StopCoroutine(returning); returning = null; }
        if (dragging) return;
        if (!resumingReturn)
        {
            dragOriginParent = transform.parent;
            dragOriginPosition = rectTransform.anchoredPosition;
            dragOriginIndex = transform.GetSiblingIndex();
            originAnchorMin = rectTransform.anchorMin;
            originAnchorMax = rectTransform.anchorMax;
            originPivot = rectTransform.pivot;
        }
        restAlpha = canvasGroup.alpha;
        restRaycasts = canvasGroup.blocksRaycasts;
        dragging = true;
        accepted = false;
        bridge = tag == "bridge";
        SetBridgeSlots(false);
        canvasGroup.alpha = .72f;
    }
    public void OnBeginDrag(PointerEventData e)
    {
        if (!BioModal.Allows(transform)) return;
        if (PickedItem != null && PickedItem != this) PickedItem.FinishPickup();
        if (PickedItem == this) PickedItem = null;
        BeginPickup();
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData e)
    {
        if (!dragging || !BioModal.Allows(transform)) return;
        var parent = transform.parent as RectTransform;
        if (parent == null) return;
        // Convert screen motion into the actual parent canvas, including nested transforms.
        Vector2 from, to;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, e.position - e.delta, e.pressEventCamera, out from) &&
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, e.position, e.pressEventCamera, out to))
            rectTransform.anchoredPosition += to - from;
    }
    public void Accept(ItemSlot slot) { CurrentSlot = slot; accepted = true; }
    public void OnEndDrag(PointerEventData e) => FinishPickup();
    public void FinishPickup()
    {
        if (!dragging) return;
        if (PickedItem == this) PickedItem = null;
        dragging = false;
        SetBridgeSlots(true);
        canvasGroup.alpha = restAlpha;
        canvasGroup.blocksRaycasts = restRaycasts;
        if (accepted) return;
        Vector3 world = rectTransform.position;
        transform.SetParent(dragOriginParent, false);
        transform.SetSiblingIndex(dragOriginIndex);
        rectTransform.anchorMin = originAnchorMin;
        rectTransform.anchorMax = originAnchorMax;
        rectTransform.pivot = originPivot;
        if (BioMotion.Reduced || !Application.isPlaying || !isActiveAndEnabled)
            rectTransform.anchoredPosition = dragOriginPosition;
        else
        {
            rectTransform.position = world;
            returning = StartCoroutine(ReturnHome());
        }
    }
    IEnumerator ReturnHome()
    {
        Vector2 from = rectTransform.anchoredPosition;
        for (float t = 0; t < .16f; t += Time.unscaledDeltaTime)
        {
            rectTransform.anchoredPosition = Vector2.LerpUnclamped(from, dragOriginPosition, BioMotion.Ease(t / .16f));
            yield return null;
        }
        rectTransform.anchoredPosition = dragOriginPosition;
        returning = null;
    }
    void SetBridgeSlots(bool value)
    {
        if (!bridge || slots == null) return;
        foreach (var slot in slots) if (slot != null) slot.SetActive(value);
    }
    void Pick()
    {
        if (!BioModal.Allows(transform)) return;
        if (PickedItem == this) { FinishPickup(); return; }
        if (PickedItem != null) PickedItem.FinishPickup();
        BeginPickup();
        PickedItem = this;
    }
    public void OnPointerDown(PointerEventData e) { }
    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left && !e.dragging) Pick();
    }
    public void OnSubmit(BaseEventData e) => Pick();
    public void OnCancel(BaseEventData e) => FinishPickup();
    void OnDisable()
    {
        if (returning != null)
        {
            StopCoroutine(returning);
            rectTransform.anchoredPosition = dragOriginPosition;
        }
        returning = null;
        if (dragging)
        {
            dragging = false;
            SetBridgeSlots(true);
            if (canvasGroup != null) { canvasGroup.alpha = restAlpha; canvasGroup.blocksRaycasts = restRaycasts; }
            if (!accepted && dragOriginParent != null)
            {
                transform.SetParent(dragOriginParent, false);
                transform.SetSiblingIndex(dragOriginIndex);
                rectTransform.anchorMin = originAnchorMin; rectTransform.anchorMax = originAnchorMax;
                rectTransform.pivot = originPivot; rectTransform.anchoredPosition = dragOriginPosition;
            }
        }
        if (PickedItem == this) PickedItem = null;
    }
    void OnDestroy() { if (CurrentSlot != null) CurrentSlot.Release(this); }
}
