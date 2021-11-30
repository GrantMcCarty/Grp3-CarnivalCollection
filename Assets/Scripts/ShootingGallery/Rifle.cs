using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle:MonoBehaviour
{
    private Animator animator;
    public Transform barrelEnd;
    public GameObject bullet;
    public AudioSource audioSource;
    float readyToFire = 0f;
    public bool debug;
    public bool canFire;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if(!canFire) { return; }
        if(Input.GetMouseButton(0) && readyToFire <= 0f) {
            PerformAttack();
            readyToFire = 0.8f;
        } else {
            readyToFire -= 1*Time.deltaTime;
        }
    }

    void FireProjectile() {
        GameObject projectileInstance = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = transform.up * 200;
        Destroy(projectileInstance, 2f);
    }

    public void PerformAttack()
    {
        // animator.SetTrigger("fire");
        FireProjectile();
        audioSource.Play();
        // animator.SetTrigger("doneFiring");
    }
}
