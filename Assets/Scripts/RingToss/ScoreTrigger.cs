using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    MeshCollider check;
    int collide;
    float timer = 0;
    float limit = 2; //change this!

    public Score score;
    Collision touching;
    // Start is called before the first frame update
    void Start()
    {
        //check = GetComponent<MeshCollider>();
        collide = 0;
    }

    // Update is called once per frame
    /**private void Update()
    {
        if (collide)
        {
            timer += Time.deltaTime;
            if (timer >= limit)
            {
                score.IncreaseScore();
            }
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Peg")
        {
            collide = 1;
        }
        else collide = 0;
    }

    public void Register()
    {

    }
}
