using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooseScreenLogic : MonoBehaviour
{
    
    [SerializeField] Text text;
    [SerializeField] ResourceLogic rLogic;
    // Start is called before the first frame update
    string[] facts = { "18.7 million acres of forests are lost annually", "The Amazon, the planet's largest rainforest, lost at least 17% of its forest cover in the last half century due to human activity.", "Forests are home to 80% of the world’s terrestrial biodiversity.", "15% of all greenhouse gas emissions are the result of deforestation." };

    void Start()
    {
        string reason = "Error";
        if(rLogic.getMoney() < 1){
            reason = "Lack of Funds Were";
        }else if(rLogic.getCitizenHappiness() < 1){
            reason = "Riots Were";

        }else if(rLogic.getPaperSupply() < 1){
            reason = "Lack of stock was";
        }
        text.text = reason + " the death of your company";
        Debug.Log(rLogic.getMoney() + " " + rLogic.getCitizenHappiness() + " " + rLogic.getPaperSupply());
        Text forestFact = GameObject.Find("ForestFact").GetComponent<Text>();
        forestFact.text = facts[Random.Range(0, 4)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
