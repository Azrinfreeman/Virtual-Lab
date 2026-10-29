using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonReactionController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    bool confirming, focused, hovered;
    Animator animator;
    void Awake() => animator = GetComponent<Animator>();
    void Start()
    {
        if (button == null) button = GetComponentInChildren<Button>(true);
        if (button != null) button.onClick.AddListener(Confirm);
    }
    void OnEnable() => BioMotion.Changed += Refresh;
    void Confirm()
    {
        if (!confirming && !BioMotion.Reduced && transform.childCount > 2)
            StartCoroutine(ConfirmPlay());
    }
    IEnumerator ConfirmPlay()
    {
        confirming = true;
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(.2f);
        transform.GetChild(2).gameObject.SetActive(false);
        confirming = false;
    }
    public void SetFocus(bool value)
    {
        if (focused == value) return;
        focused = value;
        Refresh();
    }
    void Refresh()
    {
        if (animator == null || !animator.isActiveAndEnabled) return;
        animator.Play(!BioMotion.Reduced && (hovered || focused) ? "hover" : "idle");
        if (BioMotion.Reduced)
        {
            animator.Update(0);
            if (transform.childCount > 2) transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData e) { hovered = true; Refresh(); }
    public void OnPointerExit(PointerEventData e) { hovered = false; Refresh(); }
    void OnDisable()
    {
        BioMotion.Changed -= Refresh;
        StopAllCoroutines();
        confirming = focused = hovered = false;
        if (transform.childCount > 2) transform.GetChild(2).gameObject.SetActive(false);
    }
    void OnDestroy() { if (button != null) button.onClick.RemoveListener(Confirm); }
}
