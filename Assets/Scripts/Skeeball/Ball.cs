using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool hit = false;
    public bool crossedPlane = false;
    float waitTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(hit) {
            waitTime -= 1*Time.deltaTime;
        } 
        if (waitTime <= 0) {
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.left * 2;
        }
    }
}
