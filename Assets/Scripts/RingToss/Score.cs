using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateScore();
        //update ui here
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
