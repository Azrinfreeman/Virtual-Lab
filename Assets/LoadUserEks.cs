using TMPro;
using UnityEngine;

public class LoadUserEks : MonoBehaviour
{
    public string Domain;
    public int no;
    public TextMeshProUGUI text;
    void Start()
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BioScoreLoader.Load(text, Domain, no, false));
    }
}
