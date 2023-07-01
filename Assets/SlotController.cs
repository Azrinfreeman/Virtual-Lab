using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SlotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "5.4"){
            if(transform.GetChild(0).transform.name == transform.GetChild(0).transform.GetComponent<ItemSlot>().answerStore && 
            transform.GetChild(1).transform.name == transform.GetChild(1).transform.GetComponent<ItemSlot>().answerStore &&
            transform.GetChild(2).transform.name == transform.GetChild(2).transform.GetComponent<ItemSlot>().answerStore &&
            transform.GetChild(3).transform.name == transform.GetChild(3).transform.GetComponent<ItemSlot>().answerStore){
                KuizController.instance.soalanAnswer[7] = true;
            }else{
                KuizController.instance.soalanAnswer[7] = false;
            }
        }else if (SceneManager.GetActiveScene().name == "4.4"){

        }
    }


}
