using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleButton : MonoBehaviour
{
    public bool isToggle;
    public Transform item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowOrHide(){
        if(!isToggle){
            item.gameObject.SetActive(true);
            isToggle = true;
        }
        else{
            item.gameObject.SetActive(false);
            isToggle = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
