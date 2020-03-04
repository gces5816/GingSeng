using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMuteOrNot : MonoBehaviour {
    GameObject e;
	// Use this for initialization
    void Start()
    {
        e = this.gameObject;
        if (EffectMute.effectmute == false)
        {
            e.SetActive(true);
        }
        else
        {
            e.SetActive(false);
        }
    }
}
