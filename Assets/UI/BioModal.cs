using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class BioModal : MonoBehaviour
{
    static readonly List<BioModal> Stack = new List<BioModal>();
    public Button cancelButton;
    public Selectable initialControl;
    public Canvas modalCanvas;
    public CanvasGroup screenGroup;
    static readonly Dictionary<CanvasGroup, bool[]> ScreenStates = new Dictionary<CanvasGroup, bool[]>();
    CanvasGroup group;
    GameObject previousFocus;
    bool open, closing;
    public static bool HasOpenModal { get { Prune(); return Stack.Count != 0; } }
    public bool IsOpen => open;
    public static bool Allows(Transform target)
    {
        Prune();
        return Stack.Count == 0 || target == Stack[Stack.Count - 1].transform ||
            target.IsChildOf(Stack[Stack.Count - 1].transform);
    }
    static void Prune() => Stack.RemoveAll(m => m == null || !m.isActiveAndEnabled || !m.open);

    public void BeginOpen()
    {
        if (group == null) group = GetComponent<CanvasGroup>();
        if (!open) previousFocus = EventSystem.current == null ? null : EventSystem.current.currentSelectedGameObject;
        Stack.Remove(this);
        Stack.Add(this);
        open = true;
        closing = false;
        group.interactable = group.blocksRaycasts = true;
        group.ignoreParentGroups = true;
        if (screenGroup != null && screenGroup != group)
        {
            if (!ScreenStates.ContainsKey(screenGroup))
                ScreenStates[screenGroup] = new[] { screenGroup.interactable, screenGroup.blocksRaycasts };
            screenGroup.interactable = screenGroup.blocksRaycasts = false;
        }
        RefreshOrder();
        FocusFirst();
    }
    public void BeginClose()
    {
        closing = true;
        if (group != null) group.interactable = false;
    }
    public void CompleteClose()
    {
        if (!open) return;
        open = false;
        closing = false;
        Stack.Remove(this);
        RefreshOrder();
        if (group != null) group.interactable = group.blocksRaycasts = false;
        if (screenGroup != null && screenGroup != group && !Stack.Any(m => m != null && m.open && m.screenGroup == screenGroup) &&
            ScreenStates.TryGetValue(screenGroup, out var previous))
        {
            screenGroup.interactable = previous[0];
            screenGroup.blocksRaycasts = previous[1];
            ScreenStates.Remove(screenGroup);
        }
        if (EventSystem.current == null) return;
        Prune();
        if (Stack.Count > 0) Stack[Stack.Count - 1].FocusFirst();
        else if (previousFocus != null && previousFocus.activeInHierarchy)
            EventSystem.current.SetSelectedGameObject(previousFocus);
        else EventSystem.current.SetSelectedGameObject(null);
    }
    void FocusFirst()
    {
        if (EventSystem.current == null) return;
        var first = initialControl != null && initialControl.IsActive() && initialControl.IsInteractable()
            ? initialControl : GetComponentsInChildren<Selectable>().FirstOrDefault(s=>s.IsActive() && s.IsInteractable());
        if (first != null) EventSystem.current.SetSelectedGameObject(first.gameObject);
    }
    static void RefreshOrder()
    {
        for (int i=0;i<Stack.Count;i++)
            if (Stack[i] != null && Stack[i].modalCanvas != null) Stack[i].modalCanvas.sortingOrder = 201+i;
    }
    void LateUpdate()
    {
        if (!open || !Allows(transform)) return;
        var system = EventSystem.current;
        if (system != null && (system.currentSelectedGameObject == null ||
            !system.currentSelectedGameObject.transform.IsChildOf(transform))) FocusFirst();
        // Only a reviewed cancel action may handle Back. Never guess the affirmative button.
        if (!closing && cancelButton != null && cancelButton.IsActive() && cancelButton.IsInteractable() &&
            Input.GetButtonDown("Cancel")) cancelButton.onClick.Invoke();
    }
    void OnDisable() => CompleteClose();
}
