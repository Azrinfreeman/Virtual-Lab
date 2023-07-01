using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class loadScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        KeputusanController.instance.CheckAnswer();
        text.text = KeputusanController.instance.score+" / "+ KeputusanController.instance.Jawapan.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
