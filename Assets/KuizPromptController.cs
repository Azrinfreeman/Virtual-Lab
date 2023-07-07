using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuizPromptController : MonoBehaviour
{
    public Transform[] aktiviti;
    public Transform promptStart;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("pernahjawab") == 1)
        {
            promptStart.gameObject.SetActive(true);
        }
        else
        {
            promptStart.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
