using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteAlways]
public class BioUITestEventSystem : EventSystem { }

public class AnimationUIBehaviourTests
{
    static Type GameType(string name) => AppDomain.CurrentDomain.GetAssemblies()
        .Select(a=>a.GetType(name)).First(t=>t != null);
    static Component Add(GameObject go, string name) => go.AddComponent(GameType(name));
    static void Set(object target, string name, object value) => target.GetType().GetField(name).SetValue(target,value);
    static object Get(object target, string name) => target.GetType().GetProperty(name).GetValue(target);
    static object Call(object target, string name, params object[] args) => target.GetType().GetMethod(name).Invoke(target,args);

    [TestCase(2,14,50)]
    [TestCase(3,15,75)]
    [TestCase(4,27,100)]
    [TestCase(5,31,100)]
    [TestCase(6,26,100)]
    [TestCase(7,28,100)]
    public void RealMilestonesSetConsistentProgressAndReset(int activity, int step, int expected)
    {
        var go = new GameObject("Progress fixture",typeof(RectTransform),typeof(Slider));
        var textObject = new GameObject("Value",typeof(RectTransform),typeof(TextMeshProUGUI));
        textObject.transform.SetParent(go.transform,false);
        try
        {
            var p = Add(go,"ProgressController");
            var slider = go.GetComponent<Slider>(); slider.maxValue = 100;
            var label = textObject.GetComponent<TextMeshProUGUI>();
            Set(p,"slider",slider); Set(p,"text",label); Set(p,"no",activity);
            Call(p,"OnStepCompleted",step);
            Assert.That(slider.value,Is.EqualTo(expected));
            Assert.That(label.text,Is.EqualTo(expected+"%"));
            Call(p,"OnStepCompleted",0);
            Assert.That(slider.value,Is.Zero);
            Assert.That(label.text,Is.EqualTo("0%"));
        }
        finally { UnityEngine.Object.DestroyImmediate(go); }
    }

    [Test]
    public void NestedModalRetainsInputLockUntilLastCloseAndRestoresFocus()
    {
        var root = new GameObject("Screen",typeof(RectTransform),typeof(Canvas),typeof(CanvasGroup));
        var events = new GameObject("Events",typeof(BioUITestEventSystem));
        EventSystem.current = events.GetComponent<EventSystem>();
        try
        {
            var screenGroup = root.GetComponent<CanvasGroup>();
            var origin = new GameObject("Origin",typeof(RectTransform),typeof(Button));
            origin.transform.SetParent(root.transform,false);
            EventSystem.current.SetSelectedGameObject(origin);
            var firstGo = new GameObject("First",typeof(RectTransform)); firstGo.transform.SetParent(root.transform,false);
            var secondGo = new GameObject("Second",typeof(RectTransform)); secondGo.transform.SetParent(root.transform,false);
            var first = Add(firstGo,"BioModal"); var second = Add(secondGo,"BioModal");
            Set(first,"screenGroup",screenGroup); Set(second,"screenGroup",screenGroup);
            Call(first,"BeginOpen"); Call(second,"BeginOpen");
            Assert.That(screenGroup.interactable,Is.False);
            Assert.That((bool)GameType("BioModal").GetMethod("Allows").Invoke(null,new object[]{origin.transform}),Is.False);
            Call(second,"CompleteClose");
            Assert.That(screenGroup.interactable,Is.False);
            Call(first,"CompleteClose");
            Assert.That(screenGroup.interactable,Is.True);
            Assert.That(screenGroup.blocksRaycasts,Is.True);
            Assert.That(EventSystem.current.currentSelectedGameObject,Is.SameAs(origin));
        }
        finally { UnityEngine.Object.DestroyImmediate(root); UnityEngine.Object.DestroyImmediate(events); }
    }

