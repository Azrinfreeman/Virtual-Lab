using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{
    public Animator mainScene;
    public Slider slider;
    public TextMeshProUGUI text;
    public int no;
    public TextMeshProUGUI stepLabel;
    BioLabStepRelay relay;
    Coroutine fill;

    public static int[] Milestones(int activity)
    {
        switch (activity)
        {
            case 2: case 4: return new[] { 1, 7, 14, 23, 27 };
            case 3: return new[] { 1, 7, 10, 15, 20 };
            case 5: return new[] { 1, 7, 15, 23, 31 };
            case 6: return new[] { 1, 7, 13, 19, 26 };
            case 7: return new[] { 1, 7, 15, 23, 28 };
            default: return new int[0];
        }
    }
    void Start()
    {
        if (mainScene == null)
        {
            var owner = GameObject.Find("GameObject (1)");
            if (owner != null) mainScene = owner.GetComponent<Animator>();
        }
        if (slider == null) slider = GetComponent<Slider>();
        if (text == null) text = GetComponentInChildren<TextMeshProUGUI>(true);
        if (mainScene == null) return;
        relay = mainScene.GetComponent<BioLabStepRelay>();
        if (relay == null) return;
        relay.StepCompleted += OnStepCompleted;
        relay.StepStarted += OnStepStarted;
        OnStepCompleted(relay.LastCompletedStep);
        OnStepStarted(relay.CurrentStep);
    }
    public void OnStepCompleted(int step)
    {
        int[] milestones = Milestones(no);
        int[] values = { 1, 25, 50, 75, 100 };
        if (step == 0) { SetProgress(0); return; }
        for (int i = milestones.Length - 1; i >= 0; i--)
            if (step >= milestones[i]) { SetProgress(values[i]); return; }
    }
    void OnStepStarted(int step)
    {
        int[] milestones = Milestones(no);
        if (stepLabel != null && milestones.Length > 0)
            stepLabel.text = "Langkah " + Mathf.Max(1, step) + " / " + milestones[milestones.Length - 1];
    }
    public void SetProgress(int value)
    {
        value = Mathf.Clamp(value, 0, 100);
        if (text != null) text.text = value + "%";
        if (slider == null) return;
        if (fill != null) StopCoroutine(fill);
        if (BioMotion.Reduced || !Application.isPlaying || !isActiveAndEnabled || value == 0)
            slider.SetValueWithoutNotify(value);
        else fill = StartCoroutine(Fill(value));
    }
    IEnumerator Fill(int value)
    {
        float from = slider.value;
        for (float t = 0; t < .18f; t += Time.unscaledDeltaTime)
        {
            slider.SetValueWithoutNotify(Mathf.Lerp(from, value, BioMotion.Ease(t / .18f)));
            yield return null;
        }
        slider.SetValueWithoutNotify(value);
        fill = null;
    }
    void OnDestroy()
    {
        if (relay == null) return;
        relay.StepCompleted -= OnStepCompleted;
        relay.StepStarted -= OnStepStarted;
    }
}
