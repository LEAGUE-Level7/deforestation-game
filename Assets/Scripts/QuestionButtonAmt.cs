using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonAmt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button button;
    [SerializeField] Text questionText;
    [SerializeField] Text answerText;
   const string quesFile = "Questions\\Questions.json";
    //[SerializeField] int buttonAmount;
    String question;
    [SerializeField] String answer;
    [SerializeField] String[] buttons;
   //  [SerializeField] String[] questions;
    [SerializeField] String[] choices;
    [SerializeField] int spacing;
    [SerializeField] int n;


    //[SerializeField] String question;
    //[SerializeField] String[] valueChangersID;
    //[SerializeField] int[] valueChangers;


    [SerializeField]  static ResourceLogic resourceLogic;


    public class ResourceChanger
    {
        ArrayList valueChangersID = new ArrayList();
        ArrayList valueChangerMin = new ArrayList();
        ArrayList valueChangerMax = new ArrayList();
        System.Random r = new System.Random();

        public ResourceChanger()
        {
            

        }


        public void updateValues()
        {
            for(int i = 0; i < valueChangerMin.Count; i++)
            {
                String valId = valueChangersID[i].ToString();
                int valMin = (int) valueChangerMin[i];
                int valMax = (int) valueChangerMax[i];

                int modValue = r.Next(valMin, valMax);
                switch (valId)
                {
                    case "PublicOpinion":
                        resourceLogic.modifyHappiness(modValue);
                        break;
                    case "Money":
                        resourceLogic.modifyMoney(modValue);
                        break;
                    case "Forest":
                        resourceLogic.modifyForestSupply(-modValue);
                        break;
                    default:
                        Console.WriteLine("Error: A invalid stats modifyer has been input. ID: " + valId);
                        break;
                }

            }
        }

        void addEffect(String ID, int minChange, int maxChange)
        {
            valueChangersID.Add(ID);
            valueChangerMin.Add(minChange);
            valueChangerMax.Add(maxChange);
        }
    }

    void Start()
    {
        string fileName = Path.Combine(Application.dataPath, quesFile);
       
            //pass in the original text object and then the question as a string
        setQuestion(questionText, question, fileName);
        //pass in the original button and then a string array of the answers
        //createButtons(button, buttons,answer);
    }

    void setQuestion(Text questionText, String question, String fileName) {
        Debug.Log(fileName);
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            QuestionLists items = JsonUtility.FromJson<QuestionLists>(json);
            int randomQuestionSelect = UnityEngine.Random.Range(0, items.Questions.Length);
            question = items.Questions[randomQuestionSelect].Question;
            createButtons(button, items.Questions[randomQuestionSelect].Answers, "");

            /*for (int i = 0; i < items.Questions.Length; i++)
            {
                question = items.Questions[i].Question;
                Debug.Log(items.Questions[i].Question);
            }*/
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

    void modifyStats(int forestMod, int happinessMod, int moneyMod)
    {
        resourceLogic.modifyForestSupply(forestMod);
        resourceLogic.modifyHappiness(happinessMod);
        resourceLogic.modifyMoney(moneyMod);
    }

    void createButtons(Button originalButton, Answers[] answers, string answer)
    {
        Debug.Log(answers);
        float originalX = button.transform.position.x;
        Text ButtonText = originalButton.GetComponentInChildren(typeof(Text)) as Text;
        ButtonText.text = answers[0].AnswerText;
        originalButton.onClick.AddListener(delegate {
            //print("original"); 
            int paperMod;
            int happinessMod;
            int moneyMod;
            

        });


        for (int i = 1; i < answers.Length; i++)
        {
            //answers[i] = answer;
            Button ButtonClone = Instantiate(originalButton);
            ButtonClone.name = "Choice " + (i + 1);
            ButtonClone.onClick.AddListener(delegate { print("aaa"); });
            Vector3 position = new Vector3(button.transform.position.x, button.transform.position.y - (i * spacing), 0);
            ButtonClone.transform.position = position;
            ButtonText = ButtonClone.GetComponentInChildren(typeof(Text)) as Text;
            ButtonText.text = answers[0].AnswerText;
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
    public Answers[] Answers;
    public string ConditionType;
    public bool placeholderTile;
}
//[Serializable]
public class Answers
{
    public string AnswerText;
    public string ConditionType;
    public bool placeholderTile;
}