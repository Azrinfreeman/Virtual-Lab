using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StoreEksController : MonoBehaviour
{
    public string Domain;

    public int no;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InsertEksperiment()
    {
        //StartCoroutine(InsertEks(Domain, KeputusanController.instance.score, no));
        PlayerPrefs.SetInt("k" + no, KeputusanController.instance.score);
    }
    IEnumerator InsertEks(string Domain, int score, int no)
    {
        WWWForm form = new WWWForm();
        form.AddField("_userid", PlayerPrefs.GetInt("id_user"));
        form.AddField("_userScore", score);
        form.AddField("_kuizNo", no);
        using (UnityWebRequest www = UnityWebRequest.Post(Domain + "insertEks.php", form))
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
                //if it's an id 
                if (www.downloadHandler.text.Equals("success"))
                {
                    Debug.Log(www.downloadHandler.text);

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
}
