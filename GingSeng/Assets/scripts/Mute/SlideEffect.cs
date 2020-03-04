using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SlideEffect : MonoBehaviour {
    AudioSource slide;
    void Start()
    {
        slide = this.GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {
        if (CardMove.isleft == 1 || CardMove.isright == 1)
        {
            slide.Play();
        }
	}
}
