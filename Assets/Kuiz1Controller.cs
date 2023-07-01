using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuiz1Controller : MonoBehaviour
{
    public InputBehaviour[] inputs;
    // Start is called before the first frame update
    void Start()
    {   
        inputs = new InputBehaviour[transform.childCount];

        for(int i =0; i < inputs.Length; i++){
            inputs[i] = transform.GetChild(i).transform.GetChild(1).GetComponent<InputBehaviour>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
