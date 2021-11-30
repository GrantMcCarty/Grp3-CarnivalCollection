using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHole : MonoBehaviour
{
    public int points;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col) {
        Debug.Log("Collision! Got " + points + " points!");
        col.gameObject.GetComponent<Ball>().hit = true;
        Destroy(col.gameObject, 2);
    }
}
