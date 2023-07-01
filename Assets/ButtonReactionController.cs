using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonReactionController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(0).GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            StartCoroutine(confirmPlay());
        });
    }
    IEnumerator confirmPlay()
    {
        transform.GetChild(2).GetComponent<Transform>().gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(2).GetComponent<Transform>().gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animator>().Play("hover");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Animator>().Play("idle");
    }
}
