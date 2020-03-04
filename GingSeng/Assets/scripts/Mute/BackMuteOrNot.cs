using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMuteOrNot : MonoBehaviour {
    GameObject bgm;
	// Use this for initialization
	void Start () {
        bgm = this.gameObject;
        if (BackMute.backmute == false)
        {
            bgm.SetActive(true);
        }
        else
        {
            bgm.SetActive(false);
        }
	}
}
