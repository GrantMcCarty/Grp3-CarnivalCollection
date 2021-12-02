using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreTracker : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI piecesLeftText;
    public TextMeshProUGUI endGame;

    public int piecesLeft;
    float score;

    const string scorePrefix = "Score: ";
    const string piecesLeftPrefix = "Pieces Left: ";
    const string endGameText = "Press Q To End The Game!";

    public int PiecesLeft
    {
        get { return piecesLeft; }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        ShowInfo();
    }

    /*
     * Method made incase tickets are used to increase amount of pieces
    */ 
    public void setPlinkoPieceAmount(int amount)
    {

        if (amount > piecesLeft)
        {
            piecesLeft = amount;
        }
        else
        {
            piecesLeft = 4;
        }
        //Sets default first. Will change if upgrades are added.
    }

    void ShowInfo()
    {
        scoreText.text = scorePrefix + score;
        piecesLeftText.text = piecesLeftPrefix + piecesLeft;
        
    }

    public void IncScore(int value)
    {
        score += value;
        ShowInfo();
    }

    public void DecPiecesLeft()
    {
        piecesLeft -= 1;
        ShowInfo();
    }

    public void IncPiecesLeft()
    {
        if (piecesLeft < 4)
        {
            Debug.Log("Before:" + piecesLeft);
            piecesLeft++;
            Debug.Log("After:" + piecesLeft);
        }
        ShowInfo();
    }

    public void CheckStatus()
    {
        if (piecesLeft <= 0)
        {
            Debug.Log("Game Should Be Done");
            endGame.text = endGameText;

        }

        if (Input.GetKeyDown("q"))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        GameObject Save = GameObject.FindGameObjectWithTag("Save");
        Save.GetComponent<SaveEngine>().SaveGame((int)score, (int) Mathf.Ceil(score / 8f), GameName.Plinko);
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }

    public void Update()
    {
        GameObject Save = GameObject.FindGameObjectWithTag("Save");
        CheckStatus();

        if (Input.GetKeyDown("l"))
        {
            Save.GetComponent<SaveEngine>().LoadSavedGame();
        }
    }

    public void PlaySound()
    {
        AudioSource test = GetComponent<AudioSource>();
        test.Play();
    }

}