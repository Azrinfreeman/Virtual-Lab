using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursors : MonoBehaviour
{   
    public static Cursors instance; 
    private void Awake() {
        instance = this;
    }
    public Transform[] cursors;
    // Start is called before the first frame update
    void Start()
    {
        cursors = new Transform[2];

        for(int i = 0; i < 2; i++){
            cursors[i] = transform.GetChild(i).GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
