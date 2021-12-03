using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlace : MonoBehaviour
{
    public float currentSpeed = 0f;
    public float currentRotation = 0f;
    public GameObject ball;

    public int ballsLeft = 9;

    public int speedCap = 30;

    Vector3 startPos;
    Quaternion startRot;

    void Start() {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        if(ballsLeft < 0) return;
        if(Input.GetMouseButton(0)) {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            currentSpeed += y * -3f;
            if(currentSpeed > speedCap) currentSpeed = speedCap;
            currentRotation += x * -0.025f;
            if(currentRotation > 0.2f) currentRotation = 0.2f;
            else if(currentRotation < -0.2f) currentRotation = -0.2f;
        }
        else if(Input.GetMouseButtonUp(0) && currentSpeed > 0f) {
            Debug.Log("THROW");
            if(currentSpeed < 5) currentSpeed = 5;
            ThrowBall(currentSpeed, currentRotation);
        }
       else { 
            float x = Input.GetAxis("Mouse X");
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + x);
            if(transform.position.z > 2.4) {
              Vector3 newpos = transform.position;
              newpos.z = 2.4f;
              transform.position = newpos;
            } else if(transform.position.z < -0.8) {
              Vector3 newpos = transform.position;
              newpos.z = -0.8f;
              transform.position = newpos;
            }
       }
    }

    void ThrowBall(float currentSpeed, float currentRotation) {
        Quaternion rot = transform.rotation;
        Debug.Log("Had rotation " + rot.y);
        rot.y += currentRotation;
        Debug.Log("Current rotation " + rot.y);
        transform.rotation = rot;

        GameObject ball = this.gameObject.transform.GetChild(0).gameObject;
        ball.transform.parent = null;
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().velocity = transform.forward * currentSpeed;
        InstantiateBall();
    }

    void InstantiateBall() {
        ballsLeft--;
        StartCoroutine(WaitForBall());
    }

    IEnumerator WaitForBall()
    {
        yield return new WaitForSeconds(1);
        ResetBall();
    }

    void ResetBall() {
        currentSpeed = 0f;
        currentRotation = 0f;
        transform.position = startPos;
        transform.rotation = startRot;
        GameObject ballInstance = Instantiate(ball, transform.position, transform.rotation);
        ballInstance.transform.parent = transform;
    }
}
