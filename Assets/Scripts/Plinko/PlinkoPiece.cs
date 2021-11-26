using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoPiece : MonoBehaviour
{


    private GameObject hud;
    private ScoreTracker scoreTrackerScript;
    bool spawnable; 
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        scoreTrackerScript = hud.GetComponent<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Despawner")
        {
            Destroy(gameObject);
            scoreTrackerScript.IncPiecesLeft();
        }
        else if(other.gameObject.tag == "ZeroScore")
        {
            Debug.Log("Nothing Earned.");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "SmallScore")
        {
            Debug.Log("Small Score Hit");
            scoreTrackerScript.IncScore(30);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "MediumScore")
        {
            Debug.Log("Medium Score Hit");
            scoreTrackerScript.IncScore(50);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "LargeScore")
        {
            Debug.Log("Large Score Hit");
            scoreTrackerScript.IncScore(70);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "JackPot")
        {
            Debug.Log("JackPot Hit");
            scoreTrackerScript.IncScore(100);
            Destroy(gameObject);
        }
    }
}
