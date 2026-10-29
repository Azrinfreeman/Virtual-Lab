using UnityEngine;

public class BioLabStepState : StateMachineBehaviour
{
    public int step;
    public int startStep;
    bool completed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        completed = false;
        var relay = animator.GetComponent<BioLabStepRelay>();
        if (relay != null) relay.BeginStep(startStep > 0 ? startStep : step);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo info, int layerIndex)
    {
        // Preserve the former progress gate: finished current state, not during a transition.
        if (completed || info.normalizedTime < 1f || animator.IsInTransition(layerIndex)) return;
        completed = true;
        var relay = animator.GetComponent<BioLabStepRelay>();
        if (relay != null) relay.CompleteStep(step);
    }
}
