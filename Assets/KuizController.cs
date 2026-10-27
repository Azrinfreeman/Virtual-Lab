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

    public bool[] soalanAnswer;
    // Start is called before the first frame update
    void Start()
    {
        numSoalan = transform.childCount;
        NoSoalan = new Transform[numSoalan];

        for(int i =0; i < numSoalan; i++){
            NoSoalan[i] = transform.GetChild(i);
        }

        soalanAnswer = new bool[transform.childCount];
    }

    public void checkAnswers(){
        int total = 0;
        for(int i = 0; i < soalanAnswer.Length; i++){
            if(soalanAnswer[i]){
                total++;
            }
        }
        scores = total;
    }
    public void checkAnswers5Q(){
        int total = 0;
        for(int i = 0; i < soalanAnswer.Length; i++){
            if(soalanAnswer[i]){
                total +=2;
            }
        }
        scores = total;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
