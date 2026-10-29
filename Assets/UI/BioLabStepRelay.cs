using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BioLabStepRelay : MonoBehaviour
{
    public event Action<int> StepCompleted;
    public event Action<int> StepStarted;
    public int LastCompletedStep { get; private set; }
    public int CurrentStep { get; private set; }

    public void BeginStep(int step)
    {
        if (step == 1)
        {
            LastCompletedStep = 0;
            StepCompleted?.Invoke(0);
        }
        CurrentStep = step;
        StepStarted?.Invoke(step);
    }
    public void CompleteStep(int step)
    {
        LastCompletedStep = step;
        StepCompleted?.Invoke(step);
    }
}
