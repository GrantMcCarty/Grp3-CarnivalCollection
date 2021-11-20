using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject normalTarget;
    public GameObject badTarget;
    public GameObject rareTarget;
    public bool flipped;
    float currentSpawn;
    void Start()
    {
        currentSpawn = calcCurrentSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpawn <= 0f) {
            spawnTarget();
            currentSpawn = calcCurrentSpawn();
        }
        else {
            currentSpawn -= 1 * Time.deltaTime;
        }
    }

    float calcCurrentSpawn() {
        return Random.Range(1, 5f);
    }

    void spawnTarget() {
        GameObject toSpawn;
        float targRng = Random.Range(0, 50f);
        if(targRng < 10f) {
            toSpawn = badTarget;
        } else if(targRng < 48f) {
            toSpawn = normalTarget;
        } else {
            toSpawn = rareTarget;
        }
        GameObject target = Instantiate(toSpawn, transform.position, Quaternion.identity);
        target.GetComponent<Target>().flipped = flipped;
    }
}
