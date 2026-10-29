using UnityEngine;

// Only assigned to the audited ambient artwork controllers, never experiment animators.
[RequireComponent(typeof(Animator))]
public class BioDecorativeMotion : MonoBehaviour
{
    Animator animator;
    void Awake() => animator = GetComponent<Animator>();
    void OnEnable() { BioMotion.Changed += Refresh; Refresh(); }
    void OnDisable() => BioMotion.Changed -= Refresh;
    void Refresh() { if (animator != null) animator.enabled = !BioMotion.Reduced; }
}
