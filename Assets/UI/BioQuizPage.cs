using UnityEngine;

public class BioQuizPage : MonoBehaviour
{
    public KuizController quiz;
    public int index;
    void OnEnable() { if (quiz != null) quiz.SetCurrentQuestion(index); }
}
