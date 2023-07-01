using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionController : MonoBehaviour
{
    public Transform[] items;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {

            items[i] = transform.GetChild(1).GetChild(i).GetComponent<Transform>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (items[0].GetComponent<ItemSlot>().answerStore.ToUpper().Equals("PROTEIN") &&
        items[1].GetComponent<ItemSlot>().answerStore.ToUpper().Equals("AIR") &&
        items[2].GetComponent<ItemSlot>().answerStore.ToUpper().Equals("POLIPEPTIDA"))
        {
            KuizController.instance.soalanAnswer[6] = true;
        }
        else
        {
            KuizController.instance.soalanAnswer[6] = false;
        }
    }
}
