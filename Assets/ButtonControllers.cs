using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllers : MonoBehaviour
{

    public static ButtonControllers instance;

    private void Awake() {
        instance = this;
    }
    public Transform[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = new Transform[transform.childCount];

        for(int i = 0; i <transform.childCount; i++){
            buttons[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
