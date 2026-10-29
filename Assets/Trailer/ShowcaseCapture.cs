#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Temporary Play Mode rig. Never attached to an asset or included in a player build.
public sealed class ShowcaseCapture : MonoBehaviour
{
    public static string Status = "Idle";
    string take, mode, folder;
    int frames, previousRate, frame;
    bool previousBackground, cleaned;
    readonly List<string> markers = new List<string>();
    readonly Dictionary<string, string> oldStrings = new Dictionary<string, string>();
    int oldCompleted;
    bool hadCompleted;
    RectTransform pointer;
    Camera camera;
    Vector3 cameraStart;
    Animator lab;
    DragScript food;
    ItemSlot slot;
    Vector2 foodFrom, foodTo;
    MultiAnswer question;
    Stopwatch watch;
    RenderTexture target, oldTarget;
    Texture2D pixels;
    readonly List<CanvasState> canvases = new List<CanvasState>();
    readonly Dictionary<Image,bool> backdrops = new Dictionary<Image,bool>();
    int width=1920,height=1080;
    Texture2D pointerTexture;
    Sprite pointerSprite;

    public static void Begin(string scene, string id, float seconds, string profile, int captureWidth=1920)
    {
        if (!Application.isPlaying) throw new InvalidOperationException("Enter Play Mode first");
        if (FindFirstObjectByType<ShowcaseCapture>() != null) throw new InvalidOperationException("Capture already running");
        var rig = new GameObject("Showcase capture (temporary)").AddComponent<ShowcaseCapture>();
        rig.take = id; rig.mode = profile; rig.frames = Mathf.RoundToInt(seconds * 60);
        rig.width=captureWidth;rig.height=captureWidth*9/16;
        rig.StartCoroutine(rig.Run(scene));
    }

