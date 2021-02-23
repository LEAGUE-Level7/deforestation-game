using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStats : MonoBehaviour
{

    [SerializeField] Text text;
    [SerializeField] Text score;

    [SerializeField] ResourceLogic rLogic;

    string[] facts = { "18.7 million acres of forests are lost annually", "The Amazon, the planet's largest rainforest, lost at least 17% of its forest cover in the last half century due to human activity.", "Forests are home to 80% of the world’s terrestrial biodiversity.", "15% of all greenhouse gas emissions are the result of deforestation." };

    // Start is called before the first frame update
    void Start()
    {

        text.text = "Public Opinion: " + rLogic.getCitizenHappiness() + " - Profit: "+ rLogic.getMoney() + " -  Resources: " + rLogic.getPaperSupply();
        score.text = "Score: " + (rLogic.getCitizenHappiness() + rLogic.getMoney() + rLogic.getPaperSupply());
        Text forestFact = GameObject.Find("ForestFact").GetComponent<Text>();
        forestFact.text = facts[Random.Range(0, 4)];
        Debug.Log(forestFact);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
