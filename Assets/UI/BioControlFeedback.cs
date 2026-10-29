using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class BioControlFeedback : MonoBehaviour, ISelectHandler, IDeselectHandler,
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEngine.UI.Outline focusOutline;
    // Assigned only when the editor audit finds no Animator/layout owner for this transform.
    public RectTransform motionTarget;
    Selectable control;
    ButtonReactionController reaction;
    Vector3 restScale;
    bool focused, hovered, pressed;
    Coroutine motion;

    void Awake()
    {
        control = GetComponent<Selectable>();
        reaction = GetComponentInParent<ButtonReactionController>();
        if (motionTarget != null) restScale = motionTarget.localScale;
    }
    void OnEnable() => BioMotion.Changed += Refresh;
    void OnDisable()
    {
        BioMotion.Changed -= Refresh;
        if (motion != null) StopCoroutine(motion);
        motion = null;
        if (motionTarget != null) motionTarget.localScale = restScale;
        if (focusOutline != null) focusOutline.enabled = false;
        focused = hovered = pressed = false;
        if (reaction != null) reaction.SetFocus(false);
    }
    public void OnSelect(BaseEventData e) { focused = true; Refresh(); }
    public void OnDeselect(BaseEventData e) { focused = false; pressed = false; Refresh(); }
    public void OnPointerEnter(PointerEventData e) { hovered = true; Refresh(); }
    public void OnPointerExit(PointerEventData e) { hovered = false; pressed = false; Refresh(); }
    public void OnPointerDown(PointerEventData e)
    {
        if (e.button != PointerEventData.InputButton.Left) return;
        pressed = true; Refresh();
    }
    public void OnPointerUp(PointerEventData e) { pressed = false; Refresh(); }

    void Refresh()
    {
        if (control == null) return;
        bool interactive = control.IsInteractable();
        if (focusOutline != null) focusOutline.enabled = focused && interactive;
        if (reaction != null) reaction.SetFocus(focused && interactive);
        if (motionTarget == null) return;
        if (motion != null) StopCoroutine(motion);
        float factor = !interactive || BioMotion.Reduced ? 1f : pressed ? .98f : hovered || focused ? 1.02f : 1f;
        if (BioMotion.Reduced) { motionTarget.localScale = restScale; motion = null; }
        else motion = StartCoroutine(Animate(restScale * factor, pressed ? .07f : .12f));
    }
    IEnumerator Animate(Vector3 target, float duration)
    {
        Vector3 from = motionTarget.localScale;
        for (float t = 0; t < duration; t += Time.unscaledDeltaTime)
        {
            motionTarget.localScale = Vector3.LerpUnclamped(from, target, BioMotion.Ease(t / duration));
            yield return null;
        }
        motionTarget.localScale = target;
        motion = null;
    }
}
