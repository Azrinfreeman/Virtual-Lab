using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class WebController : MonoBehaviour
{
    public Transform loadingIcon;
    public string Domain;

    public TMP_InputField[] textField;
    public Transform[] errorText;

    public string username;
    public string email;
    public string password;
    public string password2;

    //public byte[] binaryData;
    // Start is called before the first frame update
    void Start()
    {

        textField = new TMP_InputField[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            textField[i] = transform.GetChild(i).GetComponent<TMP_InputField>();
        }

        //StartCoroutine(GetUsers(Domain));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InsertUser()
    {
        //assign
        username = textField[0].text;
        email = textField[1].text;
        password = textField[2].text;
        password2 = textField[3].text;
        //Debug.Log(username);
        StartCoroutine(InsertUser(Domain, username, email, password, password2));
    }

    IEnumerator InsertUser(string Domain, string username, string email, string password, string password2)
    {
        loadingIcon.gameObject.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("_loginName", username);
        form.AddField("_loginEmail", email);
        form.AddField("_loginPassword", password);
        form.AddField("_loginPassword2", password2);
        using (UnityWebRequest www = UnityWebRequest.Post(Domain + "InsertUser.php", form))
        {



            yield return www.SendWebRequest();


            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
                errorText[0].gameObject.SetActive(false);
                errorText[1].gameObject.SetActive(false);
                errorText[2].gameObject.SetActive(false);
                errorText[3].gameObject.SetActive(true);
                loadingIcon.gameObject.SetActive(false);
            }
            else
            {

                //show result as text .text
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Equals("username is ALREADY taken"))
                {
                    errorText[0].gameObject.SetActive(false);
                    errorText[1].gameObject.SetActive(true);
                    errorText[2].gameObject.SetActive(false);
                    errorText[3].gameObject.SetActive(false);

                    loadingIcon.gameObject.SetActive(false);
                }
                else if (www.downloadHandler.text.Equals("invalid password"))
                {
                    errorText[0].gameObject.SetActive(true);
                    errorText[1].gameObject.SetActive(false);
                    errorText[2].gameObject.SetActive(false);
                    errorText[3].gameObject.SetActive(false);
                    loadingIcon.gameObject.SetActive(false);
                }
                else if (www.downloadHandler.text.Equals("user inserted"))
                {
                    errorText[0].gameObject.SetActive(false);
                    errorText[1].gameObject.SetActive(false);
                    errorText[2].gameObject.SetActive(true);
                    errorText[3].gameObject.SetActive(false);
                    loadingIcon.gameObject.SetActive(false);
                }else if (www.downloadHandler.text.Equals("empty")){
                    errorText[4].gameObject.SetActive(true);
                    loadingIcon.gameObject.SetActive(false);
                }
                //show result as binary using []
                //binaryData = www.downloadHandler.data;
            }
        }
    }
}
