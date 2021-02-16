using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLogic : MonoBehaviour
{
    //values are out of 100
    static private int paperSupply = 50;
    static private int citizenHappiness = 50;
    static private int money = 50;
    //value is out of 5 with a HIGHER VALUE = SHORTER GAME!!
    private int lengthOfGame = 2;
    private bool hasSetLength = false;

    [SerializeField]
    private Image backgroundImage;

    private Sprite env1;
    private Sprite env2;
    private Sprite env3;
    private Sprite env4;
    private Sprite env5;
    private Sprite env6;

    public void Awake()
    {
        env1 = Resources.Load<Sprite>("env1");
        Debug.Log(env1.name);
        env2 = Resources.Load<Sprite>("env2");
        Debug.Log(env2.name);
        env3 = Resources.Load<Sprite>("env3");
        Debug.Log(env3.name);
        env4 = Resources.Load<Sprite>("env4");
        Debug.Log(env4.name);
        env5 = Resources.Load<Sprite>("env5");
        Debug.Log(env5.name);
        env6 = Resources.Load<Sprite>("env6");
        Debug.Log(env6.name);
        backgroundImage.sprite = env3;
    }

    //MODIFY VALUES SHOULD BE -3  ->  3 TO MAKE GAME LENGTH APPROPRIATE

    public void modifyPaperSupply(int amount)
    {

        int amountChanged = paperSupply + amount * lengthOfGame;

        if (amount < 0 && amountChanged >= 0)
        {

            paperSupply += amount * lengthOfGame;

        }
        else if (amount < 0 && amountChanged < 0)
        {
            paperSupply = 0;
            Debug.Log("Minimum Paper Supply Reached");
        }
        else if (amount > 0 && amountChanged <= 100)
        {
            paperSupply += amount * lengthOfGame;
        }
        else if (amount > 0 && amountChanged > 100)
        {
            paperSupply = 100;
            Debug.Log("Maximum Paper Supply Reached");
        }

        if (paperSupply <= 16 && paperSupply >= 0)
        {
            backgroundImage.sprite = env6;
        }
        else if (paperSupply <= 33 && paperSupply >= 17)
        {
            backgroundImage.sprite = env5;
        }
        else if (paperSupply <= 50 && paperSupply >= 34)
        {
            backgroundImage.sprite = env4;
        }
        else if (paperSupply <= 66 && paperSupply >= 51)
        {
            backgroundImage.sprite = env3;
        }
        else if (paperSupply <= 83 && paperSupply >= 67)
        {
            backgroundImage.sprite = env2;
        }
        else if (paperSupply <= 100 && paperSupply >= 84)
        {
            backgroundImage.sprite = env1;
        }


    }



    public void modifyHappiness(int amount) 
    {

        int amountChanged = citizenHappiness + amount * lengthOfGame;

        if (amount<0 && amountChanged >= 0) {

            citizenHappiness += amount * lengthOfGame;
            
        }else if (amount<0 && amountChanged < 0)
        {
            citizenHappiness = 0;
            Debug.Log("Minimum Citizen Happiness Reached");
        }else if (amount>0 && amountChanged <= 100)
        {
            citizenHappiness += amount * lengthOfGame;
        }else if (amount>0 && amountChanged > 100)
        {
            citizenHappiness = 100;
            Debug.Log("Maximum Citizen Happiness Reached");
        }


    }


    public void modifyMoney(int amount)
    {

        int amountChanged = money + amount * lengthOfGame;

        if (amount<0 && amountChanged >= 0)
        {

            money += amount * lengthOfGame;

        }
        else if (amount<0 && amountChanged < 0)
        {
            money = 0;
            Debug.Log("Minimum Money Reached");
        }
        else if (amount>0 && amountChanged <= 100)
        {
            money += amount * lengthOfGame;
        }
        else if (amount>0 && amountChanged > 100)
        {
            money = 100;
            Debug.Log("Maximum Money Reached");
        }


    }


    public int getMoney()
    {
        return money;
    }

    public int getCitizenHappiness()
    {
        return citizenHappiness;
    }

    public int getPaperSupply()
    {
        return paperSupply;
    }
   


    public void setGameLength(int gameLength5through1)
    {
        if (gameLength5through1 > 0 && gameLength5through1 <= 5 && !hasSetLength)
        {
            this.lengthOfGame = gameLength5through1;
            hasSetLength = true;
        }else if (hasSetLength)
        {
            Debug.Log("Length should not change midgame!");
        }else if (gameLength5through1 <= 0 || gameLength5through1 > 5)
        {
            Debug.Log("You have exceed the range of values for gameLength. Length of game should be set from a number 1-5 with 5 being a shortest game and 1 being the longest game.");
        }
    }

    public void setBackground(int imageShown)
    {

    }





}
