using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 5f;
    public bool flipped;
    public bool hit;

    public int points;
    GameObject pointCounter;
    Vector3 startPos;
    public AudioSource audioSource;

    void Start()
    {
        startPos = transform.position;
        audioSource = (transform.parent != null) ? transform.parent.GetComponent<AudioSource>() : GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if(flipped) {
            pos.x -= speed * Time.deltaTime;
        } else {
            pos.x += speed * Time.deltaTime;
        }
        if(hit) {
            Vector3 parentPos = Vector3.zero;
            if(transform.parent != null) {
                parentPos = transform.parent.position;
                Quaternion rot = transform.parent.rotation;
                if(rot.x <90) {
                    rot.x += 1*Time.deltaTime;
                    transform.parent.rotation = rot;
                }
            } 
            else {
                Quaternion rot = transform.rotation;
                if(rot.x <90) {
                    rot.x += 1*Time.deltaTime;
                    transform.rotation = rot;
                }
            }
            pos.y -= 0.55f*Time.deltaTime;
            pos.z += 1.55f*Time.deltaTime;
        }
        transform.position = pos;
        if(Vector3.Distance(startPos, transform.position) > 15) {
            Destroy(this.gameObject);
        }
    }
    public void ProcessHit() {
        GameObject.FindWithTag("GameController").GetComponent<ManageGame>().scoreNum += points;
        hit = true;
        audioSource.Play();
        if(transform.parent != null) {
            Destroy(transform.parent.gameObject, 1);
        } else {
            Destroy(this.gameObject, 1);
        }
    }
}
