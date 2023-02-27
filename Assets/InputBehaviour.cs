using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class InputBehaviour : MonoBehaviour
{
    public TMP_InputField text;
    public string answerText;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if(text.text.ToUpper() == answerText){
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = true;
            }else{
                KuizController.instance.soalanAnswer[transform.parent.transform.parent.GetSiblingIndex()] = false;
            }
        
    }
}
