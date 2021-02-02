﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLogic : MonoBehaviour
{
    //values are out of 100
    private int paperSupply = 50;
    private int citizenHappiness = 50;
    private int money = 50;
    //value is out of 5 with a HIGHER VALUE = SHORTER GAME!!
    private int lengthOfGame = 2;
    private bool hasSetLength = false;

    [SerializeField] public Slider paperSlider;
    [SerializeField] public Slider happySlider;
    [SerializeField] public Slider profitSlider;
    [SerializeField] public Text percentPaper;
    [SerializeField] public Text percentProfit;
    [SerializeField] public Text percentHappy;
    private const int RESOURCE_MAX = 100;
    //MODIFY VALUES SHOULD BE -3  ->  3 TO MAKE GAME LENGTH APPROPRIATE
    public void Start()
    {
        Debug.Log(paperSupply);
        Debug.Log(citizenHappiness);
        Debug.Log(money);
    }
    public void modifyPaperSupply(int amount)
    {

        int amountChanged = paperSupply + amount * lengthOfGame;

       /* if (amount<0 &&  amountChanged >= 0)
        {

            paperSupply += amount * lengthOfGame;

        }
        else if (amount<0 && amountChanged < 0)
        {
            paperSupply = 0;
            Debug.Log("Minimum Paper Supply Reached");
        }
        else if (amount>0 && amountChanged <= 100)
        {
            paperSupply += amount * lengthOfGame;
        }
        else if (amount>0 && amountChanged > 100)
        {
            paperSupply = 100;
            Debug.Log("Maximum Paper Supply Reached");
        }*/
        paperSlider.value = ((float)paperSupply / RESOURCE_MAX);
        percentPaper.text = paperSlider.value*100 + " %";
    }



    public void modifyHappiness(int amount) 
    {

        int amountChanged = citizenHappiness + amount * lengthOfGame;

        /* if (amount<0 && amountChanged >= 0) {

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
         }*/

        profitSlider.value = ((float)money / RESOURCE_MAX) ;
        percentProfit.text = profitSlider.value*100 + " %";
        Debug.Log(profitSlider.value);
    }


    public void modifyMoney(int amount)
    {

        int amountChanged = money + amount * lengthOfGame;

        /*  if (amount<0 && amountChanged >= 0)
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
          }*/

        happySlider.value = ((float)citizenHappiness / RESOURCE_MAX);
        percentHappy.text = happySlider.value*100 + " %";

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
