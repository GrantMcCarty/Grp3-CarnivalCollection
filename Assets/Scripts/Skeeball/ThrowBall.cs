using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject ball;
    GameObject startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0)) {
        //     Throw();
        // }
        
    }

    void Throw() {
        GameObject ballInstance = Instantiate(ball, startPos.transform.position, startPos.transform.rotation);
        ballInstance.GetComponent<Rigidbody>().velocity = startPos.transform.forward * Random.Range(25,45);
    }
}