    [Test]
    public void OccupiedSlotRejectsWithoutMovingOrReplacingAndMovingClearsOldSlot()
    {
        var scene = EditorSceneManager.NewPreviewScene();
        scene.name = "8.2";
        var root = new GameObject("Drop fixture",typeof(RectTransform),typeof(Canvas));
        SceneManager.MoveGameObjectToScene(root,scene);
        var events = new GameObject("Events",typeof(BioUITestEventSystem));
        EventSystem.current = events.GetComponent<EventSystem>();
        SceneManager.MoveGameObjectToScene(events,scene);
        try
        {
            var slotAObject = new GameObject("Slot A",typeof(RectTransform)); slotAObject.transform.SetParent(root.transform,false);
            var slotBObject = new GameObject("Slot B",typeof(RectTransform)); slotBObject.transform.SetParent(root.transform,false);
            var slotA = Add(slotAObject,"ItemSlot"); var slotB = Add(slotBObject,"ItemSlot");
            var plateA=Add(slotAObject,"PingganName"); Add(slotBObject,"PingganName");
            var firstObject = new GameObject("IKAN",typeof(RectTransform),typeof(CanvasGroup)); firstObject.transform.SetParent(root.transform,false);
            var secondObject = new GameObject("NASI",typeof(RectTransform),typeof(CanvasGroup)); secondObject.transform.SetParent(root.transform,false);
            var first=Add(firstObject,"DragScript"); var second=Add(secondObject,"DragScript");
            Assert.That(Call(slotA,"TryPlace",first),Is.True);
            Assert.That(Call(slotA,"TryPlace",second),Is.False);
            Assert.That(Get(slotA,"Occupant"),Is.SameAs(first));
            Assert.That(plateA.GetType().GetField("plateName").GetValue(plateA),Is.EqualTo("IKAN"));
            Assert.That(Call(slotB,"TryPlace",first),Is.True);
            Assert.That(Get(slotA,"Occupant"),Is.Null);
            Assert.That(plateA.GetType().GetField("plateName").GetValue(plateA),Is.EqualTo(""));
            Assert.That(Get(slotB,"Occupant"),Is.SameAs(first));
            Assert.That(Call(slotA,"TryPlace",second),Is.True);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root); UnityEngine.Object.DestroyImmediate(events);
            EditorSceneManager.ClosePreviewScene(scene);
        }
    }

    [Test]
    public void SafeAreaClampsPhysicalDisplayToGameViewportAndRetainsInsets()
    {
        var method=GameType("BioSafeArea").GetMethod("Normalize");
        var full=(Rect)method.Invoke(null,new object[]{new Rect(0,0,2732,2086),new Vector2Int(1095,843)});
        Assert.That(full,Is.EqualTo(new Rect(0,0,1,1)));
        var inset=(Rect)method.Invoke(null,new object[]{new Rect(50,0,900,500),new Vector2Int(1000,500)});
        Assert.That(inset.xMin,Is.EqualTo(.05f).Within(.0001f));
        Assert.That(inset.xMax,Is.EqualTo(.95f).Within(.0001f));
    }

    [Test]
    public void ModalCannotLockItsOwnCanvasGroup()
    {
        var go = new GameObject("Self-group fixture",typeof(RectTransform));
        var modal=Add(go,"BioModal");
        try
        {
            var group=go.GetComponent<CanvasGroup>();
            Set(modal,"screenGroup",group);
            Call(modal,"BeginOpen");
            Assert.That(group.interactable,Is.True);
            Assert.That(group.blocksRaycasts,Is.True);
            Call(modal,"CompleteClose");
        }
        finally { UnityEngine.Object.DestroyImmediate(go); }
    }

    [TestCase("Assets/Scenes/MainMenuAktiviti.unity")]
    [TestCase("Assets/Scenes/Aktiviti2/2.2.unity")]
    [TestCase("Assets/Scenes/Aktiviti1/1.1.unity")]
    public void InstalledInactiveDialogsLockTheOuterScreenAndKeepReadableButtons(string path)
    {
        var scene=EditorSceneManager.OpenPreviewScene(path);
        try
        {
            var modals=scene.GetRootGameObjects().SelectMany(r=>r.GetComponentsInChildren(GameType("BioModal"),true));
            int count=0;
            foreach (var modal in modals)
            {
                count++;
                var group=(CanvasGroup)modal.GetType().GetField("screenGroup").GetValue(modal);
                Assert.That(group,Is.Not.Null);
                Assert.That(group.transform.IsChildOf(modal.transform),Is.False);
                foreach(var button in modal.GetComponentsInChildren<Button>(true))
                    foreach(var label in button.GetComponentsInChildren<TMP_Text>(true))
                        Assert.That(label.color.r,Is.GreaterThan(.8f),path+" / "+button.name);
            }
            Assert.That(count,Is.GreaterThan(0));
        }
        finally { EditorSceneManager.ClosePreviewScene(scene); }
    }

    [Test]
    public void InvalidDropRestoresCoordinatesAndRaycastsEvenWhenReleasedOverSlot()
    {
        var go=new GameObject("Answer",typeof(RectTransform),typeof(CanvasGroup));
        var events=new GameObject("Events",typeof(BioUITestEventSystem));
        EventSystem.current = events.GetComponent<EventSystem>();
        try
        {
            var drag=Add(go,"DragScript");
            drag.GetType().GetMethod("Awake",BindingFlags.NonPublic|BindingFlags.Instance).Invoke(drag,null);
            var rect=go.GetComponent<RectTransform>(); rect.anchoredPosition=new Vector2(25,40);
            var data=new PointerEventData(EventSystem.current){pointerDrag=go};
            Call(drag,"OnBeginDrag",data);
            rect.anchoredPosition=new Vector2(900,900);
            Call(drag,"OnEndDrag",data);
            Assert.That(rect.anchoredPosition,Is.EqualTo(new Vector2(25,40)));
            Assert.That(go.GetComponent<CanvasGroup>().blocksRaycasts,Is.True);
            Assert.That(go.GetComponent<CanvasGroup>().alpha,Is.EqualTo(1));
        }
        finally { UnityEngine.Object.DestroyImmediate(go); UnityEngine.Object.DestroyImmediate(events); }
    }
}
