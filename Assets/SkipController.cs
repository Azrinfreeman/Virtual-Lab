using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkipController : MonoBehaviour
{
    public Animator animator;
    public AnimatorClipInfo[] clipInfo;

    public string currentAnimation;

    public string GetCurrentClipName()
    {
        int layerIndex = 0;
        clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        return clipInfo[0].clip.name;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void PlayAnimation(string animationName){
        animator.Play(animationName);
    }

    public void SkipAnimation(string animationName){
        GetComponent<Button>().onClick.AddListener(()=>PlayAnimation(animationName));
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = GetCurrentClipName();
        Debug.Log(GetCurrentClipName());
    }
}
