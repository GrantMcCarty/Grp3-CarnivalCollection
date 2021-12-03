using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Respawn")) {
            Destroy(col.gameObject, 2);
        }
    }
}
