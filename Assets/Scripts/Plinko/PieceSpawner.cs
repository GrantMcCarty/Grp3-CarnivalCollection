using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject prefabPiece;

    Vector3 position;
    public Camera c;

    private GameObject hud;
    private ScoreTracker scoreTrackerScript;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        scoreTrackerScript = hud.GetComponent<ScoreTracker>();
    }

    private void OnGUI()
    {
        Event m_Event = Event.current;


        if (m_Event.type == EventType.MouseDown)
        {
            if (scoreTrackerScript.PiecesLeft > 0)
            {
                Ray ray = c.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(prefabPiece, hit.point, Quaternion.Euler(90, 0, 0));
                    scoreTrackerScript.DecPiecesLeft();
                }

                scoreTrackerScript.CheckStatus();
            }
            else
            {
                Debug.Log("No pieces remaining");
            }

        }

    }

}
