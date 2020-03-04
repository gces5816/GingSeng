using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FMNCardDisplay : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [HideInInspector]
    public FMNCard card;

    public Text leftText;
    public Text rightText;

    public Image cardImage;

    public void FMNCardSetup(FMNCard thiscard)
    {
        card = thiscard;

        leftText.text = card.left;
        rightText.text = card.right;

        cardImage.sprite = card.picture;
    }
}
