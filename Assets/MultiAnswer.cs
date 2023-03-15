using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MultiAnswer : MonoBehaviour
{
    public Toggle[] answers;

    public bool[] answersTick;
    public int answerCount;

    public List<int> storeAnswers;
    public bool isTrue=false;
    // Start is called before the first frame update
    void Start()
    {
        answers = new Toggle[transform.childCount];
        
        
        for(int i = 0; i< transform.childCount; i++){
            answers[i] = transform.GetChild(i).GetComponent<Toggle>();
            
        }

        
        

  
    }

    public void checkAnswers(){
        
        if(SceneManager.GetActiveScene().name == "2.4"){

            if(transform.parent.name == "1"){

            
                if(answers[0].isOn && !answers[1].isOn && !answers[2].isOn && answers[3].isOn && answers[4].isOn ){
                
                isTrue = true;
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()]= true;
                }else{
                isTrue = false;
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()]= false;
                }

            }else if (transform.parent.transform.parent.name == "10"){

            }


        }else if(SceneManager.GetActiveScene().name == "5.4"){

           

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
            
        checkAnswers();

       
            
        
        
        
    }
}
