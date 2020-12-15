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
   const string quesFile = "Questions\\Questions.json";

    [SerializeField] int spacing;

    [SerializeField] ResourceLogic resourceManager;


    //[SerializeField] int n;
    int selectedQuestionID;


    void Start()
    {
        setup();
        button.GetComponent<Button>().onClick.AddListener(delegate {
            reset();
        });
    }


    public void reset()
    {
        for (int i = 2; i < 10; i++)
        {
            GameObject go = GameObject.Find("Choice " + i);

            try
            {
                Destroy(go.gameObject);
            }
            catch (Exception e) { }
                


        }
        setup();

    }
    public void setup()
    {
        print("e");
        string fileName = Path.Combine(Application.dataPath, quesFile);

        //pass in the original text object and then the question as a string
        //setQuestion(questionText, question, fileName);
        Debug.Log(fileName);
        using (StreamReader r = new StreamReader(fileName))
        {


            string json = r.ReadToEnd();
            QuestionLists items = JsonUtility.FromJson<QuestionLists>(json);
            /*for (int i = 0; i < items.Questions.Length; i++)
            {
                question = items.Questions[i].Question;
                Debug.Log(items.Questions[i].Question);
            }*/

            selectedQuestionID = (int)Math.Floor((float)(new System.Random().NextDouble()) * items.Questions.Length);


            questionText.text = items.Questions[selectedQuestionID].Question;



            //pass in the original button and then a string array of the answers

            string[] questions = new String[items.Questions[selectedQuestionID].Answers.Length];
            string[,] types = new String[items.Questions[selectedQuestionID].Answers.Length, 8];
            int[,] max = new int[items.Questions[selectedQuestionID].Answers.Length, 8];
            int[,] min = new int[items.Questions[selectedQuestionID].Answers.Length, 8];

            for (int i = 0; i < items.Questions[selectedQuestionID].Answers.Length; i++)
            {
                questions[i] = items.Questions[selectedQuestionID].Answers[i].AnswerText;

                for (int j = 0; j < items.Questions[selectedQuestionID].Answers[i].Effects.Length; j++)
                {
                    types[i, j] = items.Questions[selectedQuestionID].Answers[i].Effects[j].Type;
                    min[i, j] = items.Questions[selectedQuestionID].Answers[i].Effects[j].MinEffect;
                    max[i, j] = items.Questions[selectedQuestionID].Answers[i].Effects[j].MaxEffect;
                }
                //types[i] = items.Questions[selectedQuestionID].Answers[i].Effects[0].Type;
                //min[i] = items.Questions[selectedQuestionID].Answers[i].Effects[0].MinEffect;
                //max[i] = items.Questions[selectedQuestionID].Answers[i].Effects[0].MaxEffect;


            }

            createButtons(button, questions, types, max, min);
        }

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

void createButtons(GameObject originalButton, String[] answers, String[,] types, int[,] max, int[,] min)
    {
        float originalX = button.transform.position.x;


        Text ButtonText = originalButton.GetComponentInChildren(typeof(Text)) as Text;

        ButtonText = button.GetComponentInChildren(typeof(Text)) as Text;
        ButtonText.text = answers[0];
        originalButton.GetComponent<Button>().onClick.AddListener(delegate {
            for (int l = 0; l < 8; l++)
            {
                updateResources(types[0, l], (int)UnityEngine.Random.Range(min[0, l], max[0, l]));
            }
            //reset();
        });

        for (int i = 1; i < answers.Length; i++)
        {
            GameObject ButtonClone = Instantiate(originalButton);
            ButtonClone.name = "Choice " + (i + 1);
            Vector3 position = new Vector3(button.transform.position.x, button.transform.position.y - (i * spacing), 0);
            ButtonClone.transform.position = position;
            ButtonText = ButtonClone.GetComponentInChildren(typeof(Text)) as Text;
            ButtonText.text = answers[i];
            ButtonClone.transform.parent = GameObject.Find("Questions-Canvas/Choice 1").transform.parent;

            int j = i;
            ButtonClone.GetComponent<Button>().onClick.AddListener(delegate {
                for (int l = 0; l < 8; l++)
                {
                    updateResources(types[j,l], (int)UnityEngine.Random.Range(min[j,l], max[j,l]));
                }
                reset();
            });
        }
    }



    public void updateResources(String r, int amount)
    {
        switch (r) {
            case "Money":
                //print(resourceManager.getMoney() + " " + amount);

                resourceManager.modifyMoney(amount);
                //print(resourceManager.getMoney());
                break;
            case "Forest":
                //print(resourceManager.getPaperSupply() + " " + amount);

                resourceManager.modifyPaperSupply(amount);
                //print(resourceManager.getPaperSupply());
                break;
            case "PublicOpinion":
                //print(resourceManager.getCitizenHappiness() + " " + amount);
                resourceManager.modifyHappiness(amount);
                //print(resourceManager.getCitizenHappiness());
                break;

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
[Serializable]
public class Answers
{
    public string AnswerText;
    public Effects[] Effects;
}

[Serializable]
public class Effects
{
    public string Type;
    public int MinEffect;
    public int MaxEffect;

}