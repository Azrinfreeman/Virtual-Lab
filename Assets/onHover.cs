using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        transform.parent.GetComponent<Animator>().Play("hover");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        transform.parent.GetComponent<Animator>().Play("idle");
    }
}
