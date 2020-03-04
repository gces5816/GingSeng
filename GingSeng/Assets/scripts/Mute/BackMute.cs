using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackMute : MonoBehaviour {
    public static bool backmute;
    public GameObject backaudio;
    public Text T;
    void Start()
    {
        if (backmute == true)
        {
            T.text = "開啟";
            backaudio.SetActive(false);
        }
        else
        {
            T.text = "關閉";
            backaudio.SetActive(true);
        }
    }
    public void MuteBackAudio() {
        if (backaudio.activeInHierarchy == true)
        {
            backmute = true;
            T.text = "開啟";
            backaudio.SetActive(false);
        }
        else {
            backmute = false;
            T.text = "關閉";
            backaudio.SetActive(true);
        }
    }
}
