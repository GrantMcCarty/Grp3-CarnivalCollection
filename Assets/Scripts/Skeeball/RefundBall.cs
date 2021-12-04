using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundBall : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Respawn")) {
            GameObject ball = col.gameObject;
            if(ball.GetComponent<Ball>().crossedPlane) {
                Destroy(ball, 1);
                GameObject ballPlace = GameObject.FindWithTag("BallPlace");
                ballPlace.GetComponent<BallPlace>().ballsLeft++;
                ballPlace.GetComponent<BallPlace>().SetBallsLeftText();
            }
            ball.GetComponent<Ball>().crossedPlane = true;
        }
    }
}
