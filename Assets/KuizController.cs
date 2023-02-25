using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KuizController : MonoBehaviour
{
    public static KuizController instance;

    private void Awake() {
        instance = this;
    }
    public int scores;
    public Transform[] NoSoalan;
    public int numSoalan;
    // Start is called before the first frame update
    void Start()
    {
        numSoalan = transform.childCount;
        NoSoalan = new Transform[numSoalan];

        for(int i =0; i < numSoalan; i++){
            NoSoalan[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
