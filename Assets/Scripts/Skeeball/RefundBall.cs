using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundBall : MonoBehaviour
{
    //Used to determine if the ball should automatically be refunded on trigger enter
    public bool autoRefund = false;

    //Ball is tagged with Respawn, if the ball has hit this component once to go up,
    //didnt make it up the ramp and is coming down, refund the ball.
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Respawn")) {
            GameObject ball = col.gameObject;
            if(ball.GetComponent<Ball>().crossedPlane || autoRefund) {
                Destroy(ball, 1);
                GameObject ballPlace = GameObject.FindWithTag("BallPlace");
                ballPlace.GetComponent<BallPlace>().ballsLeft++;
                ballPlace.GetComponent<BallPlace>().SetBallsLeftText();
            }
            ball.GetComponent<Ball>().crossedPlane = true;
        }
    }
}
