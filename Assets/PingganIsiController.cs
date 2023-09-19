using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingganIsiController : MonoBehaviour
{
    [SerializeField] private Transform[] namaplate;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("pinggan1").Equals("IKAN"))
        {
            namaplate[0].GetChild(0).gameObject.SetActive(true);
            namaplate[0].GetChild(1).gameObject.SetActive(false);
            
        
        }
        else if (PlayerPrefs.GetString("pinggan1").Equals("NASI"))
        {
            namaplate[0].GetChild(0).gameObject.SetActive(false);
            namaplate[0].GetChild(1).gameObject.SetActive(true);
        }
        //
        if (PlayerPrefs.GetString("pinggan2").Equals("IKAN"))
        {
            namaplate[1].GetChild(0).gameObject.SetActive(true);
            namaplate[1].GetChild(1).gameObject.SetActive(false);
            
        

        }
        else if (PlayerPrefs.GetString("pinggan2").Equals("NASI"))
        {
            namaplate[1].GetChild(0).gameObject.SetActive(false);
            namaplate[1].GetChild(1).gameObject.SetActive(true);
            
     

        }
        //
        
        if (PlayerPrefs.GetString("pinggan3").Equals("BUAH"))
        {
            namaplate[2].GetChild(0).gameObject.SetActive(true);
            namaplate[2].GetChild(1).gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetString("pinggan3").Equals("SAYUR"))
        {
            namaplate[2].GetChild(0).gameObject.SetActive(false);
            namaplate[2].GetChild(1).gameObject.SetActive(true);
        }
        //

        
        if (PlayerPrefs.GetString("pinggan4").Equals("BUAH"))
        {
            namaplate[3].GetChild(0).gameObject.SetActive(true);
            namaplate[3].GetChild(1).gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetString("pinggan4").Equals("SAYUR"))
        {
            namaplate[3].GetChild(0).gameObject.SetActive(false);
            namaplate[3].GetChild(1).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
