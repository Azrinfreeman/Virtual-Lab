using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiInputKeputusan : MonoBehaviour
{
    public InputKeputusan[] input;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        input = new InputKeputusan[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            input[i] = transform.GetChild(i).GetComponent<InputKeputusan>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "2.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) || Regex.IsMatch(input[0].text.text.ToUpper(), input[0].stringAnswer2.ToUpper()) &&
             input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) || Regex.IsMatch(input[1].text.text.ToUpper(), input[1].stringAnswer2.ToUpper()) &&
             input[2].text.text.ToUpper().Equals(input[2].stringAnswer.ToUpper()) || Regex.IsMatch(input[2].text.text.ToUpper(), input[2].stringAnswer2.ToUpper()) &&
             input[3].text.text.ToUpper().Equals(input[3].stringAnswer.ToUpper()) || Regex.IsMatch(input[3].text.text.ToUpper(), input[3].stringAnswer2.ToUpper()
             )
             ) 
            {


                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
            else
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;

            }
        }
        else if (SceneManager.GetActiveScene().name == "3.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) &&
            input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) &&
            input[2].text.text.ToUpper().Equals(input[2].stringAnswer.ToUpper()) &&
            input[3].text.text.ToUpper().Equals(input[3].stringAnswer.ToUpper()))
            {

                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "4.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) || Regex.IsMatch(input[0].text.text.ToUpper(), input[0].stringAnswer2.ToUpper()) &&
             input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) || Regex.IsMatch(input[1].text.text.ToUpper(), input[1].stringAnswer2.ToUpper())
             )
            {


                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
            else
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;

            }
        }
        else if (SceneManager.GetActiveScene().name == "5.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) || Regex.IsMatch(input[0].text.text.ToUpper(), input[0].stringAnswer2.ToUpper()) &&
             input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) || Regex.IsMatch(input[1].text.text.ToUpper(), input[1].stringAnswer2.ToUpper()) &&
             input[2].text.text.ToUpper().Equals(input[2].stringAnswer.ToUpper()) || Regex.IsMatch(input[2].text.text.ToUpper(), input[2].stringAnswer2.ToUpper()) &&
             input[3].text.text.ToUpper().Equals(input[3].stringAnswer.ToUpper()) || Regex.IsMatch(input[3].text.text.ToUpper(), input[3].stringAnswer2.ToUpper()
             ) &&
             input[4].text.text.ToUpper().Equals(input[4].stringAnswer.ToUpper()) || Regex.IsMatch(input[4].text.text.ToUpper(), input[4].stringAnswer2.ToUpper()) &&
             input[5].text.text.ToUpper().Equals(input[5].stringAnswer.ToUpper()) || Regex.IsMatch(input[5].text.text.ToUpper(), input[5].stringAnswer2.ToUpper()
             ) &&
             input[6].text.text.ToUpper().Equals(input[6].stringAnswer.ToUpper()) || Regex.IsMatch(input[6].text.text.ToUpper(), input[6].stringAnswer2.ToUpper()) &&
             input[7].text.text.ToUpper().Equals(input[7].stringAnswer.ToUpper()) || Regex.IsMatch(input[7].text.text.ToUpper(), input[7].stringAnswer2.ToUpper()
             ) &&
             input[8].text.text.ToUpper().Equals(input[8].stringAnswer.ToUpper()) || Regex.IsMatch(input[8].text.text.ToUpper(), input[8].stringAnswer2.ToUpper()) &&
             input[9].text.text.ToUpper().Equals(input[9].stringAnswer.ToUpper()) || Regex.IsMatch(input[9].text.text.ToUpper(), input[9].stringAnswer2.ToUpper()
             )


             )
            {


                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
            else
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;

            }
        }
        else if (SceneManager.GetActiveScene().name == "6.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) || Regex.IsMatch(input[0].text.text.ToUpper(), input[0].stringAnswer2.ToUpper()) &&
             input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) || Regex.IsMatch(input[1].text.text.ToUpper(), input[1].stringAnswer2.ToUpper()) &&
             input[2].text.text.ToUpper().Equals(input[2].stringAnswer.ToUpper()) || Regex.IsMatch(input[2].text.text.ToUpper(), input[2].stringAnswer2.ToUpper()) &&
             input[3].text.text.ToUpper().Equals(input[3].stringAnswer.ToUpper()) || Regex.IsMatch(input[3].text.text.ToUpper(), input[3].stringAnswer2.ToUpper()
             ) &&
             input[4].text.text.ToUpper().Equals(input[4].stringAnswer.ToUpper()) || Regex.IsMatch(input[4].text.text.ToUpper(), input[4].stringAnswer2.ToUpper()) &&
             input[5].text.text.ToUpper().Equals(input[5].stringAnswer.ToUpper()) || Regex.IsMatch(input[5].text.text.ToUpper(), input[5].stringAnswer2.ToUpper()
             ) &&
             input[6].text.text.ToUpper().Equals(input[6].stringAnswer.ToUpper()) || Regex.IsMatch(input[6].text.text.ToUpper(), input[6].stringAnswer2.ToUpper()) &&
             input[7].text.text.ToUpper().Equals(input[7].stringAnswer.ToUpper()) || Regex.IsMatch(input[7].text.text.ToUpper(), input[7].stringAnswer2.ToUpper()
             ) &&
             input[8].text.text.ToUpper().Equals(input[8].stringAnswer.ToUpper()) || Regex.IsMatch(input[8].text.text.ToUpper(), input[8].stringAnswer2.ToUpper()) &&
             input[9].text.text.ToUpper().Equals(input[9].stringAnswer.ToUpper()) || Regex.IsMatch(input[9].text.text.ToUpper(), input[9].stringAnswer2.ToUpper()
             )


             )
            {


                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
            }
            else
            {
                KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;

            }
        }
        else if (SceneManager.GetActiveScene().name == "7.3")
        {
            if (input[0].text.text.ToUpper().Equals(input[0].stringAnswer.ToUpper()) || Regex.IsMatch(input[0].text.text.ToUpper(), input[0].stringAnswer2.ToUpper()) &&
             input[1].text.text.ToUpper().Equals(input[1].stringAnswer.ToUpper()) || Regex.IsMatch(input[1].text.text.ToUpper(), input[1].stringAnswer2.ToUpper()) &&
             input[2].text.text.ToUpper().Equals(input[2].stringAnswer.ToUpper()) || Regex.IsMatch(input[2].text.text.ToUpper(), input[2].stringAnswer2.ToUpper()) &&
             input[3].text.text.ToUpper().Equals(input[3].stringAnswer.ToUpper()) || Regex.IsMatch(input[3].text.text.ToUpper(), input[3].stringAnswer2.ToUpper()
             ) &&
             input[4].text.text.ToUpper().Equals(input[4].stringAnswer.ToUpper()) || Regex.IsMatch(input[4].text.text.ToUpper(), input[4].stringAnswer2.ToUpper()) &&
             input[5].text.text.ToUpper().Equals(input[5].stringAnswer.ToUpper()) || Regex.IsMatch(input[5].text.text.ToUpper(), input[5].stringAnswer2.ToUpper()
             ) &&
             input[6].text.text.ToUpper().Equals(input[6].stringAnswer.ToUpper()) || Regex.IsMatch(input[6].text.text.ToUpper(), input[6].stringAnswer2.ToUpper())

             )
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
