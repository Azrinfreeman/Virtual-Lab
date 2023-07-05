using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kuiz1Controller : MonoBehaviour
{
    public Transform tahniahPrompt;
    public static Kuiz1Controller instance;

    private void Awake()
    {
        instance = this;
    }
    public InputBehaviour[] inputs;
    public bool[] correctAnswers;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        inputs = new InputBehaviour[transform.childCount];
        correctAnswers = new bool[11];
        count = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            inputs[i] = transform.GetChild(i).transform.GetChild(1).GetComponent<InputBehaviour>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inputs[0].GetComponent<TMP_InputField>().text != "")
        {
            if (inputs[0].GetComponent<TMP_InputField>().text.ToUpper() == "ESOFAGUS")
            {
                correctAnswers[0] = true;
            }
            else
            {
                correctAnswers[0] = false;
            }
        }
        if (inputs[1].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[1].GetComponent<TMP_InputField>().text.ToUpper() == "HATI")
            {
                correctAnswers[1] = true;
            }
            else
            {
                correctAnswers[1] = false;
            }
        }
        if (inputs[2].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[2].GetComponent<TMP_InputField>().text.ToUpper() == "KELENJAR LIUR")
            {
                correctAnswers[2] = true;
            }
            else
            {
                correctAnswers[2] = false;
            }
        }
        if (inputs[3].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[3].GetComponent<TMP_InputField>().text.ToUpper() == "MULUT")
            {
                correctAnswers[3] = true;
            }
            else
            {
                correctAnswers[3] = false;
            }
        }
        if (inputs[4].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[4].GetComponent<TMP_InputField>().text.ToUpper() == "USUS BESAR")
            {
                correctAnswers[4] = true;
            }
            else
            {
                correctAnswers[4] = false;
            }
        }
        if (inputs[5].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[5].GetComponent<TMP_InputField>().text.ToUpper() == "USUS KECIL")
            {
                correctAnswers[5] = true;
            }
            else
            {
                correctAnswers[5] = false;
            }
        }
        if (inputs[6].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[6].GetComponent<TMP_InputField>().text.ToUpper() == "REKTUM")
            {
                correctAnswers[6] = true;
            }
            else
            {
                correctAnswers[6] = false;
            }
        }
        if (inputs[7].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[7].GetComponent<TMP_InputField>().text.ToUpper() == "DUBUR")
            {
                correctAnswers[7] = true;
            }
            else
            {
                correctAnswers[7] = false;
            }
        }
        if (inputs[8].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[8].GetComponent<TMP_InputField>().text.ToUpper() == "PUNDI HEMPEDU")
            {
                correctAnswers[8] = true;
            }
            else
            {
                correctAnswers[8] = false;
            }
        }
        if (inputs[9].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[9].GetComponent<TMP_InputField>().text.ToUpper() == "PANKREAS")
            {
                correctAnswers[9] = true;
            }
            else
            {
                correctAnswers[9] = false;
            }
        }
        if (inputs[10].GetComponent<TMP_InputField>().text != "")
        {

            if (inputs[10].GetComponent<TMP_InputField>().text.ToUpper() == "PERUT")
            {
                correctAnswers[10] = true;
            }
            else
            {
                correctAnswers[10] = false;
            }
        }


        if (correctAnswers[0] && correctAnswers[1] && correctAnswers[2] && correctAnswers[3] &&
        correctAnswers[4] && correctAnswers[5] && correctAnswers[6] && correctAnswers[7] &&
        correctAnswers[8] && correctAnswers[9] && correctAnswers[10])
        {

            tahniahPrompt.gameObject.SetActive(true);
            Debug.Log("appear");
        }


    }
}