    void OnScene(Scene scene, LoadSceneMode loadMode)
    {
        // Runs before scene Start methods: recording has no account or score traffic.
        string[] network = {"LoadUserScore", "LoadUserEks", "loadUserAnswer", "setUserData", "StoreDataController", "StoreEksController", "WebController"};
        foreach (var b in FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            if (network.Contains(b.GetType().Name)) b.enabled = false;
    }

    IEnumerator Run(string scene)
    {
        DontDestroyOnLoad(gameObject);
        previousRate = Time.captureFramerate; previousBackground = Application.runInBackground;
        Time.captureFramerate = 60; Application.runInBackground = true;
        hadCompleted = PlayerPrefs.HasKey("pernahjawab"); oldCompleted = PlayerPrefs.GetInt("pernahjawab");
        foreach (var key in new[]{"pinggan1", "pinggan2", "pinggan3", "pinggan4"})
            oldStrings[key] = PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : null;
        if (mode == "plate") PlayerPrefs.SetInt("pernahjawab", 0);
        SceneManager.sceneLoaded += OnScene;
        folder = "Temp/TrailerShowcase/" + take;
        Directory.CreateDirectory(folder);
        SceneManager.LoadScene(scene);
        yield return null;
        yield return new WaitForSeconds(1);
        camera = Camera.main;
        lab = FindObjectsByType<Animator>(FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(a => a.name == "GameObject (1)");
        if (mode != "smoke" && mode != "menu" && mode != "plate" && mode != "quiz" && mode != "anatomy")
        {
            foreach (var modal in FindObjectsByType<BioModal>(FindObjectsSortMode.None)) modal.gameObject.SetActive(false);
            foreach (var t in FindObjectsByType<Transform>(FindObjectsInactive.Include, FindObjectsSortMode.None))
                if (t.name.StartsWith("prompt1")) t.gameObject.SetActive(false);
            if (lab != null) { lab.gameObject.SetActive(true); lab.enabled = true; }
            if (mode == "overview")
            {
                if (lab != null) lab.enabled = false;
                camera.transform.position = new Vector3(-3, 30, 12.8f);
                camera.transform.eulerAngles = new Vector3(4.79f, 0, 0);
            }
            if (mode == "transfer") { lab.Play("step1", 0, 0); lab.Update(0); Mark("authored-animation insert: step1; no manual 3D input claim"); }
            if (mode == "observation") { lab.Play("step18-20", 0, 0); lab.Update(0); Mark("authored-animation insert: step18-20; prior steps omitted"); }
            if (mode == "vitamin") { lab.Play("step10", 0, 0); lab.Update(0); Mark("authored-animation insert: step10; prior steps omitted"); }
        }
        cameraStart = camera != null ? camera.transform.position : Vector3.zero;
        if (mode == "plate")
        {
            food = FindObjectsByType<DragScript>(FindObjectsSortMode.None).First(d => d.name == "ikan");
            slot = FindFirstObjectByType<PingganSihatMalaysiaController>().section[0].GetComponent<ItemSlot>();
            foodFrom = RectTransformUtility.WorldToScreenPoint(null, food.transform.position);
            foodTo = RectTransformUtility.WorldToScreenPoint(null, slot.transform.position);
        }
        if (mode == "quiz") question = FindObjectsByType<MultiAnswer>(FindObjectsSortMode.None).First(q => q.transform.parent.name == "1");
        CreatePointer();
        // WaitForEndOfFrame stalls when the editor's Game View is not visible.
        // Route all overlay roots through the capture camera, including modal/pointer layers.
        target = new RenderTexture(width,height,24); pixels = new Texture2D(width,height,TextureFormat.RGB24,false);
        oldTarget = camera.targetTexture; camera.targetTexture = target;
        RouteCanvases();
        yield return null;
        watch = Stopwatch.StartNew();
        for (frame = 0; frame < frames; frame++)
        {
            Actions(frame);
            yield return null;
            if(mode=="transfer" || mode=="observation" || mode=="vitamin" || mode=="overview")
                foreach(var m in FindObjectsByType<BioModal>(FindObjectsSortMode.None))
                {
                    foreach(var im in m.GetComponentsInChildren<Image>(true).Where(i=>i.name=="Panel"))
                    { if(!backdrops.ContainsKey(im))backdrops[im]=im.enabled;im.enabled=false; }
                    if(!m.GetComponentsInChildren<TMP_Text>().Any(t=>t.GetComponentInParent<Button>()==null && !string.IsNullOrWhiteSpace(t.text)))
                    { Mark("omitted empty staging prompt: "+m.name);m.gameObject.SetActive(false); }
                }
            if(Camera.main != camera) { camera=Camera.main; camera.targetTexture=target; RouteCanvases(); }
            camera.Render();
            var previous=RenderTexture.active; RenderTexture.active=target;
            pixels.ReadPixels(new Rect(0,0,width,height),0,0);pixels.Apply();RenderTexture.active=previous;
            File.WriteAllBytes(Path.Combine(folder, frame.ToString("D5") + ".jpg"), pixels.EncodeToJPG(94));
            Status = take + ": " + (frame + 1) + "/" + frames;
        }
        watch.Stop();
        File.WriteAllText(Path.Combine(folder, "take.json"), JsonUtility.ToJson(new TakeInfo {
            id=take, scene=scene, profile=mode, fps=60, width=width, height=height, frames=frames,
            wallSeconds=watch.Elapsed.TotalSeconds, markers=markers.ToArray(),
            disclosure=(mode=="transfer" || mode=="observation" || mode=="vitamin") ? "Authored simulation animation; setup seeks to named state, backdrop hidden for editorial visibility; no manual 3D input or elapsed-time claim" : "Current game; automated UI events logged at native simulation speed"
        }, true));
        Status = "COMPLETE " + take;
        Cleanup();
        Destroy(gameObject);
    }

    void Actions(int f)
    {
        if (mode == "overview" && camera != null)
            camera.transform.position = cameraStart + new Vector3(.75f,0,2.3f) * Mathf.SmoothStep(0,1,f/(float)(frames-1));
        if (mode == "smoke")
        {
            if (f == 60 || f == 240) Click(FindObjectsByType<Button>(FindObjectsSortMode.None).FirstOrDefault(b => b.name == "btnYa"));
        }
        if (mode == "menu")
        {
            var b = FindObjectsByType<Button>(FindObjectsSortMode.None).FirstOrDefault(x => x.name == "btn2");
            if (b != null) { MovePointer(RectTransformUtility.WorldToScreenPoint(null,b.transform.position)); if (f==90) { EventSystem.current.SetSelectedGameObject(b.gameObject); ExecuteEvents.Execute(b.gameObject,new PointerEventData(EventSystem.current),ExecuteEvents.pointerEnterHandler); Mark("activity 2 focused via EventSystem"); } }
            if (f == 270) Click(b);
        }
        if (mode == "transfer" && f == 300)
        {
            lab.Play("step2",0,0);Mark("authored-animation insert: step2; editorial cut between procedure stages");
        }
        if (mode == "anatomy" && f == 150)
        {
            var b = FindObjectsByType<Button>(FindObjectsSortMode.None).FirstOrDefault(x=>x.name=="Button2" || x.name=="btn2");
            if (b != null) Click(b);
        }
        if (mode == "plate")
        {
            var p = Vector2.Lerp(foodFrom,foodTo,Mathf.SmoothStep(0,1,Mathf.Clamp01((f-100)/120f)));
            MovePointer(p);
            var ev = new PointerEventData(EventSystem.current) {position=p,pointerDrag=food.gameObject};
            ev.pointerPressRaycast=new RaycastResult{module=food.GetComponentInParent<GraphicRaycaster>()};
            if (f==100) { food.OnBeginDrag(ev); Mark("ikan BeginDrag"); }
            if (f>100 && f<=220) { ev.delta=p-Vector2.Lerp(foodFrom,foodTo,Mathf.SmoothStep(0,1,Mathf.Clamp01((f-101)/120f))); food.OnDrag(ev); }
            if (f==221) { slot.OnDrop(ev); food.OnEndDrag(ev); Mark("ikan Drop via ItemSlot; accepted="+(slot.Occupant==food)); }
        }
        if (mode == "quiz")
        {
            if (f==90) Toggle(question.answers[0]);
            if (f==150) Toggle(question.answers[3]);
            if (f==210) Toggle(question.answers[4]);
            if (f==270) { question.checkAnswers(); KuizController.instance.checkAnswers(); Mark("checked actual first-question answer; correct="+question.isTrue+"; total="+KuizController.instance.scores); }
        }
    }
    void Toggle(Toggle toggle)
    {
        MovePointer(RectTransformUtility.WorldToScreenPoint(null,toggle.transform.position));
        ExecuteEvents.Execute(toggle.gameObject,new PointerEventData(EventSystem.current){button=PointerEventData.InputButton.Left},ExecuteEvents.pointerClickHandler);
        Mark("toggle "+toggle.name+"="+toggle.isOn);
    }
    void Click(Button b)
    {
        if (b==null || !b.IsInteractable()) { Mark("click unavailable"); return; }
        MovePointer(RectTransformUtility.WorldToScreenPoint(null,b.transform.position));
        ExecuteEvents.Execute(b.gameObject,new PointerEventData(EventSystem.current){button=PointerEventData.InputButton.Left},ExecuteEvents.pointerClickHandler);
        Mark("button "+b.name+" via pointerClick");
    }
    void Mark(string message) { markers.Add(frame+": "+message); }
    void CreatePointer()
    {
        var root=new GameObject("Recorded event pointer",typeof(Canvas),typeof(CanvasScaler));
        root.transform.SetParent(transform,false);
        var canvas=root.GetComponent<Canvas>(); canvas.renderMode=RenderMode.ScreenSpaceOverlay; canvas.sortingOrder=32000;
        var go=new GameObject("Pointer",typeof(RectTransform),typeof(Image));go.transform.SetParent(root.transform,false);
        pointer=(RectTransform)go.transform;pointer.sizeDelta=new Vector2(30,42);pointer.pivot=new Vector2(0,1);
        pointerTexture=new Texture2D(30,42,TextureFormat.RGBA32,false);
        Vector2[] polygon={new Vector2(1,1),new Vector2(1,34),new Vector2(9,26),new Vector2(16,40),new Vector2(22,37),new Vector2(15,23),new Vector2(28,23)};
        Func<float,float,bool> inside=(x,y)=>{bool hit=false;for(int i=0,j=polygon.Length-1;i<polygon.Length;j=i++)if((polygon[i].y>y)!=(polygon[j].y>y)&&x<(polygon[j].x-polygon[i].x)*(y-polygon[i].y)/(polygon[j].y-polygon[i].y)+polygon[i].x)hit=!hit;return hit;};
        for(int y=0;y<42;y++)for(int x=0;x<30;x++){bool hit=inside(x,y);bool edge=hit&&(!inside(x-1,y)||!inside(x+1,y)||!inside(x,y-1)||!inside(x,y+1));pointerTexture.SetPixel(x,41-y,!hit?Color.clear:edge?BioPalette.SurfaceBase:Color.white);}
        pointerTexture.Apply();pointerSprite=Sprite.Create(pointerTexture,new Rect(0,0,30,42),new Vector2(0,1));
        var im=go.GetComponent<Image>();im.sprite=pointerSprite;im.color=Color.white;im.raycastTarget=false;
        MovePointer(new Vector2(-100,-100));
    }
    void MovePointer(Vector2 p)
    {
        if(pointer==null)return;
        var canvas=pointer.GetComponentInParent<Canvas>();
        pointer.position=canvas.renderMode==RenderMode.ScreenSpaceOverlay?(Vector3)p:canvas.worldCamera.ScreenToWorldPoint(new Vector3(p.x,p.y,canvas.planeDistance));
    }
    void RouteCanvases()
    {
        foreach(var c in FindObjectsByType<Canvas>(FindObjectsInactive.Include,FindObjectsSortMode.None))
        {
            if(!c.isRootCanvas || c.renderMode==RenderMode.WorldSpace)continue;
            canvases.Add(new CanvasState{canvas=c,mode=c.renderMode,camera=c.worldCamera,distance=c.planeDistance});
            c.renderMode=RenderMode.ScreenSpaceCamera;c.worldCamera=camera;c.planeDistance=.5f;
        }
        Canvas.ForceUpdateCanvases();
    }
    void Cleanup()
    {
        if(cleaned)return; cleaned=true;
        SceneManager.sceneLoaded-=OnScene;
        if(camera!=null)camera.targetTexture=oldTarget;
        foreach(var c in canvases)if(c.canvas!=null){c.canvas.renderMode=c.mode;c.canvas.worldCamera=c.camera;c.canvas.planeDistance=c.distance;}
        foreach(var pair in backdrops)if(pair.Key!=null)pair.Key.enabled=pair.Value;
        if(target!=null)Destroy(target);if(pixels!=null)Destroy(pixels);
        if(pointerSprite!=null)Destroy(pointerSprite);if(pointerTexture!=null)Destroy(pointerTexture);
        Time.captureFramerate=previousRate;Application.runInBackground=previousBackground;
        if(hadCompleted)PlayerPrefs.SetInt("pernahjawab",oldCompleted);else PlayerPrefs.DeleteKey("pernahjawab");
        foreach(var pair in oldStrings)if(pair.Value==null)PlayerPrefs.DeleteKey(pair.Key);else PlayerPrefs.SetString(pair.Key,pair.Value);
    }
    void OnDestroy(){Cleanup();}
    [Serializable] sealed class TakeInfo { public string id,scene,profile,disclosure;public int fps,width,height,frames;public double wallSeconds;public string[] markers; }
    sealed class CanvasState { public Canvas canvas;public RenderMode mode;public Camera camera;public float distance; }
}
#endif
