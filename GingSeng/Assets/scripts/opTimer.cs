using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class opTimer : MonoBehaviour {

    int time_int = 8;

    void Start()
    {
        InvokeRepeating("timer", 1, 1);
    }

    void timer()
    {
        time_int -= 1;

        if (time_int == 0)
        {
            CancelInvoke("timer");
            SceneManager.LoadScene(1);
        }
    }
}
