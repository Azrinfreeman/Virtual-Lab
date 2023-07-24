using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginController : MonoBehaviour
{
    public static LoginController instance;

    private void Awake()
    {
        instance = this;
    }
    public string Domain;
    public Transform loadingIcon;
    public Transform errorText;
    public TMP_InputField[] text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Login()
    {
        //StartCoroutine(LoginUser(Domain, text[0].text, text[1].text));
        SceneManager.LoadScene("MainMenu");
    }

    public void InsertKuizEks()
    {
        StartCoroutine(InsertKuizAndEks(Domain, text[0].text));
    }
    
    IEnumerator InsertKuizAndEks(string Domain, string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("_loginName", username);
        using (UnityWebRequest www = UnityWebRequest.Post(Domain + "InsertKuizAndEks.php", form))
        {



            yield return www.SendWebRequest();


            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {

                //show result as text .text
                //.Log(www.downloadHandler.text);
                Debug.Log(www.downloadHandler.text);
                //if it's an id 
                if (int.TryParse(www.downloadHandler.text, out int value))
                {
                    PlayerPrefs.SetInt("id_user", value);
                    Debug.Log(PlayerPrefs.GetInt("id_user"));

                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
                //show result as binary using []
                //binaryData = www.downloadHandler.data;
            }
        }
    }


    IEnumerator LoginUser(string Domain, string username, string password)
    {
        loadingIcon.gameObject.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("_loginName", username);
        form.AddField("_loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post(Domain + "LoginUser.php", form))
        {



            yield return www.SendWebRequest();


            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
                loadingIcon.gameObject.SetActive(false);
                errorText.gameObject.SetActive(true);
                errorText.GetComponent<TextMeshProUGUI>().text = www.error;
            }
            else
            {
                

                //show result as text .text
                //.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Equals("login valid"))
                {
                    PlayerPrefs.SetString("username", username);
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    errorText.gameObject.SetActive(true);
                    loadingIcon.gameObject.SetActive(false);
                }
                //show result as binary using []
                //binaryData = www.downloadHandler.data;
            }
        }
    }
}
