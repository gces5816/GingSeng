using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;  //StreamWrite會用到

public class endpassing : MonoBehaviour
{
    Dictionary<string, bool> selected = new Dictionary<string, bool>(){
        { "artends/ae1",false },{"artends/ae2",false },{"artends/ae3",false },{"artends/ae4",false },{"artends/ae5",false },{"artends/ae6",false },{"artends/ae7",false },{"artends/ae8",false },{"artends/ae9",false },{"artends/ae10",false },{"artends/ae11",false },{"artends/ae12",false },{"artends/ae13",false },{"artends/ae14",false },
        { "businessends/be1",false },{"businessends/be2",false },{"businessends/be3",false },{"businessends/be4",false },{"businessends/be5",false },{"businessends/be6",false },{"businessends/be7",false },{"businessends/be8",false },{"businessends/be9",false },{"businessends/be10",false },{"businessends/be11",false },{"businessends/be12",false },{"businessends/be13",false },{"businessends/be14",false },{"businessends/be15",false },
        { "ghostleft/gl1",false },{"ghostleft/gl2",false },{"ghostleft/gl3",false },{"ghostleft/gl4",false },{"ghostleft/gl5",false },{"ghostleft/gl6",false },{"ghostleft/gl7",false },{"ghostleft/gl8",false },{"ghostleft/gl9",false },{"ghostleft/gl10",false },{"ghostright/gr1",false },{"ghostright/gr2",false },{"ghostright/gr3",false },{"ghostright/gr4",false },{"ghostright/gr5",false },{"ghostright/gr6",false },{"ghostright/gr7",false },{"ghostright/gr8",false },{"ghostright/gr9",false },{"ghostright/gr10",false },
        { "medicalends/me1",false },{"medicalends/me2",false },{"medicalends/me3",false },{"medicalends/me4",false },{"medicalends/me5",false },{"medicalends/me6",false },{"medicalends/me7",false },{"medicalends/me8",false },{"medicalends/me9",false },{"medicalends/me10",false },{"medicalends/me11",false },{"medicalends/me12",false },{"medicalends/me13",false },
        { "miserable/mi1",false },{"miserable/mi2",false },{"miserable/mi3",false },{"miserable/mi4",false },{"miserable/mi5",false },{"miserable/mi6",false },{"miserable/mi7",false },{"miserable/mi8",false },{"miserable/mi9",false },{"miserable/mi10",false },{"miserable/mi11",false },{"miserable/mi12",false },
        { "scienceend/se1",false },{"scienceend/se2",false },{"scienceend/se3",false },{"scienceend/se4",false },{"scienceend/se5",false },{"scienceend/se6",false },{"scienceend/se7",false },{"scienceend/se8",false },{"scienceend/se9",false },{"scienceend/se10",false },{"scienceend/se11",false },{"scienceend/se12",false },{"scienceend/se13",false },
        {"ends/ends",false },{"ends/m1",false }
    };
    static public string[] ends = new string[100];
    static public int count=0;
    static public int tem;
    public Image endImage;
    public Text day;

    // Use this for initialization
    void Start()
    {

        initiate();
        if (Kill.killme == 1)
        {
            if (selected[Kill.img] != true)
            {
                selected[Kill.img] = true;
                //Debug.Log(selected[BarChange.img]);
                ends[count] = Kill.img;
                count++;
                tem = count;
            }
        }
        else
        {
            if (selected[BarChange.img] != true)
            {
                selected[BarChange.img] = true;
                ends[count] = BarChange.img;
                count++;
                tem = count;
            }
        }
        save(count, ends);
        if (Kill.killme == 1)
        {
            endImage.sprite = Resources.Load<Sprite>(Kill.img);
            Kill.killme = 0;
        }
        else
        {
            endImage.sprite = Resources.Load<Sprite>(BarChange.img);
        }
        if (GameManager.Days < 3)
        {
            day.text = "你只活了" + GameManager.Days + "天  SUCK!!";
        }
        else if (GameManager.Days < 7)
        {
            day.text = "你生存了" + GameManager.Days + "天  再加油喔!!";
        }
        else
        {
            day.text = "生存" + GameManager.Days + "天  太久了吧!!";
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    void initiate()
    {

       count = load.loadData.numberinsave;
       ends = load.loadData.endsinsave;

        for (int i = 0; i < count; i++)
        {
            selected[ends[i]] = true;
        }


    }
   public class savefile
    {
        public int numberinsave;
        public string[] endsinsave;
    }
    public void save(int numberofends, string[] endss)
    {
        //填寫jplayerState格式的資料..
        savefile myPlayer = new savefile();
        myPlayer.endsinsave = endss;
        myPlayer.numberinsave = numberofends;
        //將myPlayer轉換成json格式的字串
        string saveString = JsonUtility.ToJson(myPlayer);

        //將字串saveString存到硬碟中
        StreamWriter file = new StreamWriter(System.IO.Path.Combine(Application.streamingAssetsPath, "myPlayer"));
        file.Write(saveString);
        file.Close();
    }
}