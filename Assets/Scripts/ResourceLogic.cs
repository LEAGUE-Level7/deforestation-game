using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ResourceLogic : MonoBehaviour
{
    //values are out of 100
    private int paperSupply;
    private int citizenHappiness;
    private int money;
    //value is out of 5 with a HIGHER VALUE = SHORTER GAME!!
    private int lengthOfGame;
    private Boolean hasSetLength;


    // Start is called before the first frame update
    void Start()
    {
        paperSupply = 50;
        citizenHappiness = 50;
        money = 50;
        lengthOfGame = 2;
        hasSetLength = false;
    }

    // Update is called once per frame
    void Update()
    {


    }





    public void modifyPaperSupply(int amount, Boolean isIncrease, Boolean isDecrease)
    {
        if (isDecrease && paperSupply - amount * lengthOfGame >= 0)
        {

            paperSupply -= amount * lengthOfGame;

        }
        else if (isDecrease && paperSupply - amount * lengthOfGame < 0)
        {
            paperSupply = 0;
            Debug.Log("Minimum Paper Supply Reached");
        }
        else if (isIncrease && paperSupply + amount * lengthOfGame <= 100)
        {
            paperSupply += amount * lengthOfGame;
        }
        else if (isIncrease && paperSupply + amount * lengthOfGame > 100)
        {
            paperSupply = 100;
            Debug.Log("Maximum Paper Supply Reached");
        }


    }



    public void modifyHappiness(int amount, Boolean isIncrease, Boolean isDecrease) 
    {

        if (isDecrease && citizenHappiness- amount * lengthOfGame >= 0) {

            citizenHappiness -= amount * lengthOfGame;
            
        }else if (isDecrease && citizenHappiness- amount * lengthOfGame < 0)
        {
            citizenHappiness = 0;
            Debug.Log("Minimum Citizen Happiness Reached");
        }else if (isIncrease && citizenHappiness+ amount * lengthOfGame <= 100)
        {
            citizenHappiness += amount * lengthOfGame;
        }else if (isIncrease && citizenHappiness+ amount * lengthOfGame > 100)
        {
            citizenHappiness = 100;
            Debug.Log("Maximum Citizen Happiness Reached");
        }


    }


    public void modifyMoney(int amount, Boolean isIncrease, Boolean isDecrease)
    {

        if (isDecrease && money - amount * lengthOfGame >= 0)
        {

            money -= amount * lengthOfGame;

        }
        else if (isDecrease && money - amount * lengthOfGame < 0)
        {
            money = 0;
            Debug.Log("Minimum Citizen Happiness Reached");
        }
        else if (isIncrease && money + amount * lengthOfGame <= 100)
        {
            money += amount * lengthOfGame;
        }
        else if (isIncrease && money + amount * lengthOfGame > 100)
        {
            money = 100;
            Debug.Log("Maximum Citizen Happiness Reached");
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





}
