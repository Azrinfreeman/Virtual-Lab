using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text= GetComponent<TextMeshProUGUI>();
        text.text = "Markah: "+KuizController.instance.scores.ToString() + " / 10 ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
