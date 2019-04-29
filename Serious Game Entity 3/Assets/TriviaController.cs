using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class TriviaController : MonoBehaviour {

    public DrinkMixController drinkMixCon;
    public Button startTriviaButton;

    public GameObject dialogueBlock;
    public Text dialogue;
    public Button choice1Button;
    public Button choice2Button;
    public Button choice3Button;
    public Button choice4Button;
    Text choice1;
    Text choice2;
    Text choice3;
    Text choice4;

    public GameObject unlockBlock;
    Text unlockText;
    Image unlockImage;
    public Sprite mimosa;
    public Sprite ginAndTonic;

    public TextAsset questionInfo;
    List<string[]> questions = new List<string[]>();

    public int numQuestion;
    int questionsAnswered;

    bool answerCorrect = false;

    [HideInInspector]
    public bool triviaActivated = false;

    string triviaQuestion = "Hey, there's a new drink I'd like to try!";
    string triviaCorrect = "Great, so can I have a ";
    string triviaIncorrect = "Aw, maybe I can get it next time.";
    int dialogueIndex;

    public bool test = true;

    void Start () {
        InitializeTrivia();
	}
	
	void Update () {
        RunTrivia();
	}

    void InitializeTrivia()
    {
        unlockBlock.gameObject.SetActive(false);
        unlockText = unlockBlock.transform.GetChild(0).GetComponent<Text>();
        unlockImage = unlockBlock.transform.GetChild(1).GetComponent<Image>();

        choice1 = choice1Button.transform.GetChild(0).GetComponent<Text>();
        choice2 = choice2Button.transform.GetChild(0).GetComponent<Text>();
        choice3 = choice3Button.transform.GetChild(0).GetComponent<Text>();
        choice4 = choice4Button.transform.GetChild(0).GetComponent<Text>();
        dialogueBlock.gameObject.SetActive(false);
        disableQuestionChoices();

        // Store the questions in text file into a list a string arrays
        string[] splitedQuestions = questionInfo.text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
        numQuestion = splitedQuestions.Length / 7;
        for (int i = 0; i < numQuestion; i++)
        {
            string[] q = new string[7];
            for (int j = 0; j < 7; j++)
            {
                q[j] = splitedQuestions[i * 7 + j];
                
            }
            questions.Add(q);
        }

        questionsAnswered = 0;
        dialogueIndex = 0;
    }

    // Enable Trivia choices
    void enableQuestionChoices()
    {
        choice1Button.gameObject.SetActive(true);
        choice2Button.gameObject.SetActive(true);
        choice3Button.gameObject.SetActive(true);
        choice4Button.gameObject.SetActive(true);

    }
    // Disable Trivia choices
    void disableQuestionChoices()
    {
        choice1Button.gameObject.SetActive(false);
        choice2Button.gameObject.SetActive(false);
        choice3Button.gameObject.SetActive(false);
        choice4Button.gameObject.SetActive(false);
    }
    public void activateTrivia()
    {
        triviaActivated = true;
    }
    public void deactivateTrivia()
    {
        triviaActivated = false;
    }
    public bool checkTriviaActivated()
    {
        return triviaActivated;
    }

    void unlockDrink(string drink)
    {
        unlockBlock.gameObject.SetActive(true);
        unlockText.text = drink + " unlocked for drink mixing!";
        if (drink == "Mimosa")
        {
            unlockImage.sprite = mimosa;
        }
        else if (drink == "Gin And Tonic")
        {
            unlockImage.sprite = ginAndTonic;
        }
        numQuestion++;
        dialogueIndex++;
        answerCorrect = true;

        /* 
         * Need code to actually unlock the drink to be mixed
         */
    }

    void RunTrivia()
    {
        if (triviaActivated && questionsAnswered < questions.Count)
        {
            if (numQuestion == 0)
            {
                dialogue.text = "No Trivia Questions Available!";
                return;
            }
            else
            {
                dialogueBlock.gameObject.SetActive(true);

                if (dialogueIndex == 0)
                {
                    dialogue.text = triviaQuestion;
                }
                else if (dialogueIndex == 1)
                {
                    string[] temp = questions[questionsAnswered];
                    dialogue.text = temp[0];
                    choice1.text = temp[1];
                    choice2.text = temp[2];
                    choice3.text = temp[3];
                    choice4.text = temp[4];
                    enableQuestionChoices();
                }
                else if (dialogueIndex == 2)
                {
                    if (!answerCorrect)
                    {
                        dialogue.text = triviaIncorrect;
                        disableQuestionChoices();
                        dialogueIndex++;
                    }
                }
                else if (dialogueIndex == 3)
                {
                    unlockBlock.gameObject.SetActive(false);
                    if (answerCorrect)
                    {
                        disableQuestionChoices();
                        string[] temp = questions[questionsAnswered];
                        dialogue.text = triviaCorrect + temp[6] + "!";
                    }
                }
                else
                {
                    unlockBlock.gameObject.SetActive(false);
                    dialogueBlock.gameObject.SetActive(false);
                    triviaActivated = false;                   
                    dialogueIndex = 0;

                    if (!test && answerCorrect)
                    {
                        drinkMixCon.activateDrinkMix(numQuestion);
                    }

                    if (answerCorrect)
                    {
                        questionsAnswered++;
                    }     
                }

                if (Input.GetMouseButtonDown(0) && dialogueIndex != 1)
                {
                    dialogueIndex++;
                }
            }
        }
        else if (questionsAnswered >= questions.Count)
        {
            startTriviaButton.image.color = Color.red;
            triviaActivated = false;
        }
    }

    // Button functions
    public void initiateTrivia()
    {
        if (!drinkMixCon.checkDrinkMixActivated())
        {
            triviaActivated = true;
        }
    }

    public void triviaChoice1()
    {
        string[] temp = questions[questionsAnswered];
        if (temp[1] == temp[5])
        {
            unlockDrink(temp[6]);
        }
        else
        {
            answerCorrect = false;
            dialogueIndex++;
        }
    }

    public void triviaChoice2()
    {
        string[] temp = questions[questionsAnswered];
        if (temp[2] == temp[5])
        {
            unlockDrink(temp[6]);
        }
        else
        {
            answerCorrect = false;
            dialogueIndex++;
        }
    }

    public void triviaChoice3()
    {
        string[] temp = questions[questionsAnswered];
        if (temp[3] == temp[5])
        {
            unlockDrink(temp[6]);
        }
        else
        {
            answerCorrect = false;
            dialogueIndex++;
        }
    }

    public void triviaChoice4()
    {
        string[] temp = questions[questionsAnswered];
        if (temp[4] == temp[5])
        {
            unlockDrink(temp[6]);
        }
        else
        {
            answerCorrect = false;
            dialogueIndex++;
        }
    }
}
