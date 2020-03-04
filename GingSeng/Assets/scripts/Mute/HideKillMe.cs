using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideKillMe : MonoBehaviour {
    GameObject killme;
    int GotoScene;
	// Use this for initialization
	void Start () {
        killme = GameObject.Find("KillMe");
        if (changescenes.FromScene == 1)
        {
            killme.SetActive(false);
            GotoScene = 1;
        }
        else
        {
            killme.SetActive(true);
            GotoScene = 4;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void returnonclick()
    {
        SceneManager.LoadScene(GotoScene);
    }
}
