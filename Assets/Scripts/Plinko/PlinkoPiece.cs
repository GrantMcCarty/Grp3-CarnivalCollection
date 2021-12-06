using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoPiece : MonoBehaviour
{
    private GameObject hud;
    private ScoreTracker scoreTrackerScript;
    public AudioSource plinkoAudio;
    public AudioClip pegHitSound;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        scoreTrackerScript = hud.GetComponent<ScoreTracker>();
        plinkoAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Despawner")
        {
            scoreTrackerScript.IncPiecesLeft();
        }
        else if(other.gameObject.tag == "ZeroScore")
        {
            Debug.Log("Nothing Earned.");
        }
        else if (other.gameObject.tag == "SmallScore")
        {
            Debug.Log("Small Score Hit");
            scoreTrackerScript.IncScore(30);
            scoreTrackerScript.PlaySound();
        }
        else if(other.gameObject.tag == "MediumScore")
        {
            Debug.Log("Medium Score Hit");
            scoreTrackerScript.IncScore(50);
            scoreTrackerScript.PlaySound();
        }
        else if (other.gameObject.tag == "LargeScore")
        {
            Debug.Log("Large Score Hit");
            scoreTrackerScript.IncScore(70);
            scoreTrackerScript.PlaySound();
        }
        else if (other.gameObject.tag == "JackPot")
        {
            Debug.Log("JackPot Hit");
            scoreTrackerScript.IncScore(100);
            scoreTrackerScript.PlaySound();

        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Peg")
        {
            plinkoAudio.clip = pegHitSound;
            plinkoAudio.Play();
        }
    }
}
