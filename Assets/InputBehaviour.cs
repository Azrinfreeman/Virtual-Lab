using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class InputBehaviour : MonoBehaviour
{
    public TMP_InputField text;
    public string answerText;
    public string answerText2;
    public string answerText3;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(answerText != null && answerText2 == null && answerText3 == null){
            if(text.text.ToUpper() == answerText.ToUpper()){
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = true;
            }else{
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = false;
            }
        }else if(answerText != null && answerText2 != null && answerText3 != null){
            if(text.text.ToUpper() == answerText2.ToUpper() || text.text.ToUpper() == answerText3.ToUpper() || text.text.ToUpper() == answerText.ToUpper() ){
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = true;
            }else{
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = false;
            }
        }
            
        
    }
}
