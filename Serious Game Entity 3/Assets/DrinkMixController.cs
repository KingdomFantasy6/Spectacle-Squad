using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    bool drinkMixActivated = false;

    string orderDrinkQuestion = "Hello, may I have a ";
    string orderDrinkCorrect = "Perfect, thank you!";
    string orderDrinkIncorrect = "This isn't what I ordered";

    
    void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void activateDrinkMix()
    {
        drinkMixActivated = true;
    }
    public void deactivateDrinkMix()
    {
        drinkMixActivated = false;
    }
    public bool checkDrinkMixActivated()
    {
        return drinkMixActivated;
    }
}
