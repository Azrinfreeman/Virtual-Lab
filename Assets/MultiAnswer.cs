using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiAnswer : MonoBehaviour
{
    public Toggle[] answers;
    // Start is called before the first frame update
    void Start()
    {
        answers = new Toggle[transform.childCount];
        for(int i = 0; i< transform.childCount; i++){
            answers[i] = transform.GetChild(i).GetComponent<Toggle>();
        }



    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< transform.childCount;i++){
            if(answers[i].isOn && answers[i]){

            }
        }
        
    }
}
