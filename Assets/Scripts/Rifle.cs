using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle:MonoBehaviour
{
    private Animator animator;
    public Transform barrelEnd;
    public GameObject bullet;
    public int range;
    float readyToFire = 0f;
    public bool debug;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(Input.GetMouseButton(0) && readyToFire <= 0f) {
            PerformAttack();
            readyToFire = 1f;
        } else {
            readyToFire -= 1*Time.deltaTime;
        }

    }

    void FireProjectile() {
        GameObject projectileInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = transform.up * 100;
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
        {
            GameObject thing = hit.collider.gameObject;
            if(debug) {
                GameObject player = GameObject.FindWithTag("Player");
                player.GetComponent<FPSController>().canMove = false;
                Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.up));  
                Debug.DrawRay(ray.origin, ray.direction * 15, Color.yellow, 60, false);
                Time.timeScale = 0;
            } else {
                if(thing.CompareTag("Target"))
                {
                    thing.GetComponent<Target>().ProcessHit();
                }
            }
        }
        Destroy(projectileInstance, 2f);
    }

    public void PerformAttack()
    {
        // animator.SetTrigger("fire");
        FireProjectile();
        // animator.SetTrigger("doneFiring");
    }
}
