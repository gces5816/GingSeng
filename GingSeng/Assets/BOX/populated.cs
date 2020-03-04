using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class populated : MonoBehaviour
{

    public string[] endss = new string[100];
    public GameObject newObj;
    public GameObject prefab;
    public int numberofends;
    public Sprite img;
    public string path;
    public endpassing endpass;
    // Use this for initialization
    void Start()
    {
         //endss = endpassing.ends;
          //snumberofends = endpassing.tem;
        numberofends = load.loadData.numberinsave;
        endss = load.loadData.endsinsave;
        Populate(numberofends, endss);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Populate(int numberofends, string[] ends)
    {
        for (int i = 0; i < numberofends; i++)
        {
            img = (Sprite)Resources.Load<Sprite>(ends[i]);
            newObj = Instantiate(prefab, transform);
            newObj.GetComponent<Image>().sprite = img;
        }
    }
}