using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class GameController : MonoBehaviour {

    // Point indicator
    public GameObject pointsIndicator;
    Text pointsText;
    public int points = 0;

    void Start () {
        InitializeGame();
	}
	
	
	void Update () {
        // update points every frame
        pointsText.text = "Points: " + points;

	}

    void InitializeGame()
    {
        // Initialize points indicator
        pointsIndicator.gameObject.SetActive(true);
        pointsText = pointsIndicator.transform.GetChild(0).GetComponent<Text>();
    }

}
