using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProgressController : MonoBehaviour
{
    public Animator mainScene;
    public Slider slider;
    public TextMeshProUGUI text;

    public int no;
    // Start is called before the first frame update
    void Start()
    {
        mainScene = GameObject.Find("GameObject (1)").GetComponent<Animator>();
        slider = GetComponent<Slider>();
        text = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (no == 2)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step14"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step23"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)75;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step27"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
        else if (no == 3)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step10"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step15"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step20"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
        else if (no == 4)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step14"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step23"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)75;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step27"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
        else if (no == 5)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step15"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step23"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)75;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step31"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
        else if (no == 6)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step13"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step19"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)75;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step25"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
        else if (no == 7)
        {
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step1"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)1;
                    text.text = "1%";
                }
            }
            if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step7"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)25;
                    text.text = "25%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step15"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)50;
                    text.text = "50%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step23"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)75;
                    text.text = "75%";
                }
            }
            else if (mainScene.GetCurrentAnimatorStateInfo(0).IsName("step31"))
            {

                if (mainScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainScene.IsInTransition(0))
                {
                    slider.value = (float)100;
                    text.text = "100%";
                }
            }
        }
    }
}
