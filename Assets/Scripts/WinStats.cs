using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStats : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] Text score;

    [SerializeField] ResourceLogic rLogic;
    // Start is called before the first frame update
    void Start()
    {

        text.text = "Public Opinion: " + rLogic.getCitizenHappiness() + " - Profit: "+ rLogic.getMoney() + " -  Resources: " + rLogic.getPaperSupply();
        score.text = "Score: " + (rLogic.getCitizenHappiness() + rLogic.getMoney() + rLogic.getPaperSupply());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
