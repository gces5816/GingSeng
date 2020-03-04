using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{


    static public string img;
    static public int killme;
    // Use this for initialization
    void Start()
    {
        killme = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void kill()
    {
        img = "ends/ends";
        killme = 1;
    }
}
