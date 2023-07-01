using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{


    [SerializeField]
    private AudioMixer _MasterMixer;
    public float master;

    public float bgm;
    public float sfx;

    public Slider[] slider;
    public TextMeshProUGUI[] text;


    public bool isPrompt;




    private void Start()
    {
        
        getVolume();

    }
    public void saveVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", master);
        PlayerPrefs.SetFloat("bgm", bgm);
        PlayerPrefs.SetFloat("sfx", bgm);
        Debug.Log(PlayerPrefs.GetFloat("MasterVolume"));
    }

    public void getVolume()
    {
        master = PlayerPrefs.GetFloat("MasterVolume");
        bgm = PlayerPrefs.GetFloat("bgm");
        sfx = PlayerPrefs.GetFloat("sfx");

        if(master == 0 && bgm == 0 && sfx == 0){
            master = 0.50f;
            bgm = 0.50f;
            sfx = 0.50f;
        }

        _MasterMixer.SetFloat("Master", Mathf.Log10(master) * 20);

        _MasterMixer.SetFloat("bgm", Mathf.Log10(bgm) * 20);

        _MasterMixer.SetFloat("sfx", Mathf.Log10(sfx) * 20);

        if (isPrompt)
        {
            slider[0].value = master;

            slider[1].value = bgm;

            slider[2].value = sfx;
        }
    }
    public void SetMasterVolume(float volume)
    {

        _MasterMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        master = volume;
        text[0].text = (volume * 100).ToString("0");
    }

    public void SetBGMVolume(float volume)
    {

        _MasterMixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
        bgm = volume;
        text[1].text = (volume * 100).ToString("0");
    }

    public void SetSFXVolume(float volume)
    {

        _MasterMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        sfx = volume;
        text[2].text = (volume * 100).ToString("0");
    }

    internal UnityAction SetMasterVolume()
    {
        throw new NotImplementedException();
    }
}