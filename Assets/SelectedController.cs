using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedController : MonoBehaviour
{
    public bool isSelected;
    public bool isToggle;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Outline>().OutlineColor = Color.yellow;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
