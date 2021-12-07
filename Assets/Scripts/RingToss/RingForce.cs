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
    GameObject guide;

    public AudioClip swoosh;
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
        guide = GameObject.FindGameObjectWithTag("Guide");
        guide.SetActive(true);

    }
    //Click and drag BACKWARDS to throw
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
                ring.isKinematic = false;
                Debug.Log("disabled");
                ring.AddForce(new Vector3(dirAdj, 20, force/8), ForceMode.Impulse);
                guide.SetActive(false);
                gameObject.GetComponent<AudioSource>().PlayOneShot(swoosh);
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
        guide.SetActive(true);
    }
}
