using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class BioMotionToggle : MonoBehaviour
{
    Toggle toggle;
    void OnEnable()
    {
        toggle = GetComponent<Toggle>();
        toggle.SetIsOnWithoutNotify(BioMotion.Reduced);
        toggle.onValueChanged.AddListener(BioMotion.SetReduced);
        BioMotion.Changed += Refresh;
    }
    void Refresh() => toggle.SetIsOnWithoutNotify(BioMotion.Reduced);
    void OnDisable()
    {
        if (toggle != null) toggle.onValueChanged.RemoveListener(BioMotion.SetReduced);
        BioMotion.Changed -= Refresh;
    }
}
