using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescenes : MonoBehaviour {

    public int GoToScene;
    public static int FromScene;
    public static string volunteer;

    public void ChangeScenes(){
        FromScene = SceneManager.GetActiveScene().buildIndex;
        if (FromScene == 3)
        {
            volunteer = this.name;
        }
        SceneManager.LoadScene(GoToScene);
    }
}
