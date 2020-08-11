using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonAmt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject button;
    [SerializeField] Text questionText;

    //[SerializeField] int buttonAmount;
    [SerializeField] String question;
    [SerializeField] String[] buttons;
    [SerializeField] int spacing;

    void Start()
    {
        //pass in the original text object and then the question as a string
        setQuestion(questionText, question);
        //pass in the original button and then a string array of the answers

        createButtons(button, buttons);
    }

    void setQuestion(Text questionText, String question)
    {
        questionText.text = question;
    }

    void createButtons(GameObject originalButton, String[] answers)
    {
        float originalX = button.transform.position.x;

        Text ButtonText = originalButton.GetComponentInChildren(typeof(Text)) as Text;
        ButtonText.text = answers[0];

        for (int i = 1; i < answers.Length; i++)
        {
            GameObject ButtonClone = Instantiate(originalButton);
            ButtonClone.name = "Choice " + (i + 1);
            Vector3 position = new Vector3(button.transform.position.x, button.transform.position.y - (i * spacing), 0);
            ButtonClone.transform.position = position;
            ButtonText = ButtonClone.GetComponentInChildren(typeof(Text)) as Text;
            ButtonText.text = answers[i];
            ButtonClone.transform.parent = GameObject.Find("Questions-Canvas/Choice 1").transform.parent;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
