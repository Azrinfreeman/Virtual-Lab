using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KuizController : MonoBehaviour
{
    public static KuizController instance;

    private void Awake() {
        instance = this;
    }
    public int scores;
    public Transform[] NoSoalan;
    public int numSoalan;

    public bool[] soalanAnswer;
    // Start is called before the first frame update
    void Start()
    {
        numSoalan = transform.childCount;
        NoSoalan = new Transform[numSoalan];

        for(int i =0; i < numSoalan; i++){
            NoSoalan[i] = transform.GetChild(i);
        }

        soalanAnswer = new bool[transform.childCount];
    }

    public void checkAnswers(){
        int total = 0;
        for(int i = 0; i < soalanAnswer.Length; i++){
            if(soalanAnswer[i]){
                total++;
            }
        }
        scores = total;
        ShowResults();
    }
    public void checkAnswers5Q(){
        int total = 0;
        for(int i = 0; i < soalanAnswer.Length; i++){
            if(soalanAnswer[i]){
                total +=2;
            }
        }
        scores = total;
        ShowResults();
    }

    void ShowResults(){
        foreach(var options in GetComponentsInChildren<ButtonAnswers>(true)){
            options.ShowResult();
        }
        // Every question type (options, drag-and-drop, typed, tick boxes) feeds soalanAnswer,
        // so a per-question badge gives right/wrong feedback for all of them.
        for(int i = 0; i < NoSoalan.Length && i < soalanAnswer.Length; i++){
            ShowBadge(NoSoalan[i], soalanAnswer[i]);
        }
    }

    // Green "Betul" / red "Salah" chip at the question's top-right. Word + colour, never colour alone.
    static void ShowBadge(Transform question, bool correct){
        const string badgeName = "ResultBadge";
        Transform badge = question.Find(badgeName);
        TMPro.TextMeshProUGUI label;
        Image bg;
        if(badge == null){
            var go = new GameObject(badgeName, typeof(RectTransform), typeof(Image));
            badge = go.transform;
            badge.SetParent(question, false);
            var rt = (RectTransform)badge;
            rt.anchorMin = rt.anchorMax = rt.pivot = new Vector2(1f, 1f);
            rt.sizeDelta = new Vector2(130f, 44f);
            rt.anchoredPosition = new Vector2(-24f, -24f);
            go.GetComponent<Image>().raycastTarget = false;

            var textGo = new GameObject("Text", typeof(RectTransform), typeof(TMPro.TextMeshProUGUI));
            textGo.transform.SetParent(badge, false);
            var trt = (RectTransform)textGo.transform;
            trt.anchorMin = Vector2.zero; trt.anchorMax = Vector2.one; trt.offsetMin = trt.offsetMax = Vector2.zero;
            var t = textGo.GetComponent<TMPro.TextMeshProUGUI>();
            var reference = question.GetComponentInChildren<TMPro.TMP_Text>(true);
            if(reference != null) t.font = reference.font;
            t.alignment = TMPro.TextAlignmentOptions.Center;
            t.fontSize = 28;
            t.raycastTarget = false;
        }
        label = badge.GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
        bg = badge.GetComponent<Image>();
        bg.color = correct ? BioPalette.Success : BioPalette.Error;
        label.color = correct ? new Color32(0x06, 0x2B, 0x1A, 255) : new Color32(0x3A, 0x0A, 0x0A, 255);
        label.text = correct ? "Betul" : "Salah";
        badge.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
