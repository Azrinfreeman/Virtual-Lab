using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setUserData : MonoBehaviour
{
    public int sceneNum;
    public bool isEnd;

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
            //writing
            if (isEnd)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!PlayerPrefs.GetString("s2n" + (i + 1)).Equals(null))
                    {

                        text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s2n" + (i + 1));

                    }
                }
            }
        }
        else if (sceneNum == 3)
        {
            //writing
            if (isEnd)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!PlayerPrefs.GetString("s3n" + (i + 1)).Equals(null))
                    {

                        text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s3n" + (i + 1));

                    }
                }
            }
        }
        else if (sceneNum == 4)
        {
            //writing
            if (isEnd)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!PlayerPrefs.GetString("s4n" + (i + 1)).Equals(null))
                    {

                        text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s4n" + (i + 1));

                    }
                }
            }
        }
        else if (sceneNum == 5)
        {
            //writing
            if (isEnd)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!PlayerPrefs.GetString("s5n" + (i + 1)).Equals(null))
                    {

                        text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s5n" + (i + 1));

                    }
                }
            }
        }
        else if (sceneNum == 6)
        {
            //writing
            if (isEnd)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (!PlayerPrefs.GetString("s6n" + (i + 1)).Equals(null))
                    {

                        text[i].text = transform.GetChild(i).GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("s6n" + (i + 1));

                    }
                }
            }


        }
        else if (sceneNum == 7)
        {

            //writing
            if (isEnd)
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


    }

    public void SetUserAnswer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            PlayerPrefs.SetString("s" + sceneNum + "n" + (i + 1), text[i].text);
            Debug.Log("s" + sceneNum + "n" + (i + 1));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
