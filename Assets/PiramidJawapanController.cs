using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiramidJawapanController : MonoBehaviour
{
    public Transform[] section = new Transform[8];

    public Transform[] winAndFail = new Transform[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(section[0].GetComponent<PiramidJawapan>().jawapanName != "" && section[1].GetComponent<PiramidJawapan>().jawapanName != "" 
        && section[2].GetComponent<PiramidJawapan>().jawapanName != "" && section[3].GetComponent<PiramidJawapan>().jawapanName != ""
        && section[4].GetComponent<PiramidJawapan>().jawapanName != "" && section[5].GetComponent<PiramidJawapan>().jawapanName != ""
        && section[6].GetComponent<PiramidJawapan>().jawapanName != "" && section[7].GetComponent<PiramidJawapan>().jawapanName != "")
        {
            if(
        section[0].GetComponent<PiramidJawapan>().jawapanName == "2010" && section[1].GetComponent<PiramidJawapan>().jawapanName == "2020" 
        && section[2].GetComponent<PiramidJawapan>().jawapanName == "1" && section[3].GetComponent<PiramidJawapan>().jawapanName == "2"
        && section[4].GetComponent<PiramidJawapan>().jawapanName == "3" && section[5].GetComponent<PiramidJawapan>().jawapanName == "4"
        && section[6].GetComponent<PiramidJawapan>().jawapanName == "5" && section[7].GetComponent<PiramidJawapan>().jawapanName == "6")
            {
                Debug.Log("correct");
                winAndFail[0].gameObject.SetActive(true);
                winAndFail[1].gameObject.SetActive(false);
            }else{
                Debug.Log("wrong");
                
                winAndFail[0].gameObject.SetActive(false);
                winAndFail[1].gameObject.SetActive(true);
            }

        }
    }
}
