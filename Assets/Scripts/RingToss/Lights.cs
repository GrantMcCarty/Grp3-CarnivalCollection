using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    Light lightA;
    Light lightB;

    float timeOn = 2f;
    float timeOff = .3f;

    private float change = 0;
    void Start()
    {
        lightA = GameObject.Find("Directional Light").GetComponent<Light>();
        lightB = GameObject.Find("Point Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > change)
        {
            lightA.enabled = !lightA.enabled;
            lightB.enabled = !lightB.enabled;
            if (lightA.enabled) change = change + timeOn;
            else change = change + timeOff;
        }
    }
}
