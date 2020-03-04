using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayChange : MonoBehaviour {
    public Text t;
	// Use this for initialization
	void Start () {
        t.text = "第 " + "1" + " 天";
	}
	
	// Update is called once per frame
	void Update () {
        t.text = "第 " + GameManager.Days.ToString() + " 天";
	}
}
