using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour {

    public Transform girl;
    public float distanceToGirl = 5f;
    public Transform computer;
    public float distanceToComputer = 5f;

    string[] dialogue;
    int dialogueIndex;
    public Text notepad;
    public Text notepad_girl;
    public Text notepad_computer;
    bool talkedToGirl;
    bool seenComputer;
    public Text computerPost;

    // The notepad and the social network post can be done via UI text

	void Start () {
        dialogueIndex = 0;
        dialogue = new string[10];
        dialogue[0] = "Player: Hey, how’s it going?";
        dialogue[1] = "Girl: I can’t believe he’s doing this again! ";
        dialogue[2] = "Player: Who? ";
        dialogue[3] = "Girl: Mr. Thompson! He gave me and the other girls penalties for being late again.";
        dialogue[4] = "Player: That doesn’t seem unreasonable. ";
        dialogue[5] = "Girl: You don’t get it! The boys are late all the time because of morning sports " +
            "practices, but he never says anything to them. But if the girls’ practice runs for too long he " +
            "marks us all as late! It’s not fair! ";
        dialogue[6] = "Player: Has anyone tried doing anything?";
        dialogue[7] = " We told our coaches but there’s not much they can do.";
        dialogue[8] = "Player: Hey, I’m actually writing an article about implicit bias in the school, " +
            "do you mind if I use this story? "
        dialogue[9] = "Girl: If it helps me and the other girls stop getting tardy notices, sure.";

    }
	
	// Update is called once per frame
	void Update () {

        // Interaction with NPC and Object
        if (Input.GetKey(KeyCode.E))
        {
            if (Vector3.Distance(transform.position, girl.position) <= distanceToGirl)
            {

            }

            if (Vector3.Distance(transform.position, computer.position) <= distanceToComputer)
            {

            }
        }
		
        // Notepad
        if (Input.GetKey(KeyCode.Tab))
        {

        }

	}
}
