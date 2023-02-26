using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveKuiz(int kuizNo){
        PlayerPrefs.SetInt("KuizNumber_"+kuizNo,KuizController.instance.scores);
    }
}
