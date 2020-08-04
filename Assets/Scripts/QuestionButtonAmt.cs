using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonAmt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject button;
    [SerializeField] int buttonAmount;
    [SerializeField] int spacing;

    void Start()
    {
        float originalX = button.transform.position.x;
        for (int i = 1; i < buttonAmount; i++)
        {
            GameObject ButtonClone = Instantiate(button);
            ButtonClone.name = "Choice " + (i + 1);
            Vector3 position = new Vector3(button.transform.position.x, button.transform.position.y - (i * spacing), 0);
            ButtonClone.transform.position = position;
            Text ButtonText = ButtonClone.GetComponentInChildren(typeof(Text)) as Text;
            ButtonText.text = "Choice " + (i + 1);
            ButtonClone.transform.parent = GameObject.Find("Questions-Canvas/Choice 1").transform.parent;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
