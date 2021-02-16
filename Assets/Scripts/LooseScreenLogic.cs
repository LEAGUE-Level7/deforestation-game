using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LooseScreenLogic : MonoBehaviour
{
    
    [SerializeField] Text text;
    [SerializeField] ResourceLogic rLogic;
    // Start is called before the first frame update
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
