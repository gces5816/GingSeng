using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BarChange : MonoBehaviour
{
    public const int rowmax = 300, columnmax = 100;
    static public string img;
    static public int Foodcurrent, Healthycurrent, Smartcurrent, Abilitycurrent, Socialcurrent, Moneycurrent;
    static public bool Fzero, Hzero, SMzero, Azero, SOzero, Mzero;
    static public bool SMmaximun, Amaximun, SOmaximun,MOmax;
    int Fplus = 0, Hplus = 0, SMplus = 0, Aplus = 0, SOplus = 0, Mplus = 0;
    public RectTransform FRest, HRest, SMRest, ARest, SORest, MRest;
    static public int puma;

	// Use this for initialization
	void Start () {
        puma = 0;
        Fzero = false;
        Hzero = false;
        SMzero = false;
        Azero = false;
        SOzero = false;
        Mzero = false;
        SMmaximun = false;
        Amaximun = false;
        SOmaximun = false;
        MOmax = false;
        if (changescenes.FromScene == 3)
        {
            System.Random rd = new System.Random(Guid.NewGuid().GetHashCode());
            Smartcurrent = rd.Next(20, 50);
            Abilitycurrent = rd.Next(20, 50);
            Socialcurrent = rd.Next(20, 50);
            Moneycurrent = rd.Next(20, 50);
            Healthycurrent = rd.Next(60, 150);
            Foodcurrent = rd.Next(60, 150);
        }
        SMRest.sizeDelta = new Vector2(SMRest.sizeDelta.x, Smartcurrent);
        ARest.sizeDelta = new Vector2(ARest.sizeDelta.x, Abilitycurrent);
        SORest.sizeDelta = new Vector2(SORest.sizeDelta.x, Socialcurrent);
        MRest.sizeDelta = new Vector2(MRest.sizeDelta.x, Moneycurrent);
        HRest.sizeDelta = new Vector2(Healthycurrent, HRest.sizeDelta.y);
        FRest.sizeDelta = new Vector2(Foodcurrent, FRest.sizeDelta.y);
        SMplus = 0;
        Aplus = 0;
        SOplus = 0;
        Mplus = 0;
        Hplus = 0;
        Fplus = 0;
	}

	// Update is called once per frame
	void Update () {
		if (CardMove.isleft == 1 || CardMove.isright == 1)
        {
            //Healthy
            Hplus = GameManager.health * 3;
            if (Hplus < 0)
            {
                //接受傷害
                Healthycurrent = Healthycurrent + Hplus;
                //同步到當前血量長度
                HRest.sizeDelta = new Vector2(Healthycurrent, HRest.sizeDelta.y);
                if (Healthycurrent <= 0)
                {
                    Healthycurrent = 0;
                    Hzero = true;
                }
            }
            else if (Hplus >= 0)
            {
                if (Healthycurrent < rowmax)
                {
                    if (Healthycurrent + Hplus > rowmax)
                        Healthycurrent = rowmax;
                    else
                        //接受增加
                        Healthycurrent = Healthycurrent + Hplus;
                    //同步到增加條
                    HRest.sizeDelta = new Vector2(Healthycurrent, HRest.sizeDelta.y);
                }
                else { Healthycurrent = rowmax; }
            }
            //Food
            Fplus = GameManager.food_v * 3;
            if (Fplus < 0)
            {
                //接受傷害
                Foodcurrent = Foodcurrent + Fplus;
                //同步到當前血量長度
                FRest.sizeDelta = new Vector2(Foodcurrent, FRest.sizeDelta.y);
                if (Foodcurrent <= 0)
                {
                    Foodcurrent = 0;
                    Fzero = true;
                }
            }
            else if (Fplus >= 0)
            {
                if (Foodcurrent < rowmax)
                {
                    if (Foodcurrent + Fplus > rowmax)
                        Foodcurrent = rowmax;
                    else
                        //接受增加
                        Foodcurrent = Foodcurrent + Fplus;
                    //同步到增加條
                    FRest.sizeDelta = new Vector2(Foodcurrent, FRest.sizeDelta.y);
                }
                else { Foodcurrent = rowmax; }
            }
            //Smart
            SMplus = GameManager.smart;
            if (SMplus < 0)
            {
                //接受傷害
                Smartcurrent = Smartcurrent + SMplus;
                SMmaximun = false;
                //同步到當前血量長度
                SMRest.sizeDelta = new Vector2(SMRest.sizeDelta.x, Smartcurrent);
                if (Smartcurrent <= 0)
                {
                    Smartcurrent = 0;
                    SMzero = true;
                }
            }
            else if (SMplus >= 0)
            {
                if (Smartcurrent < columnmax)
                {
                    if (Smartcurrent + SMplus >= columnmax)
                    {
                        Smartcurrent = columnmax;
                        SMmaximun = true;
                        SMzero = false;
                    }
                    else
                    {
                        //接受增加
                        Smartcurrent = Smartcurrent + SMplus;
                        SMmaximun = false;
                        SMzero = false;
                    }
                    //同步到增加條
                    SMRest.sizeDelta = new Vector2(SMRest.sizeDelta.x, Smartcurrent);
                }
                else
                {
                    Smartcurrent = columnmax;
                }
            }
            //ability
            Aplus = GameManager.ability;
            if (Aplus < 0)
            {
                //接受傷害
                Abilitycurrent = Abilitycurrent + Aplus;
                Amaximun = false;
                //同步到當前血量長度
                ARest.sizeDelta = new Vector2(ARest.sizeDelta.x, Abilitycurrent);
                if (Abilitycurrent <= 0)
                {
                    Abilitycurrent = 0;
                    Azero = true;
                }
            }
            else if (Aplus >= 0)
            {
                if (Abilitycurrent < columnmax)
                {
                    if (Abilitycurrent + Aplus >= columnmax)
                    {
                        Abilitycurrent = columnmax;
                        Amaximun = true;
                        Azero = false;
                    }
                    else
                    {
                        //接受增加
                        Abilitycurrent = Abilitycurrent + Aplus;
                        Amaximun = false;
                        Azero = false;
                    }
                    //同步到增加條
                    ARest.sizeDelta = new Vector2(ARest.sizeDelta.x, Abilitycurrent);
                }
                else
                {
                    Abilitycurrent = columnmax;
                }
            }
            //Social
            SOplus = GameManager.social;
            if (SOplus < 0)
            {
                //接受傷害
                Socialcurrent = Socialcurrent + SOplus;
                SOmaximun = false;
                //同步到當前血量長度
                SORest.sizeDelta = new Vector2(SORest.sizeDelta.x, Socialcurrent);
                if (Socialcurrent <= 0)
                {
                    Socialcurrent = 0;
                    SOzero = true;
                }
            }
            else if (SOplus >= 0)
            {
                if (Socialcurrent < columnmax)
                {
                    if (Socialcurrent + SOplus >= columnmax)
                    {
                        Socialcurrent = columnmax;
                        SOmaximun = true;
                        SOzero = false;
                    }
                    else
                    {
                        //接受增加
                        Socialcurrent = Socialcurrent + SOplus;
                        SOmaximun = false;
                        SOzero = false;
                    }
                    //同步到增加條
                    SORest.sizeDelta = new Vector2(SORest.sizeDelta.x, Socialcurrent);
                }
                else
                {
                    Socialcurrent = columnmax;
                }
            }
            //Money
            Mplus = GameManager.money;
            if (Mplus < 0)
            {
                //接受傷害
                Moneycurrent = Moneycurrent + Mplus;
                MOmax = false;
                //同步到當前血量長度
                MRest.sizeDelta = new Vector2(MRest.sizeDelta.x, Moneycurrent);
                if (Moneycurrent <= 0)
                {
                    Moneycurrent = 0;
                    Mzero = true;
                }
            }
            else if (Mplus >= 0)
            {
                if (Moneycurrent < columnmax)
                {
                    if (Moneycurrent + Mplus >= columnmax)
                    {
                        Moneycurrent = columnmax;
                        MOmax = true;
                        Mzero = false;
                    }
                    else
                    {
                        //接受增加
                        Moneycurrent = Moneycurrent + Mplus;
                       MOmax = false;
                       Mzero = false;
                    }
                    //同步到增加條
                    MRest.sizeDelta = new Vector2(MRest.sizeDelta.x, Moneycurrent);
                }
                else
                {
                    Moneycurrent = columnmax;
                }
            }

            if (MOmax == true)
            {
                puma++;
            }
            else
            {
                puma = 0;
            }
        }
    }
}
