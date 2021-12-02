using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text bottomText;
    public Text ticketText;
    const string ticketTitle = "Tickets: ";
    GameManager gm; 
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    public void showGameText(string message, bool isUnlocked, int ticketsToUnlock){
        if(isUnlocked) bottomText.text = message + "\nHighscore: " + gm.Statistics.GetHighscore(message);
        else bottomText.text = message + "\nLOCKED: PRESS SPACE TO UNLOCK (" + ticketsToUnlock + ")";
        bottomText.gameObject.SetActive(true);
    }

    public void hideGameText(){
        bottomText.text = " ";
        bottomText.gameObject.SetActive(false);
    }
    public void showTickets(){
        ticketText.text = ticketTitle + gm.Statistics.Tickets;
    }
}
