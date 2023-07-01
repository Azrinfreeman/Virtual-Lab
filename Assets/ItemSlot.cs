using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string answerStore;
    public AudioSource slotInsertedAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("drop");
        //scene 3.4
        if (SceneManager.GetActiveScene().name == "3.4")
        {

            if (eventData.pointerDrag.tag == "temprotein")
            {
                eventData.pointerDrag.tag = "protein";
            }
            else if (eventData.pointerDrag.tag == "tempair")
            {
                eventData.pointerDrag.tag = "air";
            }
            else if (eventData.pointerDrag.tag == "temppolipeptida")
            {
                eventData.pointerDrag.tag = "polipeptida";
            }
            answerStore = eventData.pointerDrag.GetComponent<DragScript>().Answer;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        //scene 4.4
        else if (SceneManager.GetActiveScene().name == "2.4")
        {

            if (eventData.pointerDrag.tag == "tempButton1")
            {
                eventData.pointerDrag.tag = "button1";
            }
            else if (eventData.pointerDrag.tag == "tempButton2")
            {
                eventData.pointerDrag.tag = "button2";
            }
            else if (eventData.pointerDrag.tag == "tempButton3")
            {
                eventData.pointerDrag.tag = "button3";
            }
            else if (eventData.pointerDrag.tag == "tempButton4")
            {
                eventData.pointerDrag.tag = "button4";
            }
            answerStore = eventData.pointerDrag.GetComponent<DragScript>().Answer;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        else if (SceneManager.GetActiveScene().name == "4.4" || SceneManager.GetActiveScene().name == "7.4")
        {
            if (eventData.pointerDrag.tag == "temps1")
            {
                eventData.pointerDrag.tag = "s1";
            }
            else if (eventData.pointerDrag.tag == "temps2")
            {
                eventData.pointerDrag.tag = "s2";
            }
            else if (eventData.pointerDrag.tag == "temps3")
            {
                eventData.pointerDrag.tag = "s3";
            }
            else if (eventData.pointerDrag.tag == "temps4")
            {
                eventData.pointerDrag.tag = "s4";
            }
            else if (eventData.pointerDrag.tag == "temps5")
            {
                eventData.pointerDrag.tag = "s5";
            }
            else if (eventData.pointerDrag.tag == "temps6")
            {
                eventData.pointerDrag.tag = "s6";
            }
            else if (eventData.pointerDrag.tag == "temps7")
            {
                eventData.pointerDrag.tag = "s7";
            }
            else if (eventData.pointerDrag.tag == "temps8")
            {
                eventData.pointerDrag.tag = "s8";
            }
            else if (eventData.pointerDrag.tag == "temps9")
            {
                eventData.pointerDrag.tag = "s9";
            }
            else if (eventData.pointerDrag.tag == "temps10")
            {
                eventData.pointerDrag.tag = "s10";
            }

            //set pivot 
            eventData.pointerDrag.transform.SetParent(transform);

            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (answerStore.ToUpper() == transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.ToUpper())
            {

                KuizController.instance.soalanAnswer[int.Parse(transform.parent.transform.parent.name) - 1] = true;
            }
            else
            {
                KuizController.instance.soalanAnswer[int.Parse(transform.parent.transform.parent.name) - 1] = false;
            }


        }
        else if (SceneManager.GetActiveScene().name == "8.1")
        {
            //set pivot 
            if (eventData.pointerDrag.tag != "Untagged")
            {


                if (!slotInsertedAudio.isPlaying)
                {
                    slotInsertedAudio.Play();
                }
                if (eventData.pointerDrag.tag == "temps1")
                {
                    eventData.pointerDrag.tag = "s1";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();

                }
                else if (eventData.pointerDrag.tag == "temps2")
                {
                    eventData.pointerDrag.tag = "s2";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps3")
                {
                    eventData.pointerDrag.tag = "s3";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps4")
                {
                    eventData.pointerDrag.tag = "s4";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps5")
                {
                    eventData.pointerDrag.tag = "s5";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps6")
                {
                    eventData.pointerDrag.tag = "s6";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps7")
                {
                    eventData.pointerDrag.tag = "s7";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                GetComponent<PiramidJawapan>().jawapanName = eventData.pointerDrag.transform.name;

            }
            else
            {
                return;
            }

        }
        else if (SceneManager.GetActiveScene().name == "8.2")
        {
            if (!slotInsertedAudio.isPlaying)
            {
                slotInsertedAudio.Play();
            }
            if (eventData.pointerDrag.tag == "temps1")
            {
                eventData.pointerDrag.tag = "s1";
            }
            else if (eventData.pointerDrag.tag == "temps2")
            {
                eventData.pointerDrag.tag = "s2";
            }
            else if (eventData.pointerDrag.tag == "temps3")
            {
                eventData.pointerDrag.tag = "s3";
            }
            else if (eventData.pointerDrag.tag == "temps4")
            {
                eventData.pointerDrag.tag = "s4";
            }
            else if (eventData.pointerDrag.tag == "temps5")
            {
                eventData.pointerDrag.tag = "s5";
            }
            else if (eventData.pointerDrag.tag == "temps6")
            {
                eventData.pointerDrag.tag = "s6";
            }
            else if (eventData.pointerDrag.tag == "temps7")
            {
                eventData.pointerDrag.tag = "s7";
            }
            else if (eventData.pointerDrag.tag == "temps8")
            {
                eventData.pointerDrag.tag = "s8";
            }
            else if (eventData.pointerDrag.tag == "temps9")
            {
                eventData.pointerDrag.tag = "s9";
            }
            else if (eventData.pointerDrag.tag == "temps10")
            {
                eventData.pointerDrag.tag = "s10";
            }

            GetComponent<PingganName>().plateName = eventData.pointerDrag.transform.name;



            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

        }




    }
}
