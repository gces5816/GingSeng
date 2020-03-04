using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public GameObject FMNJCardPrefab;
    public GameObject clone;

    static public int money, health, food_v, smart, ability, social;

    public string left, right;
    public string image;

    static public string lastimage;
    static public string lastleft, lastright;

    public art art;
    public business business;
    public medical medical;
    public science science;

    public food food;
    public normal normal;
    public ghost joker;

    public FMNCard FMNJCards;

    public Vector3 spawnPoints;

    private int kind;
    static public int cardnum;
    private int Events = 0;
    static public int Days = 1;
    static public int joke = 0;

    static public int CardKind = 0;

    // Update is called once per frame
    private void Update()
    {
        if (CardMove.destroy == 1)
        {
            Events += 1;
            Value();
            clone.SetActive(false);
            Destroy(clone);
            Card();
        }
        if (Events == 3)
        {
            Days += 1;
            Events = 0;
        }
    }

    private void Value()
    {
        if (joke == 0 && CardMove.isleft == 1)
        {
            //普通
            if (kind < 137)
            {
                money = normal.dataArray[cardnum].Lmoney;
                health = normal.dataArray[cardnum].Lhealth;
                food_v = normal.dataArray[cardnum].Lfood;
                smart = normal.dataArray[cardnum].Lsmart;
                ability = normal.dataArray[cardnum].Lability;
                social = normal.dataArray[cardnum].Lsocial;
            }
            //主線
            else if (kind < 167)
            {
                if (changescenes.volunteer == "medical")
                {
                    money = medical.dataArray[cardnum].Lmoney;
                    health = medical.dataArray[cardnum].Lhealth;
                    food_v = medical.dataArray[cardnum].Lfood;
                    smart = medical.dataArray[cardnum].Lsmart;
                    ability = medical.dataArray[cardnum].Lability;
                    social = medical.dataArray[cardnum].Lsocial;
                }
                else if (changescenes.volunteer == "science")
                {
                    money = science.dataArray[cardnum].Lmoney;
                    health = science.dataArray[cardnum].Lhealth;
                    food_v = science.dataArray[cardnum].Lfood;
                    smart = science.dataArray[cardnum].Lsmart;
                    ability = science.dataArray[cardnum].Lability;
                    social = science.dataArray[cardnum].Lsocial;
                }
                else if (changescenes.volunteer == "business")
                {
                    money = business.dataArray[cardnum].Lmoney;
                    health = business.dataArray[cardnum].Lhealth;
                    food_v = business.dataArray[cardnum].Lfood;
                    smart = business.dataArray[cardnum].Lsmart;
                    ability = business.dataArray[cardnum].Lability;
                    social = business.dataArray[cardnum].Lsocial;
                }
                else if (changescenes.volunteer == "art")
                {
                    money = art.dataArray[cardnum].Lmoney;
                    health = art.dataArray[cardnum].Lhealth;
                    food_v = art.dataArray[cardnum].Lfood;
                    smart = art.dataArray[cardnum].Lsmart;
                    ability = art.dataArray[cardnum].Lability;
                    social = art.dataArray[cardnum].Lsocial;
                }
            }
            //餵食
            else if (kind < 197)
            {
                money = food.dataArray[cardnum].Lmoney;
                health = food.dataArray[cardnum].Lhealth;
                food_v = food.dataArray[cardnum].Lfood;
                smart = food.dataArray[cardnum].Lsmart;
                ability = food.dataArray[cardnum].Lability;
                social = food.dataArray[cardnum].Lsocial;
            }
        }
        else if (joke == 0 && CardMove.isright == 1)
        {
            //普通
            if (kind < 137)
            {
                money = normal.dataArray[cardnum].Rmoney;
                health = normal.dataArray[cardnum].Rhealth;
                food_v = normal.dataArray[cardnum].Rfood;
                smart = normal.dataArray[cardnum].Rsmart;
                ability = normal.dataArray[cardnum].Rability;
                social = normal.dataArray[cardnum].Rsocial;
            }
            //主線
            else if (kind < 167)
            {
                if (changescenes.volunteer == "medical")
                {
                    money = medical.dataArray[cardnum].Rmoney;
                    health = medical.dataArray[cardnum].Rhealth;
                    food_v = medical.dataArray[cardnum].Rfood;
                    smart = medical.dataArray[cardnum].Rsmart;
                    ability = medical.dataArray[cardnum].Rability;
                    social = medical.dataArray[cardnum].Rsocial;
                }
                else if (changescenes.volunteer == "science")
                {
                    money = science.dataArray[cardnum].Rmoney;
                    health = science.dataArray[cardnum].Rhealth;
                    food_v = science.dataArray[cardnum].Rfood;
                    smart = science.dataArray[cardnum].Rsmart;
                    ability = science.dataArray[cardnum].Rability;
                    social = science.dataArray[cardnum].Rsocial;
                }
                else if (changescenes.volunteer == "business")
                {
                    money = business.dataArray[cardnum].Rmoney;
                    health = business.dataArray[cardnum].Rhealth;
                    food_v = business.dataArray[cardnum].Rfood;
                    smart = business.dataArray[cardnum].Rsmart;
                    ability = business.dataArray[cardnum].Rability;
                    social = business.dataArray[cardnum].Rsocial;
                }
                else if (changescenes.volunteer == "art")
                {
                    money = art.dataArray[cardnum].Rmoney;
                    health = art.dataArray[cardnum].Rhealth;
                    food_v = art.dataArray[cardnum].Rfood;
                    smart = art.dataArray[cardnum].Rsmart;
                    ability = art.dataArray[cardnum].Rability;
                    social = art.dataArray[cardnum].Rsocial;
                }
            }
            //餵食
            else if (kind < 197)
            {
                money = food.dataArray[cardnum].Rmoney;
                health = food.dataArray[cardnum].Rhealth;
                food_v = food.dataArray[cardnum].Rfood;
                smart = food.dataArray[cardnum].Rsmart;
                ability = food.dataArray[cardnum].Rability;
                social = food.dataArray[cardnum].Rsocial;
            }
        }
    }

    private void Start()
    {
        if (changescenes.FromScene == 3)
        {
            Days = 1;
            Card();
            CardKind = 0;
        }
        else
        {
            backDisplay();
        }
    }
    private void Card()
    {
        DrawCard();
        Display();
    }

    private void DrawCard()
    {
        joke = 0;
        long tick = DateTime.Now.Ticks;
        System.Random ran = new System.Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        kind = ran.Next(0, 199);
        //普通卡
        if (kind < 137 )
        {
            CardKind = 1;
            //第幾張卡
            cardnum = ran.Next(0,44);
            left = normal.dataArray[cardnum].Left;
            right = normal.dataArray[cardnum].Right;
            image = "normal/" + normal.dataArray[cardnum].Image;
        }
        //主線
        else if (kind < 167)
        {
            CardKind = 2;
            cardnum = ran.Next(0,9);
            if (changescenes.volunteer == "medical")
            {
                left = medical.dataArray[cardnum].Left;
                right = medical.dataArray[cardnum].Right;
                image = "medical/" + medical.dataArray[cardnum].Image;
            }
            else if (changescenes.volunteer == "science")
            {
                left = science.dataArray[cardnum].Left;
                right = science.dataArray[cardnum].Right;
                image = "science/" + science.dataArray[cardnum].Image;
            }
            else if (changescenes.volunteer == "business")
            {
                left = business.dataArray[cardnum].Left;
                right = business.dataArray[cardnum].Right;
                image = "business/" + business.dataArray[cardnum].Image;
            }
            else if (changescenes.volunteer == "art")
            {
                left = art.dataArray[cardnum].Left;
                right = art.dataArray[cardnum].Right;
                image = "art/" + art.dataArray[cardnum].Image;
            }
        }
        //餵食
        else if (kind < 197)
        {
            CardKind = 3;
            cardnum = ran.Next(0,9);
            left = food.dataArray[cardnum].Left;
            right = food.dataArray[cardnum].Right;
            image = "food/" + food.dataArray[cardnum].Image;
        }
        //鬼牌
        else if (kind < 200)
        {
            CardKind = 4;
            joke = 1;
            cardnum = ran.Next(0,9);
            left = joker.dataArray[cardnum].Left;
            right = joker.dataArray[cardnum].Right;
            image = "ghost/" + joker.dataArray[cardnum].Image;
        }
    }

    private void Display()
    {
        FMNJCards.left = left;
        FMNJCards.right = right;
        FMNJCards.picture = Resources.Load<Sprite>(image);
        lastimage = image;
        lastleft = left;
        lastright = right;
        clone = Instantiate(FMNJCardPrefab, spawnPoints, Quaternion.identity);
        FMNCardDisplay display = clone.GetComponent<FMNCardDisplay>();
        display.FMNCardSetup(FMNJCards);
    }

    private void backDisplay()
    {
        FMNJCards.left = lastleft;
        FMNJCards.right = lastright;
        FMNJCards.picture = Resources.Load<Sprite>(lastimage);
        clone = Instantiate(FMNJCardPrefab, spawnPoints, Quaternion.identity);
        FMNCardDisplay display = clone.GetComponent<FMNCardDisplay>();
        display.FMNCardSetup(FMNJCards);
    }
}