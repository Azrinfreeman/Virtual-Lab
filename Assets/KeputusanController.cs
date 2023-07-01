using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeputusanController : MonoBehaviour
{
    public static KeputusanController instance;

    public int score;
    private void Awake() {
        instance = this;
    }
    public bool[] Jawapan;
    // Start is called before the first frame update
    void Start()
    {
        Jawapan = new bool[transform.childCount];
        Jawapan[transform.childCount - 3] = true;
    }

    public void CheckAnswer(){
        for(int i =0; i < transform.childCount; i++){
            if(Jawapan[i]){
                score++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
