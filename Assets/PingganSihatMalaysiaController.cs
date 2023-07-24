using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingganSihatMalaysiaController : MonoBehaviour
{
    public Transform[] section = new Transform[4];

    public Transform[] winAndFail = new Transform[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(section[0].GetComponent<PingganName>().plateName != "" && section[1].GetComponent<PingganName>().plateName != "" 
        && section[2].GetComponent<PingganName>().plateName != "" && section[3].GetComponent<PingganName>().plateName != "")
        {
            if(section[0].GetComponent<PingganName>().plateName.ToUpper() == "IKAN" || section[0].GetComponent<PingganName>().plateName.ToUpper() == "NASI" 
            && section[1].GetComponent<PingganName>().plateName.ToUpper() == "NASI" || section[1].GetComponent<PingganName>().plateName.ToUpper() == "IKAN" 
            && section[2].GetComponent<PingganName>().plateName.ToUpper() == "BUAH" || section[2].GetComponent<PingganName>().plateName.ToUpper() == "SAYUR"
            && section[3].GetComponent<PingganName>().plateName.ToUpper() == "SAYUR"|| section[3].GetComponent<PingganName>().plateName.ToUpper() == "BUAH")
            {
                Debug.Log("correct");
                winAndFail[3].gameObject.SetActive(true);
                winAndFail[2].gameObject.SetActive(false);
                PlayerPrefs.SetInt("pernahjawab",1);
            }else{
                Debug.Log("wrong");
                
                winAndFail[0].gameObject.SetActive(false);
                winAndFail[1].gameObject.SetActive(true);
            }

        }
    }
}
