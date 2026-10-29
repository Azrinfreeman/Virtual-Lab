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
    bool initialised;
    bool resultShown;

    void Start()
    {
        Init();
    }

    // Also called lazily: questions on hidden pages never get Start before the quiz is checked.
    void Init()
    {
        if(initialised) return;
        initialised = true;
       


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




    // Marks one option as chosen. Violet = "my choice"; red/green are reserved for evaluated results.
    void SetSelected(int index){
        for(int l = 0; l < transform.childCount; l++){
            bool chosen = l == index;
            NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked = chosen;
            tickImage[l].gameObject.SetActive(chosen);
            colorBlock = defaultColor;
            if(chosen){
                colorBlock.normalColor = BioPalette.Select;
                colorBlock.selectedColor = BioPalette.Select;
            }
            NoButtons[l].GetComponent<Button>().colors = colorBlock;
        }
    }

    public void ButtonClicked1(){ SetSelected(0); }
    public void ButtonClicked2(){ SetSelected(1); }
    public void ButtonClicked3(){ SetSelected(2); }
    public void ButtonClicked4(){ SetSelected(3); }

    /// <summary>
    /// Shown once the quiz is checked. Green + "Betul" marks the right option; red + "Salah" marks a wrong choice.
    /// Colour is paired with a word, so it never carries the meaning alone.
    /// </summary>
    public void ShowResult(){
        Init();
        if(resultShown) return;
        resultShown = true;
        for(int l = 0; l < transform.childCount; l++){
            bool correct = transform.GetChild(l).GetComponent<CorrectAnswer>() != null;
            bool chosen = NoButtons[l].GetComponent<ButtonBehaviour>().hasClicked;
            if(!correct && !chosen) continue;

            Color tint = correct ? BioPalette.Success : BioPalette.Error;
            colorBlock = defaultColor;
            colorBlock.normalColor = tint;
            colorBlock.highlightedColor = tint;
            colorBlock.selectedColor = tint;
            NoButtons[l].GetComponent<Button>().colors = colorBlock;

            var label = NoButtons[l].GetComponentInChildren<TMPro.TMP_Text>(true);
            if(label != null) label.text += correct ? "  - Betul" : "  - Salah";
            tickImage[l].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
