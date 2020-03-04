using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New FMNCard",menuName ="Cards/FMNCard")]
public class FMNCard : ScriptableObject
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string right;
    public string left;
    public Sprite picture;

    /*public int money;
    public int health;
    public int food;

    public string cardName;

    public int smart;
    public int ability;
    public int social;



    public bool isRight;
    public bool isLeft;
    public bool isCreate;*/
}
