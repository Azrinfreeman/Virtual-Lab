using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string name)
    {
        BioSceneTransition.Load(name);

    }

    public void Logout(){
        PlayerPrefs.SetInt("id_user",0);
        var chatbot = GameObject.Find("ChatGPT");
        if (chatbot != null && chatbot.TryGetComponent<OpenAI.ChatGPT>(out var chat))
            chat.SetSessionToken(null);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
