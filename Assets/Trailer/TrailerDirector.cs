#if UNITY_EDITOR
using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Recording-only orchestration. Excluded from player builds; never attached to saved scenes.
public class TrailerDirector : MonoBehaviour
{
    public static string Status = "Idle";
    private int frame;
    private RenderTexture target;
    private Texture2D pixels;
    private Camera renderCamera;
    private TMP_Text caption;
    private GameObject captionRoot;
    private int previousCaptureRate;
    private int oldCompleted;
    private string[] oldPlate;
    private readonly string folder = "Temp/Trailer/frames";
    private int lastAction = -1;
    private bool begun;
    private bool patchOnly;
    private bool patchEnd;
    public static void PatchEnding()
    {
        var d = new GameObject("Trailer ending takes").AddComponent<TrailerDirector>();
        d.patchEnd = true;
        d.StartCoroutine("Start");
    }
    public static void PatchShots()
    {
        var d = new GameObject("Trailer replacement takes").AddComponent<TrailerDirector>();
        d.patchOnly = true;
        d.StartCoroutine("Start");
    }

    public static void Begin()
    {
        if (!Application.isPlaying) throw new InvalidOperationException("Enter Play Mode first");
        if (FindFirstObjectByType<TrailerDirector>() != null) return;
        new GameObject("Trailer recording only").AddComponent<TrailerDirector>();
    }

    IEnumerator Start()
    {
        if (begun) yield break;
        begun = true;
        DontDestroyOnLoad(gameObject);
        Directory.CreateDirectory(folder);
        previousCaptureRate = Time.captureFramerate;
        Time.captureFramerate = 30;
        oldCompleted = PlayerPrefs.GetInt("pernahjawab");
        oldPlate = Enumerable.Range(1,4).Select(i=>PlayerPrefs.GetString("pinggan"+i)).ToArray();
        SceneManager.sceneLoaded += OnScene;
        if (patchEnd)
        {
            frame=1470;
            yield return Load("2.4");
            yield return Record(6,"Uji kefahaman anda",t=>{
                var m=FindObjectsByType<MultiAnswer>(FindObjectsSortMode.None).FirstOrDefault(x=>x.transform.parent.name=="1");
                if(m==null || m.answers==null || m.answers.Length<5)return;
                if(t>1)m.answers[0].isOn=true;
                if(t>2)m.answers[3].isOn=true;
                if(t>3)m.answers[4].isOn=true;
            });
            yield return Load("2.2");
            PrepareLab("beauty",0);
            yield return Record(5,"BioNutri-MM",t=>renderCamera.transform.position+=Vector3.left*0.003f);
            Status="ENDING COMPLETE";
            Cleanup();UnityEditor.EditorApplication.isPlaying=false;
            yield break;
        }
        if (patchOnly)
        {
            frame = 870;
            yield return Load("6.2");
            PrepareLab("step10", 0);
            yield return Record(7,"Bandingkan kandungan vitamin C",t=>{
                if(t>3.5f && lastAction<1){lastAction=1;PlayLab("step14");}
            });
            yield return Load("1.1");
            yield return Record(2,"Kenali sistem pencernaan manusia",t=>{
                if(renderCamera!=null)renderCamera.fieldOfView=60-t*1.5f;
            });
            Status="PATCH COMPLETE";
            File.WriteAllText("Temp/Trailer/patch-complete.txt",Status);
            Cleanup();
            UnityEditor.EditorApplication.isPlaying=false;
            yield break;
        }
        // Same project scenes and authored animations; pauses are removed in the edit.
        yield return Load("2.2");
        PrepareLab("beauty", 0);
        yield return Record(4, "Terokai sains melalui pengalaman", t => {
            if (renderCamera != null) renderCamera.transform.position += Vector3.right * 0.004f;
        });
        yield return Load("MainMenuAktiviti");
        yield return Record(5, "8 aktiviti pembelajaran interaktif", t => {
            var button = FindObjectsByType<Button>(FindObjectsSortMode.None).FirstOrDefault(b=>b.name=="btn2");
            if (button != null && UnityEngine.EventSystems.EventSystem.current != null)
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(button.gameObject);
        });
        yield return Load("2.2");
        PrepareLab("step1", 0);
        yield return Record(11, "Kendalikan eksperimen dalam makmal 3D", t => {
            if(t>5 && lastAction<1){lastAction=1; PlayLab("step2");}
        });
        PrepareLab("step18-20", 0);
        yield return Record(9, "Perhati perubahan. Fahami tindak balas.  |  Masa dipercepat", t => {
            if(t>5 && lastAction<1){lastAction=1;PlayLab("step25-26");}
        });
        yield return Load("6.2");
        PrepareLab("step10", 0);
        yield return Record(7, "Bandingkan kandungan vitamin C", t => {
            if(t>3.5f && lastAction<1){lastAction=1;PlayLab("step14");}
        });
        PlayerPrefs.SetInt("pernahjawab",0);
        yield return Load("8.2");
        var plate = FindFirstObjectByType<PingganSihatMalaysiaController>();
        var drag = FindObjectsByType<DragScript>(FindObjectsSortMode.None).FirstOrDefault(d=>d.name=="ikan");
        Vector3 origin = drag != null ? drag.transform.position : Vector3.zero;
        yield return Record(7, "Kenali tubuh. Amalkan pemakanan sihat.", t => {
            if(plate==null || drag==null) return;
            float p = Mathf.SmoothStep(0,1,Mathf.Clamp01((t-1)/2));
            drag.transform.position=Vector3.Lerp(origin,plate.section[0].position,p);
            if(t>3 && lastAction<1){
                lastAction=1;
                var ev=new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
                ev.pointerDrag=drag.gameObject;
                plate.section[0].GetComponent<ItemSlot>().OnDrop(ev);
            }
        });
        yield return Load("MainMenu");
        var chat=FindObjectsByType<OpenAI.ChatGPT>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault();
        InputField chatInput=null;
        Button chatSend=null;
        if(chat!=null){
            var flags=System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance;
            chatInput=(InputField)typeof(OpenAI.ChatGPT).GetField("inputField",flags).GetValue(chat);
            chatSend=(Button)typeof(OpenAI.ChatGPT).GetField("button",flags).GetValue(chat);
            if(chatInput!=null){for(Transform p=chatInput.transform;p!=null;p=p.parent)p.gameObject.SetActive(true);}
            chat.gameObject.SetActive(true);
            chat.SetOfflineDemoMode(true);
        }
        yield return Record(6, "DEMO LUAR TALIAN - jawapan contoh", t=>{
            if(chatInput==null)return;
            if(t<1){string q="Apakah fungsi amilase?";chatInput.text=q.Substring(0,Mathf.Min(q.Length,(int)(t*q.Length)));}
            if(t>=1 && lastAction<1 && chatSend!=null){lastAction=1;chatInput.text="Apakah fungsi amilase?";chatSend.onClick.Invoke();}
        });
        if(chat!=null)chat.SetOfflineDemoMode(false);
        yield return Load("2.4");
        yield return Record(6, "Uji kefahaman anda", t=>{
            var multi=FindObjectsByType<MultiAnswer>(FindObjectsSortMode.None).FirstOrDefault(m=>m.transform.parent.name=="1");
            if(multi==null || multi.answers==null || multi.answers.Length<5)return;
            if(t>1 && lastAction<1){lastAction=1;multi.answers[0].isOn=true;}
            if(t>2 && lastAction<2){lastAction=2;multi.answers[3].isOn=true;}
            if(t>3 && lastAction<3){lastAction=3;multi.answers[4].isOn=true;}
        });
        yield return Load("2.2");
        PrepareLab("beauty",0);
        yield return Record(5, "BioNutri-MM\nBelajar. Eksperimen. Fahami.",t=>{
            if(renderCamera!=null)renderCamera.transform.position+=Vector3.left*0.003f;
        });
        Status="COMPLETE: "+frame+" frames";
        File.WriteAllText("Temp/Trailer/complete.txt",Status);
        Cleanup();
        UnityEditor.EditorApplication.isPlaying=false;
    }

