using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnswers : MonoBehaviour
{
    public Transform[] NoButtons;
    public Transform[] tickImage;
    public ColorBlock colorBlock;
    public ColorBlock defaultColor;



    public void Correct(){
        KuizController.instance.soalanAnswer[transform.parent.GetSiblingIndex()] = true;
    }
    public void Wrong(){
        KuizController.instance.soalanAnswer[transform.parent.GetSiblingIndex()] = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       


        NoButtons = new Transform[transform.childCount];
        tickImage = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount;i++){
            NoButtons[i] = transform.GetChild(i).transform.GetComponent<Transform>();
            tickImage[i] = transform.GetChild(i).transform.GetChild(1).transform.GetComponent<Transform>();

            
        
        }
        colorBlock = NoButtons[0].GetComponent<Button>().colors;
        defaultColor = colorBlock;

        //Button Behaviours
        for(int l = 0; l < transform.childCount;l++){
            if(l == 0){
            transform.GetChild(l).transform.GetComponent<Button>().onClick.AddListener(ButtonClicked1);
            }else if (l == 1){
            transform.GetChild(l).transform.GetComponent<Button>().onClick.AddListener(ButtonClicked2);
            }
            else if (l == 2){
            transform.GetChild(l).transform.GetComponent<Button>().onClick.AddListener(ButtonClicked3);
            }else if (l == 3){
            transform.GetChild(l).transform.GetComponent<Button>().onClick.AddListener(ButtonClicked4);
            }
        }

        for(int j = 0; j < transform.childCount;j++){
            CorrectAnswer CA = transform.GetChild(j).GetComponent<CorrectAnswer>();

            if(CA){
                transform.GetChild(j).GetComponent<Button>().onClick.AddListener(Correct);
            }else{
                transform.GetChild(j).GetComponent<Button>().onClick.AddListener(Wrong);
            }
        }
    }




    public void ButtonClicked1(){




        for(int l = 0; l < transform.childCount; l++){
            
        
            
            if(l == 0){
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = true;
                tickImage[l].gameObject.SetActive(true);
                colorBlock.normalColor = Color.red;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }else{
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = false;
                tickImage[l].gameObject.SetActive(false);
                colorBlock= defaultColor;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }
        
        }
    }
    public void ButtonClicked2(){

        for(int l = 0; l < transform.childCount; l++){
            if(l == 1){
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = true;
                tickImage[l].gameObject.SetActive(true);
                colorBlock.normalColor = Color.red;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }else{
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = false;
                tickImage[l].gameObject.SetActive(false);
                colorBlock= defaultColor;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }
        }
    }

    public void ButtonClicked3(){

        for(int l = 0; l < transform.childCount; l++){
            if(l == 2){
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = true;
                tickImage[l].gameObject.SetActive(true);
                colorBlock.normalColor = Color.red;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }else{
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = false;
                tickImage[l].gameObject.SetActive(false);
                colorBlock= defaultColor;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }
        }
    }

    public void ButtonClicked4(){

        for(int l = 0; l < transform.childCount; l++){
            if(l == 3){
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = true;
                tickImage[l].gameObject.SetActive(true);
                colorBlock.normalColor = Color.red;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }else{
                NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = false;
                tickImage[l].gameObject.SetActive(false);
                colorBlock= defaultColor;
                NoButtons[l].GetComponent<Button>().colors = colorBlock;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
