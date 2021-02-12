using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLogic : MonoBehaviour
{
    //values are out of 100
    static private int paperSupply ;
    static private int citizenHappiness;
    static private int money;
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
        citizenHappiness = 50;
        money = 50;
        paperSupply = 50;
        modifyHappiness(0);
        modifyMoney(0);
        modifyPaperSupply(0);
    }
    public void modifyPaperSupply(int amount)
    {

        int amountChanged = paperSupply + amount * lengthOfGame;
        paperSupply = amountChanged;
        paperSlider.value = ((float)paperSupply / RESOURCE_MAX);
        percentPaper.text = paperSlider.value*100 + " %";
    }



    public void modifyHappiness(int amount) 
    {

        int amountChanged = citizenHappiness + amount * lengthOfGame;
        citizenHappiness = amountChanged;
        happySlider.value = ((float)citizenHappiness / RESOURCE_MAX) ;
        percentHappy.text = happySlider.value*100 + " %";
        Debug.Log(profitSlider.value);
    }


    public void modifyMoney(int amount)
    {

        int amountChanged = money + amount * lengthOfGame;
        money = amountChanged;
        profitSlider.value = ((float)money / RESOURCE_MAX);
        percentProfit.text = profitSlider.value*100 + " %";

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
