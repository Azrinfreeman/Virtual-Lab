using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{

    public static ObjectController instance;
    public int Eksperimen;
    private void Awake()
    {
        Eksperimen = 2;
        instance = this;
    }


    [Header("Main Animation")]
    public Animator SceneAnim;

    [Header("Step1 Animation")]

    public Animator bstep1;
    public Button button1;
    [Header("Step2 Animation")]

    public Animator bstep2;
    public Button button2;

    [Header("Step3 Animation")]

    public Animator bstep3;
    public Button button3;
    [Header("Step4 Animation")]

    public Animator bstep4;
    public Button button4;
    [Header("Step5 Animation")]

    public Animator bstep5;
    public Button button5;
    [Header("Step6 Animation")]

    public Animator bstep6;
    public Button button6;

    [Header("Step7 Animation")]

    public Animator bstep7;
    public Button button7;
    [Header("Step8 Animation")]

    public Animator bstep8;
    public Button button8;

    [Header("Step9 Animation")]

    public Animator bstep9;
    public Button button9;

    [Header("Step10-12 Animation")]

    public Animator bstep10_12;
    public Button button10_12;

    [Header("Step13_14 Animation")]

    public Animator bstep13_14;
    public Button button13_14;


    [Header("Step15 Animation")]

    public Animator bstep15;
    public Button button15;


    [Header("Step16 Animation")]

    public Animator bstep16;
    public Button button16;



    [Header("Step17 Animation")]

    public Animator bstep17;
    public Button button17;


    [Header("Step18_20 Animation")]

    public Animator bstep18_20;
    public Button button18_20;


    [Header("Step21 Animation")]

    public Animator bstep21;
    public Button button21;

    [Header("Step22_23 Animation")]

    public Animator bstep22_23;
    public Button button22_23;


    [Header("Step24 Animation")]

    public Animator bstep24;
    public Button button24;

    [Header("Step25_26 Animation")]

    public Animator bstep25_26;
    public Button button25_26;

    [Header("Step27 Animation")]
    public Animator anim;
    public Animator bstep27;
    public Button button27;


    [Header("References")]
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHistory;
    public TouchController touch;
    // Start is called before the first frame update
    void Start()
    {

        text = GameObject.Find("textInventory").GetComponent<TextMeshProUGUI>();
        touch = GetComponent<TouchController>();
    }
    public void Untouch()
    {
        for (int i = 0; i < touch.Barangs.Length; i++)
        {
            Debug.Log(touch.Barangs[i].GetChild(0));
            touch.Barangs[i].GetChild(0).GetComponent<SelectedController>().isToggle = false;
            touch.Barangs[i].GetChild(0).GetComponent<Outline>().enabled = false;
        }
    }
    IEnumerator TrueAndFalseWithTimeTwo(float time, int i, int l)
    {
        touch.Barangs[i].GetComponent<DragController>().isStop = true;
        touch.Barangs[l].GetComponent<DragController>().isStop = true;
        yield return new WaitForSeconds(time);

        touch.Barangs[i].GetComponent<DragController>().isStop = false;
        touch.Barangs[l].GetComponent<DragController>().isStop = false;
    }
    // Update is called once per frame
    void Update()
    {
        //step 1
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep1"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep1.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep1.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    //Debug.Log(touch.Barangs[0]);
                    text.text = "Tarik bikar ampaian kanji 1% ke silinder penyukat  ";
                    if (touch.Barangs[0].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[1].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step1");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 0, 1));
                        Untouch();
                    }

                }
            }
        }
        //step 2
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep2"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep2.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep2.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik silinder penyukat ke tabung uji A yang terletak pada rak tabung uji ";
                    textHistory.text = "1. Tarik bikar ampaian kanji 1% ke silinder penyukat ";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[2].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step2");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));
                        Untouch();
                    }

                }
            }
        }
        //step 3
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep3"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep3.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep3.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = " Tarik bikar ampaian kanji 1% ke silinder penyukat";
                    textHistory.text = "2. Tarik silinder penyukat ke tabung uji A yang terletak pada rak tabung uji";
                    if (touch.Barangs[0].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[1].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step3");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));
                        Untouch();
                    }

                }
            }
        }

        //step 4
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep4"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep4.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep4.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "  Tarik silinder penyukat ke tabung uji B yang terletak pada rak tabung uji   ";
                    textHistory.text = "3. Tarik bikar ampaian kanji 1% ke silinder penyukat";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[3].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step4");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));
                        Untouch();
                    }

                }
            }
        }

        //step 5
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep5"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep5.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep5.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik bikar larutan enzim amilase 0.5% ke silinder penyukat (3ml). ";
                    textHistory.text = "4. Tarik silinder penyukat ke tabung uji B yang terletak pada rak tabung uji  ";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[4].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step5");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 4));
                        Untouch();
                    }

                }
            }
        }

        //step 6
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep6"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep6.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep6.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik silinder penyukat ke tabung uji A. ";
                    textHistory.text = "5. Tarik bikar larutan enzim amilase 0.5% ke silinder penyukat (3ml). ";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[2].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step6");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 2));
                        Untouch();
                    }

                }
            }
        }

        //step 7
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep7"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep7.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep7.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik botol air suling ke silinder penyukat (3ml).    ";
                    textHistory.text = "6. Tarik silinder penyukat ke tabung uji A. ";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[5].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step7");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 5));
                        Untouch();
                    }

                }
            }
        }

        //step 8
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep8"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep8.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep8.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik silinder penyukat ke tabung uji B. ";
                    textHistory.text = "7. Tarik botol air suling ke silinder penyukat (3ml).    ";
                    if (touch.Barangs[1].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[3].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step8");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 1, 3));
                        Untouch();
                    }

                }
            }
        }


        //step 9
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep9"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep9.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep9.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Klik penunu Bunsen untuk panaskan    ";
                    textHistory.text = "8. Tarik silinder penyukat ke tabung uji B.";
                    if (
                    touch.Barangs[6].GetChild(0).GetComponent<SelectedController>().isToggle)
                    {
                        button9.gameObject.SetActive(true);
                        Untouch();
                    }

                }
            }
        }

        //step 10-12
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep10-12"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep10_12.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep10_12.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tekan tabung uji A \n Tekan tabung uji B dan juga pengukus air \n  Tetapkan jam randik pada 10 min. (tekan jam) ";

                    textHistory.text = "9.Klik penunu Bunsen untuk panaskan ";
                    //A B pengukus air dengan jam
                    if (touch.Barangs[2].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[3].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[7].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[8].GetChild(0).GetComponent<SelectedController>().isToggle)
                    {
                        button10_12.gameObject.SetActive(true);
                        Untouch();
                    }

                }
            }
        }

        //step 10-12
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep15"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep15.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep15.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penitis dan tabung uji A ";
                    textHistory.text = "10-12. Tekan tabung uji A \n Tekan tabung uji B dan juga pengukus air \n  Tetapkan jam randik pada 10 min. (murid tekan jam)  ";
                    //A B pengukus air dengan jam
                    if (touch.Barangs[2].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[9].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step15");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 9));
                        Untouch();
                    }

                }
            }
        }

        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep16"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep16.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep16.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penitis ke tabung uji baru C di lubang ketiga";
                    textHistory.text = "15. Tarik penitis ke tabung uji A ";

                    //A B pengukus air dengan jam
                    if (touch.Barangs[9].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[10].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step16");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 9, 10));
                        Untouch();
                    }

                }
            }
        }



        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep17"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep17.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep17.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penutup botol larutan Benedict ke tabung uji C (lubang ketiga) untuk titiskan 3 titis ";
                    textHistory.text = "16. Tarik penitis ke tabung uji baru C di lubang ketiga ";
                    //A B pengukus air dengan jam
                    if (touch.Barangs[9].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[10].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step17");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 9, 10));
                        Untouch();
                    }

                }
            }
        }

        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep18-20"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep18_20.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep18_20.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tekan Tabung uji C (warna biru) \n tekan kukus air,\n tekan Jam randik pusing 1 minit, \n    ";
                    textHistory.text = "18-20. Tekan penutup botol larutan Benedict dan tabung uji C (lubang ketiga) untuk titiskan 3 titis ";
                    //C pengukus air dengan jam
                    if (touch.Barangs[8].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[10].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[7].GetChild(0).GetComponent<SelectedController>().isToggle)
                    {
                        button18_20.gameObject.SetActive(true);
                        Untouch();
                    }

                }
            }
        }



        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep21"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep21.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep21.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penitis dari botol iodin ke tabung uji A.     ";
                    textHistory.text = "18-20. Tekan penutup botol larutan Benedict dan tabung uji C (lubang ketiga) untuk titiskan 3 titis ";
                    //C pengukus air dengan jam
                    if (touch.Barangs[2].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[9].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step21");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 2, 9));
                        Untouch();
                    }

                }
            }
        }


        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep22-23"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep22_23.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep22_23.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penitis ke tabung uji B, \n Tekan penitis dan tabung uji baru (D) lubang keempat";
                    textHistory.text = "21. Tarik penitis dari botol iodin ke tabung uji A.    ";
                    //C pengukus air dengan jam
                    if (touch.Barangs[3].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[9].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step22-23");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 3, 9));
                        Untouch();
                    }

                }
            }
        }

        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep24"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep24.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep24.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penutup botol larutan Benedict ke tabung uji D untuk titiskan 3 TITIS Larutan Benedict. ";
                    textHistory.text = "22-23. Tarik penitis ke tabung uji B, \n Tarik penitis ke tabung uji baru (D) lubang keempat ";
                    //C pengukus air dengan jam
                    if (touch.Barangs[13].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[9].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step24");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 13, 9));
                        Untouch();
                    }

                }
            }
        }



        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep25-26"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep25_26.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep25_26.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tekan Tabung uji D (warna biru) dan kukus air, \n Tekan Jam randik ";
                    textHistory.text = "24. Tekan penutup botol larutan Benedict dan tabung uji D untuk titiskan 3 TITIS Larutan Benedict. ";
                    //C pengukus air dengan jam
                    if (touch.Barangs[8].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[7].GetChild(0).GetComponent<SelectedController>().isToggle &&
                    touch.Barangs[13].GetChild(0).GetComponent<SelectedController>().isToggle)
                    {
                        button25_26.gameObject.SetActive(true);
                        Untouch();
                    }

                }
            }
        }
        if (SceneAnim.GetCurrentAnimatorStateInfo(0).IsName("bstep27"))
        {

            if (SceneAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !SceneAnim.IsInTransition(0))
            {
                if (bstep27.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !bstep27.IsInTransition(0) && !SceneAnim.IsInTransition(0))
                {
                    text.text = "Tarik penitis pada botol iodin ke tabung uji B";
                    textHistory.text = "25-26. Tekan Tabung uji D (warna biru) dan kukus air, \n Tekan Jam randik ";
                    //C pengukus air dengan jam
                    if (
                    touch.Barangs[3].GetComponent<IsCollided>().isCollide &&
                    touch.Barangs[9].GetComponent<IsCollided>().isCollide)
                    {
                        anim.Play("step27");
                        StartCoroutine(TrueAndFalseWithTimeTwo(2f, 3, 13));
                        Untouch();

                    }

                }
            }
        }

    }


}
