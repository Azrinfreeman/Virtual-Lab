using UnityEngine;

public class PingganSihatMalaysiaController : MonoBehaviour
{
    public Transform[] section = new Transform[4];
    // Scene order: explanation, failure, quiz, completion prompt.
    public Transform[] winAndFail = new Transform[4];
    private string lastArrangement;

    public static bool IsCorrectArrangement(string a, string b, string c, string d)
    {
        a = Normalize(a); b = Normalize(b); c = Normalize(c); d = Normalize(d);
        bool firstPair = (a == "IKAN" && b == "NASI") || (a == "NASI" && b == "IKAN");
        bool secondPair = (c == "BUAH" && d == "SAYUR") || (c == "SAYUR" && d == "BUAH");
        return firstPair && secondPair;
    }

    private static string Normalize(string value)
    {
        return (value ?? "").Trim().ToUpperInvariant();
    }

    void Update()
    {
        string a = Normalize(section[0].GetComponent<PingganName>().plateName);
        string b = Normalize(section[1].GetComponent<PingganName>().plateName);
        string c = Normalize(section[2].GetComponent<PingganName>().plateName);
        string d = Normalize(section[3].GetComponent<PingganName>().plateName);
        string arrangement = a + "|" + b + "|" + c + "|" + d;
        // Do not reopen dismissed prompts or write preferences every frame.
        if (arrangement == lastArrangement) return;
        lastArrangement = arrangement;
        bool complete = a.Length > 0 && b.Length > 0 && c.Length > 0 && d.Length > 0;
        bool correct = IsCorrectArrangement(a, b, c, d);
        winAndFail[1].gameObject.SetActive(complete && !correct);
        winAndFail[3].gameObject.SetActive(correct);
        if (complete && !correct) winAndFail[0].gameObject.SetActive(false);
        if (!correct) return;
        PlayerPrefs.SetString("pinggan1", a);
        PlayerPrefs.SetString("pinggan2", b);
        PlayerPrefs.SetString("pinggan3", c);
        PlayerPrefs.SetString("pinggan4", d);
        PlayerPrefs.SetInt("pernahjawab", 1);
        winAndFail[2].gameObject.SetActive(false);
    }
}
