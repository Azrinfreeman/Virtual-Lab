using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class LoadUserScore : MonoBehaviour
{
    public string Domain;
    public int no;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (no == 2)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        else if (no == 3)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        else if (no == 4)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        else if (no == 5)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        else if (no == 6)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        else if (no == 7)
        {
            //text.text = PlayerPrefs.GetInt("KuizNumber_"+no).ToString() + " / 10";
            StartCoroutine(GetKuizData(Domain, no));
        }
        //StartCoroutine(GetKuizData(Domain, no));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetKuizData(string Domain, int no)
    {

        WWWForm form = new WWWForm();
        form.AddField("_userid", PlayerPrefs.GetInt("id_user"));
        form.AddField("_kuizNo", no);
        using (UnityWebRequest www = UnityWebRequest.Post(Domain + "fetchKuiz.php", form))
        {
            yield return www.SendWebRequest();

            Debug.Log(PlayerPrefs.GetInt("id_user"));
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {

                //show result as text .text
                Debug.Log(www.downloadHandler.text);
                //if it's an id 
                if (www.downloadHandler.text == "error")
                {
                    text.text = "0/10";
                }
                else
                {

                    text.text = www.downloadHandler.text + " / 10";
                }
                //show result as binary using []
                //binaryData = www.downloadHandler.data;
            }
        }
    }
}
