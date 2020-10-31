using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonAmt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject button;
    [SerializeField] Text questionText;
    [SerializeField] Text answerText;
    const string quesFile = "C:\\Users\\Cindy\\Desktop\\deforestation-game\\Assets\\Questions\\Questions.json";
    //[SerializeField] int buttonAmount;
    [SerializeField] String question;
    [SerializeField] String answer;
    [SerializeField] String[] buttons;
   //  [SerializeField] String[] questions;
    [SerializeField] String[] choices;
    [SerializeField] int spacing;
    [SerializeField] int n;
    void Start()
    {
        //pass in the original text object and then the question as a string
        setQuestion(questionText, question);
        //pass in the original button and then a string array of the answers
        createButtons(button, buttons,answer);
    }
    void setQuestion(Text questionText, String question) {
        string fileName = Path.Combine(Application.dataPath, quesFile);
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            QuestionLists items = JsonUtility.FromJson<QuestionLists>(json);
            for (int i = 0; i < items.Questions.Length; i++)
            {
                question = items.Questions[i].Question;
                Debug.Log(items.Questions[i].Question);
            }
        }
        questionText.text = question;
            
    }
   /* void setAnswers(Text answerText, String answer)
    {
        string fileName = Path.Combine(Application.dataPath, quesFile);
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            QuestionLists items = JsonUtility.FromJson<QuestionLists>(json);
            for (int i = 0; i <; i++)
            {
                answer = items.Questions[i].Answers[i].AnswerText;
                Debug.Log(items.Questions[i].Answers[i].AnswerText);
            }
        }
        answerText.text = answer;

    }*/
    void onCLickChoice(GameObject originalButton, int n)
    {
        Debug.Log("clicked");
    }

    void createButtons(GameObject originalButton, String[] answers, string answer)
    {
        float originalX = button.transform.position.x;
        Text ButtonText = originalButton.GetComponentInChildren(typeof(Text)) as Text;
        //setAnswers(answerText, answer);
        for (int i = 1; i < answers.Length; i++)
        {
            answers[i] = answer;
            GameObject ButtonClone = Instantiate(originalButton);
            ButtonClone.name = "Choice " + (i + 1);
            Vector3 position = new Vector3(button.transform.position.x, button.transform.position.y - (i * spacing), 0);
            ButtonClone.transform.position = position;
            ButtonText = ButtonClone.GetComponentInChildren(typeof(Text)) as Text;
            ButtonText.text = answers[i];
            ButtonClone.transform.parent = GameObject.Find("Questions-Canvas/Choice 1").transform.parent;

        }
    }
}
[Serializable]
public class QuestionLists
{ 
    public Questions[] Questions;
}
[Serializable]
public class Questions
{
    public string Question;
 //  public Answers[] Answers;
    public string ConditionType;
    public bool placeholderTile;
}
//[Serializable]
/*public class Answers
{
    public string AnswerText;
    public string ConditionType;
    public bool placeholderTile;
}*/