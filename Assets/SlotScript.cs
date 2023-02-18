using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SlotScript : MonoBehaviour, IDropHandler
{

   
    [Header("Variables")]
    public bool fish;

    public Transform[] image;

    [SerializeField] BoxCollider2D itemInsertedCol;
    [SerializeField] bool isItemInserted;

    private AudioSource slotInsertedSound;
    // Start is called before the first frame update
    void Start()
    {
        slotInsertedSound = GameObject.Find("SlotInserted").GetComponent<AudioSource>();
        itemInsertedCol = GetComponent<BoxCollider2D>();

        image = new Transform[2];

        image[0] = transform.GetChild(0).transform.GetComponent<Transform>();
        image[1] = transform.GetChild(1).transform.GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");


        if (eventData.pointerDrag != null)
        {
           

                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                if (!slotInsertedSound.isPlaying)
                {
                    slotInsertedSound.Play();
                  
                }

                eventData.pointerDrag.GetComponent<BoxCollider2D>().enabled = false;
                eventData.pointerDrag.gameObject.SetActive(false);
                image[0].gameObject.SetActive(false);
                image[1].gameObject.SetActive(true);
        }
    }
}
