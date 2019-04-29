using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkMixController : MonoBehaviour {
    // I have the point system setup in the gamecontroller script
    // every time you successfully mix a drink, you should add some point

    // also, I have the trivia part set up so that everytime you answered the question
    // correctly, you need to mix that unlocked drink (according to the design doc)
    // I have the "test" parameter checked to only show the trivia part
    // please make sure to uncheck it before running your implementation.
    // just remember to set the drinkMixActivated to false once you mixed a drink or failed to
    // mix a drink


    // please let me know if you have any questions with my code

    public GameController _GameController;
    public TriviaController _TriviaController;
    public GameObject FinishedDrink;
    public GameObject ButtonBlocker;

    bool drinkMixActivated = false;

    string orderDrinkCorrect = "'Perfect, thank you!'";
    string orderDrinkWrongOrder = "'It's got the right ingredients, but...\nit's not done in the right order.'";
    string orderDrinkIncorrect = "'This isn't what I ordered'";

    int DrinkNum = 0; 
    /*
    1 = Rum & Coke; 
    2 = Screw Driver; 
    3 = Mimosa; 
    4 = Gin & Tonic;
    */

    public GameObject DMScreen;
    public GameObject QuitMixingButton;
    public Text DrinkWanted;
    public Text Ingredients;
    public GameObject SubmitDrink;
    public GameObject RetryButton;
    

    [Header("Selection Set A")]
    public GameObject SelectionSetA;
    public GameObject SelectionBoxA1;
    public GameObject SelectionA1;
    public GameObject SelectionBoxA2;
    public GameObject SelectionA2;

    [Header("Selection Set B")]
    public GameObject SelectionSetB;
    public GameObject SelectionBoxB1;
    public GameObject SelectionB1;
    public GameObject SelectionBoxB2;
    public GameObject SelectionB2;
    public GameObject SelectionBoxB3;
    public GameObject SelectionB3;

    [Header("Ingredient Images")]
    public Sprite Coke;
    public Sprite Vodka;
    public Sprite Rum;
    public Sprite OJ;
    public Sprite Tonic;
    public Sprite Gin;
    public Sprite TripleSec;
    public Sprite Lime;
    public Sprite Champagne;
    public Sprite Blank;

    [Header("Finished Drink Images")]
    public Sprite RumCoke;
    public Sprite ScrewDriver;
    public Sprite Mimosa;
    public Sprite GinTonic;

    public int IngrSelectNum = 0;
    /*
     1-2 = 1st and 2nd ingredients of a 2-step drink
     4-6 = 1st, 2nd, and 3rd ingredients of a 3-step drink
    */

    void Start () {
        DMScreen.SetActive(false);
    }


    void Update()
    {
        if (drinkMixActivated)
        {
            //Highlight the Current Ingredient Slot
            switch (IngrSelectNum)
            {
                //Box A1
                case 1:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        break;
                    }
                //Box A2
                case 2:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        break;
                    }
                //Box B1
                case 4:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        break;
                    }
                //Box B2
                case 5:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        break;
                    }
                //Box B3
                case 6:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
                        break;
                    }
                default:
                    {
                        SelectionBoxA1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxA2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB1.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB2.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        SelectionBoxB3.GetComponent<Image>().color = new Color32(0, 0, 0, 100);
                        break;
                    }
            }

            if (IngrSelectNum == 3 || IngrSelectNum == 7)
            {
                SubmitDrink.SetActive(true);
                RetryButton.SetActive(true);
            } else
            {
                SubmitDrink.SetActive(false);
                RetryButton.SetActive(false);
            }



        }

    }

    public void AddIngredient(int IngrNum)
    {
        if (IngrSelectNum != 3 && IngrSelectNum < 7)
        {
            GameObject SelectionDummy = SelectionA1;
            GameObject SelectionDummyBox = SelectionBoxA1;
            switch (IngrSelectNum)
            {
                //Box A1
                case 1:
                    {
                        SelectionDummy = SelectionA1;
                        SelectionDummyBox = SelectionBoxA1;
                        break;
                    }
                //Box A2
                case 2:
                    {
                        SelectionDummy = SelectionA2;
                        SelectionDummyBox = SelectionBoxA2;
                        break;
                    }
                //Box B1
                case 4:
                    {
                        SelectionDummy = SelectionB1;
                        SelectionDummyBox = SelectionBoxB1;
                        break;
                    }
                //Box B2
                case 5:
                    {
                        SelectionDummy = SelectionB2;
                        SelectionDummyBox = SelectionBoxB2;
                        break;
                    }
                //Box B3
                case 6:
                    {
                        SelectionDummy = SelectionB3;
                        SelectionDummyBox = SelectionBoxB3;
                        break;
                    }
                default:
                    {
                        SelectionDummy = SelectionA1;
                        SelectionDummyBox = SelectionBoxA1;
                        break;
                    }
            }


            switch (IngrNum)
            {
                case 1:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Coke;
                        break;
                    }
                case 2:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Vodka;
                        break;
                    }
                case 3:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Rum;
                        break;
                    }
                case 4:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = OJ;
                        break;
                    }
                case 5:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Tonic;
                        break;
                    }
                case 6:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Gin;
                        break;
                    }
                case 7:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = TripleSec;
                        break;
                    }
                case 8:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Lime;
                        break;
                    }
                case 9:
                    {
                        SelectionDummy.GetComponent<Image>().sprite = Champagne;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            SelectionDummyBox.GetComponent<Ingredient>().IngredientNum = IngrNum;
            IngrSelectNum++;
        }
    }


    public void RemoveIngredient ()
    {
        SelectionA1.GetComponent<Image>().sprite = Blank;
        SelectionA2.GetComponent<Image>().sprite = Blank;
        SelectionB1.GetComponent<Image>().sprite = Blank;
        SelectionB2.GetComponent<Image>().sprite = Blank;
        SelectionB3.GetComponent<Image>().sprite = Blank;
        if (IngrSelectNum <= 3)
        {
            IngrSelectNum = 1;
        } else
        {
            IngrSelectNum = 4;
        }
    }
       


    public void StartRandomDrink()
    {
        if (_TriviaController.numQuestion == 2)
            activateDrinkMix(Random.Range(1, 3));
        if (_TriviaController.numQuestion == 3)
            activateDrinkMix(Random.Range(1, 4));
        if (_TriviaController.numQuestion == 4)
            activateDrinkMix(Random.Range(1, 5));
    }


    public void activateDrinkMix(int Drink)
    {
        if (!drinkMixActivated && !_TriviaController.triviaActivated)
        {
            DrinkNum = Drink;
            DMScreen.SetActive(true);
            QuitMixingButton.SetActive(true);
            ButtonBlocker.SetActive(false);

            drinkMixActivated = true;

            switch (Drink) {
                default:
                    {
                        SelectionSetA.SetActive(true);
                        DrinkWanted.text = "Impossible Drink, please";
                        Ingredients.text = "Nitroglycerin \n Potassium Chlorate";
                        IngrSelectNum = 1;
                        break;
                    }
                case 1:
                    {
                        SelectionSetA.SetActive(true);
                        DrinkWanted.text = "'One Rum and Coke Mix, please!'";
                        Ingredients.text = "Rum \n" + "Coke";
                        IngrSelectNum = 1;
                        break;
                    }
                case 2:
                    {
                        SelectionSetA.SetActive(true);
                        DrinkWanted.text = "'A Screw Driver, please!'";
                        Ingredients.text = "Vodka \n" + "Orange Juice";
                        IngrSelectNum = 1;
                        break;
                    }
                case 3:
                    {
                        SelectionSetB.SetActive(true);
                        DrinkWanted.text = "'One Mimosa, please!'";
                        Ingredients.text = "Orange Juice \n" + "Champange \n" + "Triple Sec";
                        IngrSelectNum = 4;
                        break;
                    }
                case 4:
                    {
                        SelectionSetB.SetActive(true);
                        DrinkWanted.text = "'Gin and Tonic, please!'";
                        Ingredients.text = "Gin \n" + "Tonic Water \n" + "Lime";
                        IngrSelectNum = 4;
                        break;
                    }

            }
        }
    }

    public void deactivateDrinkMix()
    {
        if (drinkMixActivated)
        { 
            DMScreen.SetActive(false);
            SelectionSetA.SetActive(false);
            SelectionSetB.SetActive(false);
            QuitMixingButton.SetActive(false);
            FinishedDrink.GetComponent<Image>().sprite = Blank;
            drinkMixActivated = false;
        }
    }

    public bool checkDrinkMixActivated()
    {
        return drinkMixActivated;
    }

    /*
        DrinkNum                                     IngredientNum
    1 = Rum & Coke   (Rum & Coke)                      1 - Coke
    2 = Screw Driver (Vodka -> OJ)                      2 - Vodka
    3 = Mimosa       (OJ -> Chmpg -> Trip.-Sec)         3 - Rum
    4 = Gin & Tonic  (Gin -> Tonic -> Lime)             4 - OJ
                                                        5 - Tonic
                                                        6 - Gin
                                                        7 - Triple Sec
                                                        8 - Lime
                                                        9 - Champange
    */

    public void GiveDrink()
    {
        switch (DrinkNum)
        {
            //Rum & Coke    (Rum[3] & Coke[1])
            case 1:
                {
                    if ((SelectionBoxA1.GetComponent<Ingredient>().IngredientNum == 3 && SelectionBoxA2.GetComponent<Ingredient>().IngredientNum == 1)
                        || (SelectionBoxA1.GetComponent<Ingredient>().IngredientNum == 1 && SelectionBoxA2.GetComponent<Ingredient>().IngredientNum == 3))
                    {
                        DrinkWanted.text = orderDrinkCorrect;
                        _GameController.points++;
                        FinishedDrink.GetComponent<Image>().sprite = RumCoke;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    } else
                    {
                        DrinkWanted.text = orderDrinkIncorrect;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }

                }
            //Screw Driver  (Vodka[2] -> OJ[4])
            case 2:
                {
                    if ((SelectionBoxA1.GetComponent<Ingredient>().IngredientNum == 2 && SelectionBoxA2.GetComponent<Ingredient>().IngredientNum == 4))
                    {
                        DrinkWanted.text = orderDrinkCorrect;
                        _GameController.points++;
                        FinishedDrink.GetComponent<Image>().sprite = ScrewDriver;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    } else
                    if ((SelectionBoxA1.GetComponent<Ingredient>().IngredientNum == 4 && SelectionBoxA2.GetComponent<Ingredient>().IngredientNum == 2))
                    {
                        DrinkWanted.text = orderDrinkWrongOrder;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }else
                    {
                        DrinkWanted.text = orderDrinkIncorrect;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                }
            //Mimosa        (OJ[4] -> Chmpg[9] -> Trip.-Sec[7])
            case 3:
                {
                    if ((SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 4 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 9 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 7))
                    {
                        DrinkWanted.text = orderDrinkCorrect;
                        _GameController.points++;
                        FinishedDrink.GetComponent<Image>().sprite = Mimosa;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                    else if((SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 4 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 7 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 9)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 9 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 4 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 7)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 9 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 7 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 4)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 7 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 4 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 9)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 7 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 9 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 4))
                    {
                        DrinkWanted.text = orderDrinkWrongOrder;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                    else
                    {
                        DrinkWanted.text = orderDrinkIncorrect;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                }
            //Gin & Tonic   (Gin[6] -> Tonic[5] -> Lime[8])
            case 4:
                {
                    if ((SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 6 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 5 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 8))
                    {
                        DrinkWanted.text = orderDrinkCorrect;
                        _GameController.points++;
                        FinishedDrink.GetComponent<Image>().sprite = GinTonic;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                    else if ((SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 6 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 8 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 5)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 5 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 6 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 8)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 5 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 8 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 6)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 8 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 6 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 5)
                        || (SelectionBoxB1.GetComponent<Ingredient>().IngredientNum == 8 && SelectionBoxB2.GetComponent<Ingredient>().IngredientNum == 5 && SelectionBoxB3.GetComponent<Ingredient>().IngredientNum == 6))
                    {
                        DrinkWanted.text = orderDrinkWrongOrder;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                    else
                    {
                        DrinkWanted.text = orderDrinkIncorrect;
                        StartCoroutine(WaitForRestart(3));
                        break;
                    }
                }
        }

    }

    void RunDrinkMix()
    {








    }


    IEnumerator WaitForRestart(int WaitTime)
    {
        ButtonBlocker.SetActive(true);
        yield return new WaitForSeconds(WaitTime);
        RemoveIngredient();
        deactivateDrinkMix();
    }
}
