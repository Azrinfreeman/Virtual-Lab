using UnityEngine;

public class BioModalState : StateMachineBehaviour
{
    public bool opening;
    bool completed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        completed = false;
        var modal = animator.GetComponent<BioModal>();
        if (modal == null) return;
        animator.speed = BioMotion.Reduced ? 1000f : opening ? 5f : 6.25f;
        if (opening) modal.BeginOpen(); else modal.BeginClose();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (opening || completed || stateInfo.normalizedTime < 1f) return;
        completed = true;
        var modal = animator.GetComponent<BioModal>();
        if (modal != null) modal.CompleteClose();
    }
}
