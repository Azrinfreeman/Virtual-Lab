using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BioScreenFocus : MonoBehaviour
{
    public Selectable defaultControl;
    IEnumerator Start()
    {
        yield return null;
        if (EventSystem.current == null || BioModal.HasOpenModal) yield break;
        if (EventSystem.current.currentSelectedGameObject != null) yield break;
        if (defaultControl != null && defaultControl.IsActive() && defaultControl.IsInteractable())
            EventSystem.current.SetSelectedGameObject(defaultControl.gameObject);
    }
}
