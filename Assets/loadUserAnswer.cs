using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class loadUserAnswer : MonoBehaviour
{
    public int sceneNum;

    [Header("scene6")]
    public TMP_InputField[] text;
    // Start is called before the first frame update
    void Start()
    {
        text = new TMP_InputField[transform.childCount];
        //assigning
        for (int i = 0; i < transform.childCount; i++)
        {
            text[i] = transform.GetChild(i).GetComponent<TMP_InputField>();
        }
        if (sceneNum == 2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s2n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s2n" + (i + 1));

                }
            }
        }
        else if (sceneNum == 3)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s3n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s3n" + (i + 1));

                }
            }
        }
        else if (sceneNum == 4)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s4n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s4n" + (i + 1));

                }
            }
        }
        else if (sceneNum == 5)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s5n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s5n" + (i + 1));

                }
            }
        }
        else if (sceneNum == 6)
        {
            //writing
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s6n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s6n" + (i + 1));

                }
            }

        }
        else if (sceneNum == 7)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!PlayerPrefs.GetString("s7n" + (i + 1)).Equals(null))
                {

                    text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s7n" + (i + 1));

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
