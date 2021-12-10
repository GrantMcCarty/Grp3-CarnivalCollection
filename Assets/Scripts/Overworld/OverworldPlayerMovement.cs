using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isStopped;
    Vector2 movement;
    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector2 preMove = new Vector2(animator.GetFloat("Horizontal"),animator.GetFloat("Vertical"));
        if(movement.magnitude <= 0.5f && preMove.magnitude >= 0.5f){
            Debug.Log(movement.x + ", " + movement.y + "\n" + preMove.x + ", " + preMove.y);
            animator.SetFloat("PreHorizontal", preMove.x);
            animator.SetFloat("PreVertical", preMove.y);
            animator.SetFloat("PreSpeed", preMove.magnitude);
        }

            
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed);
    }
    
}
