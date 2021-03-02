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
    private int backgroundTracker = 0;
    private bool hasSetLength = false;


    [SerializeField] public Slider paperSlider;
    [SerializeField] public Slider happySlider;
    [SerializeField] public Slider profitSlider;
    [SerializeField] public Text percentPaper;
    [SerializeField] public Text percentProfit;
    [SerializeField] public Text percentHappy;
    private const int RESOURCE_MAX = 100;

    [SerializeField]
    private Image backgroundImage;

    private Sprite env1;
    private Sprite env2;
    private Sprite env3;
    private Sprite env4;
    private Sprite env5;
    private Sprite env6;

    private Sprite soc1;
    private Sprite soc2;
    private Sprite soc3;
    private Sprite soc4;
    private Sprite soc5;
    private Sprite soc6;

    private Sprite fac1;
    private Sprite fac2;
    private Sprite fac3;
    private Sprite fac4;
    private Sprite fac5;
    private Sprite fac6;
    public void Resetvalues()
    {
        paperSupply = 50;
        citizenHappiness = 50;
        money = 50;
    }
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
        
        soc1 = Resources.Load<Sprite>("social1");
        Debug.Log(soc1.name);
        soc2 = Resources.Load<Sprite>("social2");
        Debug.Log(soc2.name);
        soc3 = Resources.Load<Sprite>("social3");
        Debug.Log(soc3.name);
        soc4 = Resources.Load<Sprite>("social4");
        Debug.Log(soc4.name);
        soc5 = Resources.Load<Sprite>("social5");
        Debug.Log(soc5.name);
        soc6 = Resources.Load<Sprite>("social6");
        Debug.Log(soc6.name);

        fac1 = Resources.Load<Sprite>("factory1");
        Debug.Log(fac1.name);
        fac2 = Resources.Load<Sprite>("factory2");
        Debug.Log(fac2.name);
        fac3 = Resources.Load<Sprite>("factory3");
        Debug.Log(fac3.name);
        fac4 = Resources.Load<Sprite>("factory4");
        Debug.Log(fac4.name);
        fac5 = Resources.Load<Sprite>("factory5");
        Debug.Log(fac5.name);
        fac6 = Resources.Load<Sprite>("factory6");
        Debug.Log(fac6.name);

        backgroundImage.sprite = env3;
        backgroundTracker = 0;
    }


    //MODIFY VALUES SHOULD BE -3  ->  3 TO MAKE GAME LENGTH APPROPRIATE
    public void Start()
    {
        
        
       
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

       
        updateBackground();
    }



    public void modifyHappiness(int amount) 
    {

        int amountChanged = citizenHappiness + amount * lengthOfGame;

        citizenHappiness = amountChanged;
        happySlider.value = ((float)citizenHappiness / RESOURCE_MAX) ;
        percentHappy.text = happySlider.value*100 + " %";
        Debug.Log(profitSlider.value);

        updateBackground();


    }


    public void modifyMoney(int amount)
    {

        int amountChanged = money + amount * lengthOfGame;

        money = amountChanged;
        profitSlider.value = ((float)money / RESOURCE_MAX);
        percentProfit.text = profitSlider.value*100 + " %";

        updateBackground();

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

    public void buttonClick()
    {
        Debug.Log("button_clicked");
        if (backgroundTracker < 2)
        {
            backgroundTracker += 1;
        }
        else backgroundTracker = 0;
        updateBackground();
    }

    public void updateBackground()
    {
        if (backgroundTracker == 0) {
            if (paperSupply <= 16)
            {
                backgroundImage.sprite = env6;
            }
            else if (paperSupply <= 33)
            {
                backgroundImage.sprite = env5;
            }
            else if (paperSupply <= 49)
            {
                backgroundImage.sprite = env4;
            }
            else if (paperSupply <= 67)
            {
                backgroundImage.sprite = env3;
            }
            else if (paperSupply <= 84)
            {
                backgroundImage.sprite = env2;
            }
            else
            {
                backgroundImage.sprite = env1;
            }
        }
        if (backgroundTracker == 1)
        {
            if (money <= 16)
            {
                backgroundImage.sprite = fac1;
            }
            else if (money <= 33)
            {
                backgroundImage.sprite = fac2;
            }
            else if (money <= 49)
            {
                backgroundImage.sprite = fac3;
            }
            else if (money <= 67)
            {
                backgroundImage.sprite = fac4;
            }
            else if (money <= 84)
            {
                backgroundImage.sprite = fac5;
            }
            else
            {
                backgroundImage.sprite = fac6;
            }
        }
        if (backgroundTracker == 2)
        {
            if (citizenHappiness <= 16)
            {
                backgroundImage.sprite = soc6;
            }
            else if (citizenHappiness <= 33)
            {
                backgroundImage.sprite = soc5;
            }
            else if (citizenHappiness <= 49)
            {
                backgroundImage.sprite = soc4;
            }
            else if (citizenHappiness <= 67)
            {
                backgroundImage.sprite = soc3;
            }
            else if (citizenHappiness <= 84)
            {
                backgroundImage.sprite = soc2;
            }
            else
            {
                backgroundImage.sprite = soc1;
            }
        }

    }


}
