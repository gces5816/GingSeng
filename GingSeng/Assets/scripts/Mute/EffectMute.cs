using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMute : MonoBehaviour {
    public static bool effectmute;
    public GameObject effectaudio;
    public Text T;
    // Use this for initialization
    void Start()
    {
        if (effectmute == true)
        {
            T.text = "開啟";
            effectaudio.SetActive(false);
        }
        else
        {
            T.text = "關閉";
            effectaudio.SetActive(true);
        }
    }
    public void MuteEffectAudio()
    {
        if (effectaudio.activeInHierarchy == true)
        {
            effectmute = true;
            T.text = "開啟";
            effectaudio.SetActive(false);
        }
        else
        {
            effectmute = false;
            T.text = "關閉";
            effectaudio.SetActive(true);
        }
    }
}
