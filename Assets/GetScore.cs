using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetScore : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (SceneManager.GetActiveScene().name == "7.4")
        {
            text.text = "Markah: " + KuizController.instance.scores.ToString() + " / 10";
        }
        else
        {
            text.text =
                "Markah: "
                + KuizController.instance.scores.ToString()
                + " / "
                + KuizController.instance.numSoalan.ToString();
        }
    }

    // Update is called once per frame
    void Update() { }
}
