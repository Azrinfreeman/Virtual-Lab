using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class updatePercentage : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        // Lab progress owns its label; do not compete with its final-value announcement.
        if (GetComponentInParent<ProgressController>() != null) return;
        if (slider == null) slider = GetComponentInParent<Slider>();
        if (slider == null) return;
        slider.onValueChanged.AddListener(Refresh);
        Refresh(slider.value);
    }
    void Refresh(float value) { if (text != null) text.text = value.ToString("0") + " %"; }
    void OnDestroy() { if (slider != null) slider.onValueChanged.RemoveListener(Refresh); }
}
