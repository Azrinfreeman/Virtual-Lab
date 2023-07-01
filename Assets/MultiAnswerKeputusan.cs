using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MultiAnswerKeputusan : MonoBehaviour
{
    public Toggle[] answers;

    public string names;
    public Transform parent;


    // Start is called before the first frame update
    void Start()
    {
        answers = new Toggle[transform.childCount];


        for (int i = 0; i < transform.childCount; i++)
        {
            answers[i] = transform.GetChild(i).GetComponent<Toggle>();

        }
    }
    public void checkAnswers()
    {

        if (SceneManager.GetActiveScene().name == "2.3")
        {

            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn &&
                answers[1].isOn &&
                !answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (!answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                && !answers[3].isOn
                && answers[4].isOn
                && !answers[5].isOn
                && !answers[6].isOn
                && !answers[7].isOn
                && answers[8].isOn
                && !answers[9].isOn
                && !answers[10].isOn
                && answers[11].isOn
                && !answers[12].isOn
                && !answers[13].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (!answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                && answers[3].isOn
                && !answers[4].isOn
                && answers[5].isOn
                && answers[6].isOn
                && answers[7].isOn
                && !answers[8].isOn
                && answers[9].isOn
                && answers[10].isOn
                && !answers[11].isOn
                && answers[12].isOn
                && answers[13].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }

        }
        else if (SceneManager.GetActiveScene().name == "3.3")
        {


            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn && !answers[1].isOn && answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                && !answers[3].isOn
                && answers[4].isOn
                && !answers[5].isOn
                && !answers[6].isOn
                && answers[7].isOn
                && answers[8].isOn
                && !answers[9].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && answers[2].isOn
                && answers[3].isOn
                && !answers[4].isOn
                && answers[5].isOn
                && answers[6].isOn
                && !answers[7].isOn
                && !answers[8].isOn
                && answers[9].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }








        }

        else if (SceneManager.GetActiveScene().name == "4.3")
        {
            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn &&
                !answers[1].isOn &&
                answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                )
                {
                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (!answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                && answers[3].isOn
                && !answers[4].isOn
                && !answers[5].isOn
                && answers[6].isOn
                && answers[7].isOn
                && !answers[8].isOn
                && !answers[9].isOn
                && !answers[10].isOn
                && answers[11].isOn
                && answers[12].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                && !answers[3].isOn
                && answers[4].isOn
                && answers[5].isOn
                && !answers[6].isOn
                && !answers[7].isOn
                && answers[8].isOn
                && answers[9].isOn
                && answers[10].isOn
                && answers[11].isOn
                && answers[12].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "5.3")
        {
            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn &&
                !answers[1].isOn &&
                answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                && !answers[3].isOn
                && !answers[4].isOn
                && !answers[5].isOn
                && !answers[6].isOn
                && answers[7].isOn
                && answers[8].isOn
                && !answers[9].isOn
                && !answers[10].isOn
                && !answers[11].isOn
                && answers[12].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                && answers[3].isOn
                && answers[4].isOn
                && answers[5].isOn
                && answers[6].isOn
                && !answers[7].isOn
                && !answers[8].isOn
                && answers[9].isOn
                && answers[10].isOn
                && answers[11].isOn
                && !answers[12].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
        }

        else if (SceneManager.GetActiveScene().name == "6.3")
        {

            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn &&
                answers[1].isOn &&
                !answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (!answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                && answers[3].isOn
                && answers[4].isOn
                && answers[5].isOn
                && answers[6].isOn
                && answers[7].isOn
                && !answers[8].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (!answers[0].isOn
                && !answers[1].isOn
                && answers[2].isOn
                && !answers[3].isOn
                && !answers[4].isOn
                && !answers[5].isOn
                && !answers[6].isOn
                && !answers[7].isOn
                && answers[8].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }

        }
        else if (SceneManager.GetActiveScene().name == "7.3")
        {

            if (names.Equals("Dimanipulasikan"))
            {
                if (!answers[0].isOn &&
                !answers[1].isOn &&
                answers[2].isOn)
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bergerak"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Dimalarkan"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && !answers[2].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Bahan"))
            {
                if (!answers[0].isOn
                && answers[1].isOn
                && answers[2].isOn
                && !answers[3].isOn
                && !answers[4].isOn
                && !answers[5].isOn
                && answers[6].isOn
                && !answers[7].isOn
                && !answers[8].isOn
                )
                {


                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = true;
                }
                else
                {

                    KeputusanController.instance.Jawapan[parent.GetSiblingIndex()] = false;
                }
            }
            if (names.Equals("Radas"))
            {
                if (answers[0].isOn
                && !answers[1].isOn
                && !answers[2].isOn
                && answers[3].isOn
                && answers[4].isOn
                && answers[5].isOn
                && !answers[6].isOn
                && answers[7].isOn
                && answers[8].isOn)
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

    // Update is called once per frame
    void Update()
    {
        checkAnswers();
    }
}
