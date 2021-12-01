using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlace : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            Vector3 ballPos = transform.position;
            ballPos.z = hit.point.z;
        }
        
        if(transform.position.z > 2.2) {
            Vector3 pos = transform.position;
            pos.z = 1.5f;
            transform.position = pos;
        } else if(transform.position.z < -0.6) {
            Vector3 pos = transform.position;
            pos.z = -0.6f;
            transform.position = pos;
        }
    }
}
