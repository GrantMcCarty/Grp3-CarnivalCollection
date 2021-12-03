using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public int range;
    float readyToFire = 0f;
    public bool debug;

    void Update() {
        if(Input.GetMouseButton(0) && readyToFire <= 0f) {
            FireRay();
            readyToFire = 0.8f;
        } else {
            readyToFire -= 1*Time.deltaTime;
        }
    }

    void FireRay() {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            GameObject thing = hit.collider.gameObject;
            if(debug) {
                GameObject player = GameObject.FindWithTag("Player");
                player.GetComponent<FPSController>().canMove = false;
                Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));  
                Debug.DrawRay(ray.origin, ray.direction * 15, Color.yellow, 60, false);
                Time.timeScale = 0;
            } else {
                if(thing.CompareTag("Target"))
                {
                    thing.GetComponent<Target>().ProcessHit();
                }
            }
        }
    }
}
