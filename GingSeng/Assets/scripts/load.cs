using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  //StreamWrite會用到
public class load : MonoBehaviour
{

    static public endpassing.savefile loadData = new endpassing.savefile();
    // Use this for initialization
    void Start()
    {
        loadfile();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadfile()
    {
        //讀取json檔案並轉存成文字格式
        StreamReader file = new StreamReader(System.IO.Path.Combine(Application.streamingAssetsPath, "myPlayer"));
        string loadJson = file.ReadToEnd();
        file.Close();

        //使用JsonUtillty的FromJson方法將存文字轉成Json
        loadData = JsonUtility.FromJson<endpassing.savefile>(loadJson);

    }
}