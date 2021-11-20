using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    static int totalPoints = 0;
    public float speed = 5f;
    public bool flipped;

    public int points;
    GameObject pointCounter;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(flipped) {
            pos.x -= speed * Time.deltaTime;
        } else {
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
        if(Vector3.Distance(startPos, transform.position) > 15) {
            Destroy(this.gameObject);
        }
    }
    public void ProcessHit() {
        totalPoints += points;
        Debug.Log("Current Points: " + totalPoints);
        if(transform.parent != null) {
            Destroy(transform.parent.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
