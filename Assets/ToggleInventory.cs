using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInventory : MonoBehaviour
{
    bool istoggle;
    public Animator inventoryAnim;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=> toggle());
        inventoryAnim = transform.parent.transform.parent.GetChild(1).GetComponent<Animator>();
    }

    public void toggle()
    {
        if (!istoggle)
        {
            inventoryAnim.Play("inventoryStartAnim");
            istoggle = true;
        }
        else
        {
            
            inventoryAnim.Play("inventoryStopAnim");
            istoggle = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