    private void OnScene(Scene scene,LoadSceneMode mode)
    {
        // Never use real student accounts or send scores while staging footage.
        string[] network={"LoadUserScore","LoadUserEks","loadUserAnswer","setUserData","StoreDataController","StoreEksController","WebController"};
        foreach(var b in FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include,FindObjectsSortMode.None))
            if(network.Contains(b.GetType().Name))b.enabled=false;
    }

    IEnumerator Load(string name)
    {
        if(name!="MainMenu")
            foreach(var chat in FindObjectsByType<OpenAI.ChatGPT>(FindObjectsInactive.Include,FindObjectsSortMode.None))
            {
                var field=typeof(OpenAI.ChatGPT).GetField("inputField",System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance);
                var input=field.GetValue(chat) as InputField;
                if(input!=null && input.GetComponentInParent<Canvas>()!=null)
                    input.GetComponentInParent<Canvas>().rootCanvas.gameObject.SetActive(false);
            }
        if(renderCamera!=null)renderCamera.targetTexture=null;
        if(captionRoot!=null)Destroy(captionRoot);
        if(target!=null)Destroy(target);
        if(pixels!=null)Destroy(pixels);
        SceneManager.LoadScene(name);
        yield return null;
        yield return new WaitForSeconds(1.5f);
        renderCamera=Camera.main;
        if(renderCamera==null)renderCamera=FindFirstObjectByType<Camera>();
        target=new RenderTexture(1920,1080,24);
        renderCamera.targetTexture=target;
        pixels=new Texture2D(1920,1080,TextureFormat.RGB24,false);
        foreach(var canvas in FindObjectsByType<Canvas>(FindObjectsInactive.Include,FindObjectsSortMode.None))
            if(canvas.isRootCanvas && canvas.renderMode!=RenderMode.WorldSpace){
                canvas.renderMode=RenderMode.ScreenSpaceCamera;canvas.worldCamera=renderCamera;canvas.planeDistance=1;
            }
        captionRoot=new GameObject("Trailer caption",typeof(Canvas),typeof(CanvasScaler));
        var cv=captionRoot.GetComponent<Canvas>();cv.renderMode=RenderMode.ScreenSpaceCamera;cv.worldCamera=renderCamera;cv.planeDistance=0.5f;cv.sortingOrder=32000;
        var scaler=captionRoot.GetComponent<CanvasScaler>();scaler.uiScaleMode=CanvasScaler.ScaleMode.ScaleWithScreenSize;scaler.referenceResolution=new Vector2(1920,1080);
        var strip=new GameObject("Caption background",typeof(RectTransform),typeof(Image));strip.transform.SetParent(captionRoot.transform,false);
        var rect=(RectTransform)strip.transform;rect.anchorMin=new Vector2(0,0);rect.anchorMax=new Vector2(1,0);rect.pivot=new Vector2(0.5f,0);rect.sizeDelta=new Vector2(0,124);
        strip.GetComponent<Image>().color=new Color(0.025f,0.025f,0.12f,0.9f);
        var text=new GameObject("Caption",typeof(RectTransform),typeof(TextMeshProUGUI));text.transform.SetParent(strip.transform,false);
        var tr=(RectTransform)text.transform;tr.anchorMin=Vector2.zero;tr.anchorMax=Vector2.one;tr.offsetMin=new Vector2(80,12);tr.offsetMax=new Vector2(-80,-12);
        caption=text.GetComponent<TMP_Text>();caption.font=Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");caption.fontSize=38;caption.alignment=TextAlignmentOptions.Center;caption.color=new Color(0.7f,0.95f,1);caption.raycastTarget=false;
        lastAction=-1;
        Canvas.ForceUpdateCanvases();
        yield return null;
    }

    void PrepareLab(string state,float normalized)
    {
        // Use the same authored animation states invoked by experiment controllers.
        foreach(var root in SceneManager.GetActiveScene().GetRootGameObjects())
            foreach(var t in root.GetComponentsInChildren<Transform>(true))
                if(t.name.StartsWith("prompt1"))t.gameObject.SetActive(false);
        foreach(var text in FindObjectsByType<TMP_Text>(FindObjectsSortMode.None))
            if((text.text ?? "").Contains("Simulasi Eksperimen") && text.transform.parent!=null && text.transform.parent.name=="Image")
            {
                var panel=text.transform.parent.gameObject;
                var group=panel.GetComponent<CanvasGroup>();
                if(group==null)group=panel.AddComponent<CanvasGroup>();
                group.alpha=0;group.blocksRaycasts=false;
                panel.SetActive(false);
            }
        var a=FindObjectsByType<Animator>(FindObjectsInactive.Include,FindObjectsSortMode.None).FirstOrDefault(x=>x.name=="GameObject (1)");
        if(a!=null){
            a.gameObject.SetActive(true);
            if(state=="beauty"){
                a.enabled=false;
                renderCamera.transform.position=new Vector3(-3,30,14);
                renderCamera.transform.eulerAngles=new Vector3(4.79f,0,0);
            } else {a.enabled=true;a.Play(state,0,normalized);a.Update(0);}
        }
        lastAction=-1;
    }
    void PlayLab(string state){var a=FindObjectsByType<Animator>(FindObjectsSortMode.None).FirstOrDefault(x=>x.name=="GameObject (1)");if(a!=null)a.Play(state);}

    IEnumerator Record(int seconds,string title,Action<float> action)
    {
        caption.text=title;
        lastAction=-1;
        for(int i=0;i<seconds*30;i++){
            action(i/30f);
            yield return null;
            // Explicit rendering also works when the Editor Game View is not focused.
            captionRoot.SetActive(false); // Captions are added in the final edit, outside gameplay bounds.
            renderCamera.Render();
            var previous=RenderTexture.active;
            RenderTexture.active=target;
            pixels.ReadPixels(new Rect(0,0,1920,1080),0,0);pixels.Apply();
            File.WriteAllBytes(Path.Combine(folder,frame.ToString("D5")+".jpg"),pixels.EncodeToJPG(92));
            RenderTexture.active=previous;
            frame++;
            Status="Recording "+frame+" / 1800: "+title;
        }
    }
    void Cleanup(){
        SceneManager.sceneLoaded-=OnScene;
        Time.captureFramerate=previousCaptureRate;
        if(renderCamera!=null)renderCamera.targetTexture=null;
        PlayerPrefs.SetInt("pernahjawab",oldCompleted);
        if(oldPlate!=null)for(int i=0;i<4;i++)PlayerPrefs.SetString("pinggan"+(i+1),oldPlate[i]);
    }
    void OnDestroy(){Cleanup();}
}
#endif
