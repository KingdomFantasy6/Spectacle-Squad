using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour {

    public Transform girl;
    public float distanceToGirl = 5f;
    public Transform computer;
    public float distanceToComputer = 5f;
    public GameObject BookFacePost;
    public Image Notebook;
    public Image SpeechBubble;
    public Text Dialogue;
    string[] dialogue;
    int dialogueIndex = 0;
    //public Text notepad;
    public Text notepad_girl;
    public Text notepad_computer;
    bool talkedToGirl;
    bool seenComputer;
    [HideInInspector]
    public bool InConversation;
    bool ComputerON;
    public Text interact;
    bool interactShown;
    public GameObject newnoteadded;

    // The notepad and the social network post can be done via UI text

	void Start () {
        dialogueIndex = 0;
        dialogue = new string[12];
        dialogue[0] = "Player: Hey, how’s it going?";
        dialogue[1] = "Girl: I can’t believe he’s doing this again! ";
        dialogue[2] = "Player: Who? ";
        dialogue[3] = "Girl: Mr. Thompson! He gave me and the other girls penalties for being late again.";
        dialogue[4] = "Player: That doesn’t seem unreasonable. ";
        dialogue[5] = "Girl: You don’t get it! The boys are late all the time because of morning sports " +
            "practices, but he never says anything to them.";
        dialogue[6] = "Girl: But if the girls’ practice runs for too long he " +
            "marks us all as late! It’s not fair! ";
        dialogue[7] = "Player: Has anyone tried doing anything?";
        dialogue[8] = "Girl: We told our coaches but there’s not much they can do.";
        dialogue[9] = "Player: Hey, I’m actually writing an article about implicit bias in the school, " +
            "do you mind if I use this story? ";
        dialogue[10] = "Girl: If it helps me and the other girls stop getting tardy notices, sure.";
        dialogue[11] = "";
        interact.gameObject.SetActive(false);
        interactShown = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (interactShown)
        {
            interact.gameObject.SetActive(true);
        }
        else
        {
            interact.gameObject.SetActive(false);
        }

        if ((dialogueIndex == 0 && Vector3.Distance(transform.position, girl.position) <= distanceToGirl) 
            || (!BookFacePost.activeSelf && Vector3.Distance(transform.position, computer.position) <= distanceToComputer))
        {
            interactShown = true;
        }
        else
        {
            interactShown = false;
        }

        // Interaction with NPC and Object
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactShown = false;
            if (Vector3.Distance(transform.position, girl.position) <= distanceToGirl && dialogueIndex < 12)
            {
                DialogueFunction();
            }

            if (Vector3.Distance(transform.position, computer.position) <= distanceToComputer && !ComputerON)
            {
                BookFacePost.SetActive(true);
                ComputerON = true;
            }
        }
		
        // Notepad
        if (Input.GetKeyDown(KeyCode.Tab) && !InConversation)
        {
            if (Notebook.enabled)
            {
                Notebook.enabled = false;
                notepad_girl.enabled = false;
                notepad_computer.enabled = false;
            }
            else
            {
                Notebook.enabled = true;
                if (talkedToGirl) notepad_girl.enabled = true;
                if (seenComputer) notepad_computer.enabled = true;
            }
            
        }

        if (ComputerON && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!seenComputer)
            {
                StartCoroutine(newnoteblip(4));
                seenComputer = true;
            }
            ComputerON = false;
            BookFacePost.SetActive(false);
        }


	}


    void DialogueFunction()
    {
        if (dialogueIndex <= 11)
        {
            InConversation = true;
            SpeechBubble.enabled = true;
            Notebook.enabled = false;
            notepad_girl.enabled = false;
            notepad_computer.enabled = false;
            Dialogue.text = dialogue[dialogueIndex];
            dialogueIndex = dialogueIndex + 1;


        }
        if (dialogueIndex == 12)
        {
            InConversation = false;
            talkedToGirl = true;
            SpeechBubble.enabled = false;
            Dialogue.text = "";
            dialogueIndex = 0;
            StartCoroutine(newnoteblip(4));
        }

    }

    IEnumerator newnoteblip(float waittime)
    {
        newnoteadded.transform.Translate(0, 125, 0);
        yield return new WaitForSeconds(waittime);
        newnoteadded.transform.Translate(0, -125, 0);
    }

}
