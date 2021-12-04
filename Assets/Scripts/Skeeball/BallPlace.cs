using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallPlace : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float currentRotation = 0f;
    public GameObject ball;

    public int ballsLeft = 9;

    int score = 0;

    public int speedCap = 30;

    Vector3 startPos;
    Quaternion startRot;

    public Text scoreText;
    string scoreTextPrefix = "Score: ";
    public Text ballsLeftText;
    string ballsLeftTextPrefix = "Balls Left: ";
    public Text ticketAwardText;

    public Image power;

    AudioSource audio;
    bool saved = false;

    void Start() {
        startPos = transform.position;
        startRot = transform.rotation;
        power.fillMethod = Image.FillMethod.Vertical;
        SetScoreText();
        SetBallsLeftText();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(ballsLeft <= 0 && !GameObject.FindWithTag("Respawn")) {
            EndGame();
        }
        if(Input.GetMouseButton(0)) {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            currentSpeed += y * -3f;
            
            if(currentSpeed > speedCap) currentSpeed = speedCap;
            else if(currentSpeed == 0) currentSpeed = 1;
            power.fillAmount = currentSpeed / speedCap;

            currentRotation += x * -0.025f;
            if(currentRotation < -0.8f) currentRotation = -0.8f;
            else if(currentRotation > -0.5f) currentRotation = -0.5f;
            Quaternion rot = transform.rotation;
            rot.y = currentRotation;
            transform.rotation = rot;
        }
        else if(Input.GetMouseButtonUp(0) && currentSpeed > 0f) {
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
        GameObject ball = GetChildWithTag("Respawn");
        ball.transform.parent = null;
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().velocity = transform.forward * currentSpeed;
        audio.Play();
        InstantiateBall();
    }

    GameObject GetChildWithTag(string tag) {
        Transform t = this.gameObject.transform;
        foreach(Transform tr in t)
        {
                if(tr.tag == tag)
                {
                    return tr.gameObject;
                }
        }
        return null;
    }

    void InstantiateBall() {
        ballsLeft--;
        SetBallsLeftText();
        if(ballsLeft <= 0) return;
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

    void EndGame() {
        if(saved) { return; }
        int tickets = (int) Mathf.Ceil(score/10);
        ticketAwardText.text = "You got " + tickets + " tickets!";
        GameObject Save = GameObject.FindWithTag("Save");
        Save.GetComponent<SaveEngine>().SaveGame(score, tickets, GameName.Skeeball);
        Invoke("BackToHub", 3f);
        saved = true;
    }

    void BackToHub() {
        SceneManager.LoadScene("Overworld");
    }

    public void SetScore(int scoreIn) {
        this.score += scoreIn;
    }
    public void SetScoreText() {
        scoreText.text = scoreTextPrefix + score;
    }
    public void SetBallsLeftText() {
        ballsLeftText.text = ballsLeftTextPrefix + ballsLeft;
    }
}
