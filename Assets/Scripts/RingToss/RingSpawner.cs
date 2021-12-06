using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RingSpawner : MonoBehaviour
{
    public GameObject ringPrefab;
    
    Camera camera1;
    Camera camera2;
    int ringsRemaining;
    Vector3 position = new Vector3(-150, 25, -270);
    Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);

    bool createNew = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ringPrefab, position , rotation);
        //camera1 = Camera.main;
        //camera2 = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<Camera>();
        //camera2.enabled = false;
        //camera1.enabled = true;
        ringsRemaining = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (createNew)
        {
            if (ringsRemaining > 0)
            {
                Instantiate(ringPrefab, position, rotation);
                //ringsRemaining--;
                createNew = false;
            }
            else
            {
                //gameoverthing
            }
        }
    }

    /*void SpawnRing()
    {
        if (ringsRemaining > 0)
        {
            Instantiate(ringPrefab, position, rotation);
            //ringsRemaining--;
        }
        else
        {
            //gameoverthing
        }
    }*/

    public void SpawnRingAccessor()
    {
        createNew = true;
    }
}
