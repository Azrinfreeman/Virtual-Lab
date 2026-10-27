using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private BoxCollider2D colider;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("4 slots")]
    public List<GameObject> slots;

    public string Answer;
    private Transform dragOriginParent;
    private Vector2 dragOriginPosition;
    private int dragOriginIndex;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        colider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOriginParent = transform.parent;
        dragOriginPosition = rectTransform.anchoredPosition;
        dragOriginIndex = transform.GetSiblingIndex();
        Debug.Log("drag");
        if (eventData.pointerDrag.tag == "bridge")
        {
            Debug.Log("asfasf");
            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].SetActive(false);
            }
        }
        //  Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;



    }

    public void OnDrag(PointerEventData eventData)
    {


        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Dropping outside an answer slot must not strand an answer off screen.
        if (eventData.pointerEnter == null ||
            eventData.pointerEnter.GetComponentInParent<ItemSlot>() == null)
        {
            transform.SetParent(dragOriginParent, false);
            transform.SetSiblingIndex(dragOriginIndex);
            rectTransform.anchoredPosition = dragOriginPosition;
        }
        if (eventData.pointerDrag.tag == "bridge")
        {

            for (int i = 0; i < slots.Count; i++)
            {
                slots[i].SetActive(true);
            }
        }
        //   Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;



    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //    Debug.Log("OnPointerDown");
    }


}
