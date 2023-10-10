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

    IEnumerator waits(string name)
    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }

    public void ChangeScene(string name)
    {
        StartCoroutine(waits(name));

    }

    public void Logout(){
        PlayerPrefs.SetInt("id_user",0);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
