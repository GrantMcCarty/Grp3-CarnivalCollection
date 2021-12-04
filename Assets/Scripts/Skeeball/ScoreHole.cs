using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHole : MonoBehaviour
{
    public int points;
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col) {
        col.gameObject.GetComponent<Ball>().hit = true;
        Destroy(col.gameObject, 2);
        BallPlace ballPlace = GameObject.FindWithTag("BallPlace").GetComponent<BallPlace>();
        ballPlace.SetScore(points);
        ballPlace.SetScoreText();
        audio.Play();
    }
}
