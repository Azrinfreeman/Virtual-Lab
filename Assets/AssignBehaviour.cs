using System.Collections;
using System.Collections.Generic;
using OpenAI;
using UnityEngine;
using UnityEngine.UI;

public class AssignBehaviour : MonoBehaviour
{
    public string AssignToBehaviour;
    public ChatGPT chatGpt;

    // Start is called before the first frame update
    void Start()
    {
        var chatObject = GameObject.Find("ChatGPT");
        if (chatObject != null) chatGpt = chatObject.GetComponent<ChatGPT>();
        GetComponent<Button>().onClick.AddListener(SetBehaviours);
    }

    public void SetBehaviours()
    {
        var current = GameObject.Find("CurrentBehaviour");
        if (current != null && current.TryGetComponent<CheckBehaviour>(out var behaviour))
            behaviour.BehaviourName = AssignToBehaviour;
        if (chatGpt != null) chatGpt.ChangePrompt();
    }

    // Update is called once per frame
    void Update() { }
}
