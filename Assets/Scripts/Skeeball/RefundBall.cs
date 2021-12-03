using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefundBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Respawn")) {
            GameObject ball = col.gameObject;
            if(ball.GetComponent<Ball>().crossedPlane) {
                Destroy(ball, 1);
                GameObject ballPlace = GameObject.FindWithTag("BallPlace");
                ballPlace.GetComponent<BallPlace>().ballsLeft++;
            }
            ball.GetComponent<Ball>().crossedPlane = true;
        }
    }
}
