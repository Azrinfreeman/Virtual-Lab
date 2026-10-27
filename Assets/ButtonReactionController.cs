using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonReactionController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    private bool confirming;
    private bool focused;
    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(0).GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (!confirming) StartCoroutine(confirmPlay());
        });
    }
    IEnumerator confirmPlay()
    {
        confirming = true;
        transform.GetChild(2).GetComponent<Transform>().gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(2).GetComponent<Transform>().gameObject.SetActive(false);
        confirming = false;


    }

    // Update is called once per frame
    void Update()
    {
        bool selected = EventSystem.current != null && button != null &&
            EventSystem.current.currentSelectedGameObject == button.gameObject;
        if (selected != focused)
        {
            focused = selected;
            GetComponent<Animator>().Play(focused ? "hover" : "idle");
        }
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().Play("hover");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (!focused) GetComponent<Animator>().Play("idle");
    }
    void OnDisable()
    {
        StopAllCoroutines();
        confirming = false;
        focused = false;
        if (transform.childCount > 2) transform.GetChild(2).gameObject.SetActive(false);
    }
}
