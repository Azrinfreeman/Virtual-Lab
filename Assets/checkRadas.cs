using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class checkRadas : MonoBehaviour
{
    public Toggle[] toggles;
    public int numofToggles;

    public Button mulaButton;
    // Start is called before the first frame update
    void Start()
    {
        mulaButton = GameObject.Find("btnYa").GetComponent<Button>();
        mulaButton.interactable = false;
        numofToggles = transform.childCount;
        toggles = new Toggle[numofToggles];

        for(int i =0; i < numofToggles;i++){
            toggles[i] = transform.GetChild(i).GetComponent<Toggle>();
        }

    }

    public void checkingLoop(){
        for(int l = 0; l < numofToggles; l++){
            if(toggles[l].isOn){
                mulaButton.interactable = true;
            }else{
                mulaButton.interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkingLoop();
    }
}
