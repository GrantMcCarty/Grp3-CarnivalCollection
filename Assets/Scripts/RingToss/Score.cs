using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    GameObject HUD; 
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        HUD = GameObject.FindWithTag("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        CalculateScore();
        HUD.GetComponentInChildren<Text>().text = "SCORE : " + score;
    }

    public void CalculateScore()
    {
        score = 0;
        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");
        for (int i = 0; i < rings.Length; i++)
        {
            score += 10*rings[i].GetComponentInChildren<ScoreTrigger>().Register();
        }
        Debug.Log(score);
    }
}
