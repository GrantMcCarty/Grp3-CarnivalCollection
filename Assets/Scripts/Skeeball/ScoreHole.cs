using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHole : MonoBehaviour
{
    //points to be awarded onTriggerEnter
    public int points;

    //audio source to play a good/bad sound
    AudioSource scoreAudio;

    void Start() {
        scoreAudio = GetComponent<AudioSource>();
    }

    //On hit, destroy the object after two seconds, and update the score
    void OnTriggerEnter(Collider col) {
        col.gameObject.GetComponent<Ball>().hit = true;
        Destroy(col.gameObject, 2);
        BallPlace ballPlace = GameObject.FindWithTag("BallPlace").GetComponent<BallPlace>();
        ballPlace.SetScore(points);
        ballPlace.SetScoreText();
        scoreAudio.Play();
    }
}
