using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputVolunteer : MonoBehaviour {
    string v = changescenes.volunteer;
    Text label;
	// Use this for initialization
	void Start () {
        label = GameObject.Find("Volunteer").GetComponent<Text>();
        if (v == "medical")
            label.text = "醫療";
        else if (v == "science")
            label.text = "理工";
        else if (v == "art")
            label.text = "藝文";
        else if (v == "business")
            label.text = "法商";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
