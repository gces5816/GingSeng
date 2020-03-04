using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class CardEffect : MonoBehaviour
{
    private int t;
    public AudioSource g1, g2, m1, m2, m3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CardKind != 0)
        {
            cardeffect();
            GameManager.CardKind = 0;
        }
    }

    public void cardeffect()
    {
        if (GameManager.CardKind == 1)
        {
            System.Random rd = new System.Random(Guid.NewGuid().GetHashCode());
            t = rd.Next(5);
            if (t == 0) m1.Play();
            else if (t == 1) m2.Play();
            else if (t == 2) m3.Play();
        }
        else if (GameManager.CardKind == 4)
        {
            System.Random rd = new System.Random(Guid.NewGuid().GetHashCode());
            t = rd.Next(1);
            if (t == 0) g1.Play();
            else if (t == 1) g2.Play();
        }
    }
}