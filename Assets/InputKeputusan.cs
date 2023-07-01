using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class InputKeputusan : MonoBehaviour
{

    public TMP_InputField text;
    public string stringAnswer;

    public string stringAnswer2;
    public string stringAnswer3;
    public bool multiAns;
    public Transform parent;
    public bool isCorrect;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_InputField>();
    }


    public void checkAnswer()
    {
        if (text.text.ToUpper().Equals(stringAnswer.ToUpper()))
        {
            isCorrect = true;
        }
        else
        {
            if (Regex.IsMatch(text.text.ToUpper(), stringAnswer2.ToUpper()))
            {

                isCorrect = true;
            }
            else if (Regex.IsMatch(text.text.ToUpper(), stringAnswer3.ToUpper()))
            {

                isCorrect = true;
            }
            else
            {
                isCorrect = false;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        checkAnswer();

        if (!multiAns)
        {
            if (isCorrect)
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
            else
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;

            }
        }

    }
}
