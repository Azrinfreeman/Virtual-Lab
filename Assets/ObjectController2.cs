using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectController2 : MonoBehaviour
{
    public static ObjectController2 instance;

    private void Awake()
    {
        instance = this;
    }
    public Animator anim;

    public int Eksperimen;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHistory;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        text = GameObject.Find("textInventory").GetComponent<TextMeshProUGUI>();
    }

    public void Untouch()
    {
        for (int i = 0; i < TouchController2.instance.alat.Length; i++)
        {

            TouchController2.instance.alat[i].GetChild(0).transform.GetComponent<Outline>().enabled = false;
            TouchController2.instance.alat[i].GetChild(0).transform.GetComponent<SelectedController>().isSelected = false;

        }
    }

    IEnumerator TrueAndFalseWithTimeTwo(float time, int i, int l)
    {
        TouchController2.instance.alat[i].GetComponent<DragController>().isStop = true;
        TouchController2.instance.alat[l].GetComponent<DragController>().isStop = true;
        yield return new WaitForSeconds(time);

        TouchController2.instance.alat[i].GetComponent<DragController>().isStop = false;
        TouchController2.instance.alat[l].GetComponent<DragController>().isStop = false;
    }
    // Update is called once per frame
    void Update()
    {

        //step 1
        if (Eksperimen == 3)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[1 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik bikar larutan albumen ke silinder penyukat ";

                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {

                            anim.Play("step1");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 1));
                            Untouch();


                        }

                    }
                }
            }

            //step 2
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep2"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[2 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[2 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik silinder penyukat ke tabung uji A";
                        textHistory.text = "1. Tarik bikar larutan albumen ke silinder penyukat. \n";
                        if (TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step2");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 3, 1));
                            Untouch();
                        }

                    }
                }
            }

            //step 3
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[3 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[3 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik asid hidroklorik cair ke silinder penyukat";
                        textHistory.text = "2. Tarik silinder penyukat ke tabung uji A \n";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step3");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));
                            Untouch();
                        }

                    }
                }
            }

            //step 4
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[4 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[4 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "3. Tarik asid hidroklorik cair ke silinder penyukat";
                        text.text = "Tarik silinder penyukat ke tabung uji A";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step4");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));
                            Untouch();
                        }

                    }
                }
            }

            //step 5
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep5"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[5 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[5 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "4. Tarik silinder penyukat ke tabung uji A";
                        text.text = "Goncang tabung uji A(tekan tabung uji A)";
                        if (
                        TouchController2.instance.alat[3].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[5 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }
            //step 6
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep6"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[6 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[6 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "5. Goncang tabung uji A";
                        text.text = "Tarik larutan pepsin 1% ke silinder penyukat";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step6");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));
                            Untouch();
                        }

                    }
                }
            }



            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep7"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[7 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[7 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "6. Tarik larutan pepsin 1% ke silinder penyukat";
                        text.text = "Tarik silinder penyukat mengandungi larutan pepsin ke tabung uji A";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step7");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));
                            Untouch();
                        }

                    }
                }
            }


            //step 8
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep8"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[8 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[8 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "7. Tarik silinder penyukat mengandungi larutan pepsin ke tabung uji A";
                        text.text = "Goncang tabung uji A(tekan tabung uji A)";
                        if (//TouchController2.instance.alat[1].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[3].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[8 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }

            //step 9
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[9 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[9 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "9. Goncang tabung uji A";
                        text.text = "Tarik Ampaian Albumen ke silinder penyukat";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step9");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 1));
                            Untouch();
                        }

                    }
                }
            }


            //step 10
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep10"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[10 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[10 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "9. Tarik Ampaian Albumen ke silinder penyukat";
                        text.text = "Tarik ampaian albumen ke tabung uji B";
                        if (TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step10");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 5, 1));
                            Untouch();
                        }

                    }
                }
            }

            //step 11
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep11"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[11 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[11 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "10. Tarik ampaian albumen ke tabung uji B";
                        text.text = "Tarik asid hidroklorik (1 ml) ke silinder penyukat";
                        if (TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step11");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 1));
                            Untouch();
                        }

                    }
                }
            }
            //step 12
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep12"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[12 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[12 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "11. Tarik Silinder Penyukat berisi larutan asid hidroklorik ke tabung uji B";
                        text.text = "Tarik Silinder Penyukat berisi larutan asid hidroklorik ke tabung uji B";
                        if (TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step12");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 5, 1));
                            Untouch();
                        }

                    }
                }
            }
            //step 13
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep13"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[13 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[13 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "12. Tarik Silinder Penyukat berisi larutan asid hidroklorik ke tabung uji B";
                        text.text = "Goncang tabung uji B(tekan tabung uji B)";
                        if (//TouchController2.instance.alat[5].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[5].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[13 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }

            //step 14
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep14"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[14 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[14 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "13. Goncang tabung uji B";
                        text.text = "Tarik air suling ke silinder penyukat";
                        if (TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step14");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 6, 1));
                            Untouch();
                        }

                    }
                }
            }

            //step 15
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep15"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[15 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[15 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "14. Tarik air suling ke silinder penyukat";
                        text.text = "Tarik air suling dari silinder penyukat ke tabung uji B";
                        if (TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step15");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 5, 1));
                            Untouch();
                        }

                    }
                }
            }

            //step 16
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep16"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[16 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[16 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "15. Tarik air suling dari silinder penyukat ke tabung uji B";
                        text.text = "Goncang tabung uji B(tekan tabung uji B)";
                        if (TouchController2.instance.alat[5].GetChild(0).GetComponent<SelectedController>().isSelected)//&&
                        //TouchController2.instance.alat[1].GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[16 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }


            //step 17
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[17 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[17 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "16. Goncang tabung uji B";
                        text.text = "Klik penunu Bunsen untuk nyalakan api";
                        if (TouchController2.instance.alat[7].GetChild(0).GetComponent<SelectedController>().isSelected)
                        //TouchController2.instance.alat[1].GetComponent<SelectedController>().isSelected
                        {
                            ButtonControllers.instance.buttons[17 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep18"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[18 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[18 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "17. Klik penunu Bunsen untuk nyalakan api";
                        text.text = "Tekan tabung uji A dan bikar kukus air";
                        if (TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide &&
                            TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step18");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 3, 9));
                            Untouch();
                        }

                    }
                }
            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep19"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[19 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[19 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "18. Tekan tabung uji A dan bikar kukus air";
                        text.text = "Tekan tabung uji B dan bikar kukus air";
                        if (TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide &&
                            TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step19");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 5, 9));
                            Untouch();
                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep20"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[20 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1
                    && !bstepsController.instance.bsteps[20 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        textHistory.text = "19.Tekan tabung uji B dan bikar kukus air";
                        text.text = "Tetapkan jam randik 20 minit";
                        if (//TouchController2.instance.alat[5].GetComponent<SelectedController>().isSelected &&
                            TouchController2.instance.alat[8].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[20 - 1].gameObject.SetActive(true);
                            Untouch();
                        }

                    }
                }
            }
        }

        else if (Eksperimen == 4)

        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[1 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "tarik  picagari ke minyak masak ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step1");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 7));

                        }

                    }
                }
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep2"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[2 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik minyak dalam picagari ke tabung uji A";
                        textHistory.text = "1. tarik  picagari ke minyak masak";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step2");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[3 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar larutan natrium karbonat 0.2 M.";
                        textHistory.text = "2. Tarik minyak dalam picagari ke tabung uji A. \n";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step3");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 6));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[4 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke tabung uji A ";
                        textHistory.text = "3. Tekan picagari dan bikar larutan natrium karbonat 0.2 M.";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step4");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }
            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep5"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[5 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar pencuci pinggan  ";
                        textHistory.text = "4. Tekan picagari dan tabung uji A. ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[8].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step5");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 8));

                        }

                    }
                }

            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep6"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[6 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari (warna hijau) ke tabung uji A   ";
                        textHistory.text = "5. Tarik picagari ke bikar pencuci pinggan   ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step6");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep7"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[7 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tutup tabung uji A dengan penutup tabung uji(klik tabung uji A) ";
                        textHistory.text = "6. Tarik picagari (warna hijau) ke tabung uji A     ";
                        if (TouchController2.instance.alat[3].GetChild(0).GetComponent<SelectedController>().isSelected)
                        //TouchController2.instance.alat[3].GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[7 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep8"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[8 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "goncang tabung uji A dengan kuat(klik tabung A) ";
                        textHistory.text = "7. Tutup tabung uji A dengan penutup tabung uji(klik tabung uji A)   ";
                        if (TouchController2.instance.alat[3].GetChild(0).GetComponent<SelectedController>().isSelected)
                        //TouchController2.instance.alat[3].GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[8 - 1].gameObject.SetActive(true);

                        }

                    }
                }

            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[9 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar minyak masak ";
                        textHistory.text = "8.goncang tabung uji A dengan kuat(klik tabung uji A) ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step9");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 7));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep10"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[10 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari (ada minyak masak) ke tabung uji B ";
                        textHistory.text = "9. Tarik picagari ke bikar minyak masak  ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step10");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep11"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[11 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar larutan natrium  ";
                        textHistory.text = "10. Tarik picagari (ada minyak masak) ke tabung uji B   ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step11");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 6));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep12"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[12 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari larutan natrium hidroksida ke tabung uji B ";
                        textHistory.text = "11. Tarik picagari ke bikar larutan natrium    ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step12");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep13"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[13 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar pencuci pinggan  ";
                        textHistory.text = "12. Tarik picagari larutan natrium hidroksida ke tabung uji B  ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[8].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step13");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 8));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep14"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[14 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke tabung uji B ";
                        textHistory.text = "13. Tarik picagari ke bikar pencuci pinggan   ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step14");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep15"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[15 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tutup tabung uji B di rak tabung uji(klik tabung uji)";
                        textHistory.text = "14. Tarik picagari ke tabung uji B ";
                        if (//TouchController2.instance.alat[1].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[4].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[15 - 1].gameObject.SetActive(true);

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep16"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[16 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Klik tabung uji B untuk goncang tabung B dengan kuat";
                        textHistory.text = "15. Tutup tabung uji B di rak tabung uji(klik tabung uji) ";
                        if (//TouchController2.instance.alat[1].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[4].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[16 - 1].gameObject.SetActive(true);

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[17 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik penitis ke bikar larutan fenolftelin ";
                        textHistory.text = "16. Klik tabung uji B untuk goncang tabung B dengan kuat ";
                        if (TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step17");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 9));

                        }

                    }
                }

            }


            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep18"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[18 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik penitis ke tabung uji A untuk titiskan 3 titis  ";
                        textHistory.text = "17. Tarik penitis ke bikar larutan fenolftelin   ";
                        if (TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step18");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 3));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep19"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[19 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik penitis ke bikar larutan fenolftelin.  ";
                        textHistory.text = "18. Tarik penitis ke tabung uji A untuk titiskan 3 titis   ";
                        if (TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step19");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 9));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep20"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[20 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik penitis (yang ada warna pink) ke tabung uji B untuk menitiskan 3 titis  ";
                        textHistory.text = "19. Tarik penitis ke bikar larutan fenolftelin.  ";
                        if (TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step20");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 4));

                        }

                    }
                }

            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep21"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[21 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar enzim lipase  ";
                        textHistory.text = "20. Tarik penitis (yang ada warna pink) ke tabung uji B untuk menitiskan 3 titis  ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step21");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 5));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep22"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[22 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari ke bikar enzim lipase ";
                        textHistory.text = "21. Tarik picagari (ada minyak masak) ke tabung uji B   ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step22");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep23"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[23 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik botol air suling ke tabung uji B ";
                        textHistory.text = "22. Tarik picagari ke bikar enzim lipase  ";
                        if (TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[10].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step23");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 4, 10));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep24"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[24 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Nyalakan penunu bunsen (klik penunu bunsen) ";
                        textHistory.text = "23. Tekan botol air suling dan tabung uji B    ";
                        if (//TouchController2.instance.alat[4].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[11].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[24 - 1].gameObject.SetActive(true);

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep25"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[25 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tekan tabung uji A dan kukus air(klik) ";
                        textHistory.text = "24.Nyalakan penunu bunsen (klik penunu bunsen) ";
                        if (TouchController2.instance.alat[13].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step25");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 13, 3));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep26"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[26 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tekan tabung uji B dan kukus air ";
                        textHistory.text = "25. Tekan(klik) tabung uji A dan kukus air ";
                        if (TouchController2.instance.alat[13].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step26");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 13, 4));

                        }

                    }
                }

            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep27"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[27 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Klik jam randik ";
                        textHistory.text = "26. Tekan tabung uji B dan kukus air ";
                        if (//TouchController2.instance.alat[3].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[12].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[27 - 1].gameObject.SetActive(true);

                        }

                    }
                }

            }
        }

        else if (Eksperimen == 5)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[1 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik kacang gajus ke atas penimbang  ";
                        if (TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step1");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 7, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[3 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik botol air suling ke silinder penyukat untuk tekan 20 ml air suling";
                        textHistory.text = "1. Tarik kacang gajus ke atas penimbang  ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step3");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 1));
                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[4 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik silinder penyukat ke tabung didih";
                        textHistory.text = "3. Tarik botol air suling ke silinder penyukat untuk tekan 20 ml air suling";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step4");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[9 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik kacang gajus ke jarum pada plastisin. ";
                        textHistory.text = "8. Tarik silinder penyukat ke tabung didih";
                        if (TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step9");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 5, 7));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep10"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[10 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Klik penunu Bunsen. ";
                        textHistory.text = "9. Tarik kacang gajus ke jarum pada plastisin. ";
                        if (TouchController2.instance.alat[2].GetChild(0).GetComponent<SelectedController>().isSelected)
                        //TouchController2.instance.alat[7].GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[10 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep11"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[11 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tekan jarum yang ada plastisin dan kacang gajus dan juga penunu bunsen ";
                        textHistory.text = "10. Klik penunu Bunsen";
                        if (TouchController2.instance.alat[5].GetChild(0).GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[7].GetChild(0).GetComponent<SelectedController>().isSelected
                        && TouchController2.instance.alat[2].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[11 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep13"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[13 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik kacang gajus (yang masih menyala) ke tabung didih";
                        textHistory.text = "11. Tekan jarum yang ada plastisin dan kacang gajus dan juga penunu bunsen ";
                        if (TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            ButtonControllers.instance.buttons[13 - 1].gameObject.SetActive(true);
                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[17 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik botol air suling ke silinder penyukat untuk masukkan 20ml air suling ";
                        textHistory.text = "13. Tarik kacang gajus (yang masih menyala) ke tabung didih";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step17");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 1));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep18"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[18 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik silinder penyukat yang ada air suling ke tabung didih. ";
                        textHistory.text = "17. Tarik botol air suling ke silinder penyukat untuk masukkan 20ml air suling ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step18");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep23"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[23 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik kacang gajus ke pemberat. ";
                        textHistory.text = "18. Tarik silinder penyukat yang ada air suling ke tabung didih. ";
                        if (TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step23");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 6, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep25"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[25 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik kacang tanah ke jarum pada plastisin.  ";
                        textHistory.text = "23. Tarik kacang gajus ke pemberat.";
                        if (TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step25");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 6, 5));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep26"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[26 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tekan penunu bunsen.  ";
                        textHistory.text = "25. Tarik kacang tanah ke jarum pada plastisin.";
                        if (//TouchController2.instance.alat[6].GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[2].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[26 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep27"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[27 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tekan jarum yang ada plastisin dan kacang tanah dan penunu bunsen ";
                        textHistory.text = "26. Tekan penunu bunsen. ";
                        if (TouchController2.instance.alat[5].GetChild(0).GetComponent<SelectedController>().isSelected &&
                        TouchController2.instance.alat[2].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[27 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }
        }

        else if (Eksperimen == 6)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[1 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP";

                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step1");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 7));


                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep2"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[2 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik larutan DCPIP ke tiub spesimen 1";
                        textHistory.text = "1. Tarik picagari 1ml ke larutan DCPIP ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step2");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 5));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[3 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP";
                        textHistory.text = "2. Tarik larutan DCPIP ke tiub spesimen 1 ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step3");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 7));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[4 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik larutan DCPIP ke tiub spesimen 2";
                        textHistory.text = "3. Tarik picagari 1ml ke larutan DCPIP";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step4");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep5"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[5 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP";
                        textHistory.text = "4. Tarik larutan DCPIP ke tiub spesimen 2";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step5");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 7));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep6"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[6 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik larutan DCPIP ke tiub spesimen 3";
                        textHistory.text = "5. Tarik picagari 1ml ke larutan DCPIP";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step6");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep7"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[7 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP";
                        textHistory.text = "6. Tarik larutan DCPIP ke tiub spesimen 3";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step7");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 7));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep8"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[8 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik larutan DCPIP ke tiub spesimen 4";
                        textHistory.text = "7. Tarik picagari 1ml ke larutan DCPIP";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step8");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 2));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[9 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke larutan asid askorbik";

                        textHistory.text = "8. Tarik larutan DCPIP ke tiub spesimen 4";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step9");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 6));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep10"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[10 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 1 ";
                        textHistory.text = "9. Tarik picagari 5ml ke larutan asid askorbik";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step10");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 5));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep13"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[13 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke Jus Oren";
                        textHistory.text = "10. Tarik picagari 5ml ke tiub specimen 1 ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[8].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step13");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 8));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep14"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[14 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 2 ";
                        textHistory.text = "13. Tarik picagari 5ml ke Jus Oren";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step14");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[17 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke Jus Limau Nipis";
                        textHistory.text = "14. Tarik picagari 5ml ke tiub specimen 2 ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step17");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 9));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep18"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[18 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 3 ";
                        textHistory.text = "17. Tarik picagari 5ml ke Jus Limau Nipis";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step18");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep21"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[21 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke jus Lobak Merah";
                        textHistory.text = "18. Tarik picagari 5ml ke tiub specimen 3 ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[10].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step21");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 10));


                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep22"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[22 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 4 ";
                        textHistory.text = "21. Tarik picagari 5ml ke jus Lobak Merah";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step22");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep23"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[23 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke jus Lobak Merah";
                        textHistory.text = "22. Tarik picagari 5ml ke tiub specimen 4";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[10].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step23");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 10));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep24"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[24 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 4 ";
                        textHistory.text = "23. Tarik picagari 5ml ke jus Lobak Merah";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step24");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));

                        }

                    }
                }
            }
        }

        else if (Eksperimen == 7)
        {

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[1 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik bikar A ke bikar berisi ais ";
                        if (TouchController2.instance.alat[6].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[10].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step1");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 6, 10));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep2"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[2 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik bikar B ke bikar berisi air pada suhu bilik";
                        textHistory.text = "1. Tarik bikar A ke bikar berisi ais ";
                        if (TouchController2.instance.alat[7].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[11].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step2");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 7, 11));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[3 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik bikar C ke bikar air mendidih ";
                        textHistory.text = "2. Tarik bikar B ke bikar berisi air pada suhu bilik";
                        if (TouchController2.instance.alat[8].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[12].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step3");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 8, 12));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[4 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tetapkan jam randik pada 30 minit(tekan jam) ";
                        textHistory.text = "3. Tarik bikar C ke bikar air mendidih";
                        if (TouchController2.instance.alat[13].GetChild(0).GetComponent<SelectedController>().isSelected)
                        {
                            ButtonControllers.instance.buttons[4 - 1].gameObject.SetActive(true);

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep5"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[5 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "tarik picagari 1ml ke larutan DCPIP. ";
                        textHistory.text = "4. Tetapkan jam randik pada 30 minit(tekan jam)";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step5");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 9));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep6"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[6 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke tiub spesimen 1.  ";
                        textHistory.text = "5. Tarik picagari 1ml ke larutan DCPIP.";
                        Debug.Log("bstep6 now");
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step6");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 5));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep7"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[7 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP.  ";
                        textHistory.text = "6. Tarik picagari 1ml ke tiub spesimen 1. ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step7");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 9));
                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep8"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[8 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke tiub spesimen 2  ";
                        textHistory.text = "7. Tarik picagari 1ml ke larutan DCPIP. ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step8");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[9 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP.   ";
                        textHistory.text = "8. Tarik picagari 1ml ke tiub spesimen 2";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step9");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 9));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep10"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[10 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke tiub spesimen 3 ";

                        textHistory.text = "9. Tarik picagari 1ml ke larutan DCPIP. ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step10");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep11"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[11 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke larutan DCPIP.  ";
                        textHistory.text = "10. Tarik picagari 1ml ke tiub spesimen 3  ";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[9].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step11");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 9));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep12"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[12 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 1ml ke tiub spesimen 4.   ";
                        textHistory.text = "11. Tarik picagari 1ml ke larutan DCPIP.";
                        if (TouchController2.instance.alat[0].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step12");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 2));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep13"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[13 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke larutan asid askorbik. ";
                        textHistory.text = "12. Tarik picagari 1ml ke tiub spesimen 4.";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[14].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step13");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 14));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep14"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[14 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 1. ";
                        textHistory.text = "13. Tarik picagari 5ml ke larutan asid askorbik. ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[5].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step14");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 5));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[17 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke jus oren dalam Bikar A ";
                        textHistory.text = "14. Tarik picagari 5ml ke tiub specimen 1. ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[10].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step17");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 10));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep18"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[18 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 2  ";
                        textHistory.text = "17. Tarik picagari 5ml ke jus oren dalam Bikar A";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[4].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step18");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep21"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[21 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke jus oren dalam Bikar B.  ";
                        textHistory.text = "18. Tarik picagari 5ml ke tiub specimen 2 ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[11].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step21");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 11));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep22"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[22 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 3  ";
                        textHistory.text = "21. Tarik picagari 5ml ke jus oren dalam Bikar B. ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[3].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step22");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep25"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[25 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke jus oren dalam bikar C. ";
                        textHistory.text = "22. Tarik picagari 5ml ke tiub specimen 3  ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[12].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step25");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 12));

                        }

                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("bstep26"))
            {

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    if (bstepsController.instance.bsteps[26 - 1].GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstepsController.instance.bsteps[1 - 1].IsInTransition(0) && !anim.IsInTransition(0))
                    {
                        text.text = "Tarik picagari 5ml ke tiub specimen 4. ";
                        textHistory.text = "25. Tarik picagari 5ml ke jus oren dalam bikar C.  ";
                        if (TouchController2.instance.alat[1].GetComponent<IsCollided>().isCollide &&
                        TouchController2.instance.alat[2].GetComponent<IsCollided>().isCollide)
                        {
                            anim.Play("step26");
                            StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));

                        }

                    }
                }
            }
        }
    }
}
