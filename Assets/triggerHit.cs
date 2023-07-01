using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "3.4")
        {
            if (other.gameObject.tag == "protein")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temprotein";
            }
            else if (other.gameObject.tag == "air")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "tempair";
            }
            else if (other.gameObject.tag == "polipeptida")
            {
                GetComponent<ItemSlot>().answerStore = "";

                other.gameObject.tag = "temppolipeptida";
            }

        }
        else if (SceneManager.GetActiveScene().name == "5.4")
        {

            if (other.gameObject.tag == "button1")
            {


                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "tempButton1";
            }
            else if (other.gameObject.tag == "button2")
            {
                GetComponent<ItemSlot>().answerStore = "";

                other.gameObject.tag = "tempButton2";
            }
            else if (other.gameObject.tag == "button3")
            {
                GetComponent<ItemSlot>().answerStore = "";

                other.gameObject.tag = "tempButton3";
            }
            else if (other.gameObject.tag == "button4")
            {
                GetComponent<ItemSlot>().answerStore = "";

                other.gameObject.tag = "tempButton4";
            }
        }
        else if (SceneManager.GetActiveScene().name == "4.4" || SceneManager.GetActiveScene().name == "7.4")
        {
            if (other.gameObject.tag == "s1")
            {

                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps1";
            }
            else if (other.gameObject.tag == "s2")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps2";
            }
            else if (other.gameObject.tag == "s3")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps3";
            }
            else if (other.gameObject.tag == "s4")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps4";
            }
            else if (other.gameObject.tag == "s5")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps5";
            }
            else if (other.gameObject.tag == "s6")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps6";
            }
            else if (other.gameObject.tag == "s7")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps7";
            }
            else if (other.gameObject.tag == "s8")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps8";
            }
            else if (other.gameObject.tag == "s9")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps9";
            }
            else if (other.gameObject.tag == "s10")
            {
                GetComponent<ItemSlot>().answerStore = "";
                other.gameObject.tag = "temps10";
            }
            if (transform.GetComponent<ItemSlot>().answerStore == transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)
            {
                KuizController.instance.soalanAnswer[int.Parse(transform.parent.transform.parent.name) - 1] = true;
            }
            else
            {
                KuizController.instance.soalanAnswer[int.Parse(transform.parent.transform.parent.name) - 1] = false;
            }

        }
        else if (SceneManager.GetActiveScene().name == "8.2")
        {
            if (other.gameObject.tag == "s1")
            {

                GetComponent<PingganName>().plateName = "";
                other.gameObject.tag = "temps1";
            }
            else if (other.gameObject.tag == "s2")
            {
                GetComponent<PingganName>().plateName = "";
                other.gameObject.tag = "temps2";
            }
            else if (other.gameObject.tag == "s3")
            {
                GetComponent<PingganName>().plateName = "";
                other.gameObject.tag = "temps3";
            }
            else if (other.gameObject.tag == "s4")
            {
                GetComponent<PingganName>().plateName = "";
                other.gameObject.tag = "temps4";
            }

        }

    }
}
