using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RingSpawner : MonoBehaviour
{
    public GameObject ringPrefab;
    GameObject current;
    GameSystem gameSystem;
    int ringsRemaining;
    Vector3 position = new Vector3(-150, 25, -270);
    Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);

    bool createNew = false;
    // Start is called before the first frame update
    void Start()
    {
        current = Instantiate(ringPrefab, position , rotation);
        current.GetComponent<Rigidbody>().isKinematic = true;
        gameSystem = GameObject.FindWithTag("Manager").GetComponent<GameSystem>();
        Debug.Log(gameSystem);
        ringsRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (createNew)
        {
            if (ringsRemaining > 0)
            {
                Instantiate(ringPrefab, position, rotation);
                ringsRemaining--;
                createNew = false;
            }
            else
            {
                Debug.Log("ednig");
                gameSystem.EndGame();
                createNew = false;
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
