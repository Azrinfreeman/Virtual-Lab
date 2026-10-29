using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerClickHandler, ISubmitHandler
{
    public DragScript Occupant { get; private set; }
    public bool CanAccept(DragScript item)
    {
        if (item == null || !BioModal.Allows(transform) || !item.isActiveAndEnabled ||
            (Occupant != null && Occupant != item)) return false;
        string scene = gameObject.scene.name;
        if (scene == "2.4" || scene == "3.4" || scene == "5.4" || scene == "8.2") return true;
        if (scene == "4.4" || scene == "7.4") return item.tag != "panel";
        return scene == "8.1" && item.tag != "Untagged";
    }
    public bool TryPlace(DragScript item)
    {
        if (!CanAccept(item) || EventSystem.current == null) return false;
        OnDrop(new PointerEventData(EventSystem.current) { pointerDrag = item.gameObject });
        return Occupant == item;
    }
    public void Release(DragScript item)
    {
        if (Occupant != item) return;
        Occupant = null;
        string scene = gameObject.scene.name;
        if (scene == "2.4" || scene == "3.4" || scene == "5.4") answerStore = "";
        var pyramid = GetComponent<PiramidJawapan>();
        if (pyramid != null) pyramid.jawapanName = "";
        var plate = GetComponent<PingganName>();
        if (plate != null) plate.plateName = "";
        int question;
        if ((scene == "4.4" || scene == "7.4") && KuizController.instance != null &&
            transform.parent != null && transform.parent.parent != null &&
            int.TryParse(transform.parent.parent.name, out question) && question > 0 &&
            KuizController.instance.soalanAnswer != null && question <= KuizController.instance.soalanAnswer.Length)
            KuizController.instance.soalanAnswer[question-1] = false;
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left) PlacePickedItem();
    }
    public void OnSubmit(BaseEventData e) => PlacePickedItem();
    void PlacePickedItem()
    {
        var item = DragScript.PickedItem;
        if (item == null) return;
        TryPlace(item);
        item.FinishPickup();
    }
    public string answerStore;

    public string answerStore2;
    public AudioSource slotInsertedAudio;

    // Start is called before the first frame update
    void Start()
    {
        var audioObject = GameObject.Find("SlotInserted");
        if (audioObject != null) slotInsertedAudio = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() { }

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag == null ? null : eventData.pointerDrag.GetComponent<DragScript>();
        if (!CanAccept(item)) return;
        //scene 3.4
        if (gameObject.scene.name == "3.4")
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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
        //scene 4.4
        else if (gameObject.scene.name == "2.4")
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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
        else if (
            gameObject.scene.name == "4.4"
            && eventData.pointerDrag.tag != "panel"
        )
        {
            if (slotInsertedAudio != null && !slotInsertedAudio.isPlaying)
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

            //set pivot
            eventData.pointerDrag.transform.SetParent(transform);

            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;

            if (
                answerStore.ToUpper()
                == transform
                    .GetChild(0)
                    .transform
                    .GetChild(0)
                    .GetComponent<TextMeshProUGUI>()
                    .text
                    .ToUpper()
            )
            {
                KuizController.instance.soalanAnswer[
                    int.Parse(transform.parent.transform.parent.name) - 1
                ] = true;
            }
            else
            {
                KuizController.instance.soalanAnswer[
                    int.Parse(transform.parent.transform.parent.name) - 1
                ] = false;
            }
        }
        else if (gameObject.scene.name == "5.4")
        {
            if (slotInsertedAudio != null && !slotInsertedAudio.isPlaying)
            {
                slotInsertedAudio.Play();
            } //set pivot
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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
        else if (gameObject.scene.name == "7.4" & eventData.pointerDrag.tag != "panel")
        {
            if (slotInsertedAudio != null && !slotInsertedAudio.isPlaying)
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

            //set pivot
            eventData.pointerDrag.transform.SetParent(transform);

            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot = new Vector2(
                0.5f,
                0.5f
            );
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            Debug.Log(
                transform
                    .GetChild(0)
                    .transform
                    .GetChild(0)
                    .GetComponent<TextMeshProUGUI>()
                    .text
                    .ToUpper()
            );
            if (
                answerStore.ToUpper()
                == transform
                    .GetChild(0)
                    .transform
                    .GetChild(0)
                    .GetComponent<TextMeshProUGUI>()
                    .text
                    .ToUpper()
            )
            {
                KuizController.instance.soalanAnswer[
                    int.Parse(transform.parent.transform.parent.name) - 1
                ] = true;
            }
            else
            {
                KuizController.instance.soalanAnswer[
                    int.Parse(transform.parent.transform.parent.name) - 1
                ] = false;
            }
        }
        else if (gameObject.scene.name == "8.1")
        {
            //set pivot
            if (eventData.pointerDrag.tag != "Untagged")
            {
                if (slotInsertedAudio != null && !slotInsertedAudio.isPlaying)
                {
                    slotInsertedAudio.Play();
                }
                if (eventData.pointerDrag.tag == "temps1")
                {
                    eventData.pointerDrag.tag = "s1";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps2")
                {
                    eventData.pointerDrag.tag = "s2";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps3")
                {
                    eventData.pointerDrag.tag = "s3";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps4")
                {
                    eventData.pointerDrag.tag = "s4";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps5")
                {
                    eventData.pointerDrag.tag = "s5";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps6")
                {
                    eventData.pointerDrag.tag = "s6";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                else if (eventData.pointerDrag.tag == "temps7")
                {
                    eventData.pointerDrag.tag = "s7";
                    eventData.pointerDrag.transform.SetParent(transform);

                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMin =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().anchorMax =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.transform.GetComponent<RectTransform>().pivot =
                        new Vector2(0.5f, 0.5f);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(0.0f, 0.0f);
                    eventData.pointerDrag.AddComponent<Mask>();
                }
                GetComponent<PiramidJawapan>().jawapanName = eventData.pointerDrag.transform.name;
                eventData.pointerDrag.transform.SetParent(transform.parent);
            }
            else
            {
                return;
            }
        }
        else if (gameObject.scene.name == "8.2")
        {
            if (slotInsertedAudio != null && !slotInsertedAudio.isPlaying)
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

            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
        if (item.CurrentSlot != null && item.CurrentSlot != this) item.CurrentSlot.Release(item);
        Occupant = item;
        item.Accept(this);
        // World position is correct even when the item and target have different parents/anchors.
        item.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        if (KuizController.instance != null) KuizController.instance.ClearFeedback();
    }
}
