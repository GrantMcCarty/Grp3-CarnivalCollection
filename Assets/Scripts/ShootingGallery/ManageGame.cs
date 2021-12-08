using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageGame : MonoBehaviour
{
    public Text timeLeft;
    public Text score;
    public Text ticketAwardText;
    string timeLeftPrefix = "Time Left: ";
    string scorePrefix = "Score: ";
    float time;
    public int scoreNum;
    bool saved = false;

    void Start()
    {
        time = 60f;
        timeLeft.text = timeLeftPrefix + time;
        scoreNum = 0;
    }

    void Update()
    {
        if(saved) { return; }
        if(time <= 0) {
            Debug.Log("Game has ended!");
            GameObject.FindWithTag("Player").GetComponent<FPSController>().canMove = false;
            GameObject.FindWithTag("Gun").GetComponent<Rifle>().canFire = false;
            int tickets = (int) Mathf.Ceil(scoreNum/100);
            ticketAwardText.text = "You got " + tickets + " tickets!";
            GameObject Save = GameObject.FindWithTag("Save");
            Save.GetComponent<SaveEngine>().SaveGame(scoreNum, tickets, GameName.ShootingGallery);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Invoke("BackToHub", 3f);
            saved = true;
        }  else {
            time -= 1* Time.deltaTime;
            timeLeft.text = timeLeftPrefix + time;
            score.text = scorePrefix + scoreNum;
        }
     }
     void BackToHub() {
        SceneManager.LoadScene("Overworld");
     }
}
