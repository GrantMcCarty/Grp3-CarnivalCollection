using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using ImpossibleOdds.MouseEvents;


public class RingForce : MonoBehaviour
{
    //[SerializeField]
    //private MouseEventMonitor monitor = null;

    //public GameObject hoop;
    Rigidbody ring;
    Vector3 start;
    Vector3 end;
    Camera camera1;
    Camera camera2;
    float force;
    float direction;
    bool launched = false;
    bool canSpawn = true;
    RingSpawner ringspawner;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        //if (ring == null) ring = GameObject.FindWithTag("Ring");
        ringspawner = GameObject.FindWithTag("Respawn").GetComponent<RingSpawner>();
        ring = GetComponent<Rigidbody>();
        //camera1 = Camera.main;
        //camera2 = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<Camera>();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
            Debug.Log("mousedown");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouseup");
            end = Input.mousePosition;
            force = end.y - start.y;
            //put in check for if too low
            direction = end.x - start.x;
            Debug.Log(force);
            if (force <= -26 && !launched)
            {
                force *= -1;
                direction *= -1;

                force = Mathf.Round(force / 100) * 100;
                direction = Mathf.Round(direction / 100) * 100;

                int dirAdj = 0;
                if (direction > 0) dirAdj = 10;
                if (direction < 0) dirAdj = -10;

                Debug.Log(force);
                ring.AddForce(new Vector3(dirAdj, 20, force/8), ForceMode.Impulse);
                //camera1.enabled = false;
                //camera2.enabled = true;
                launched = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground" ||collision.gameObject.tag == "Ring")
        {
            if (canSpawn)
            {
                StartCoroutine(Destory());
                canSpawn = false;
            }
        }
    }

    IEnumerator Destory()
    {
        yield return new WaitForSecondsRealtime(2);
        //Destroy(gameObject);
        //canSpawn = false;
        ringspawner.SpawnRingAccessor();
    }
}
