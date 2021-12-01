using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStartIcon : MonoBehaviour
{
    // Start is called before the first frame update
   public string GameName;
   private bool isTouching = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("COLLIDE");
        if(collision.gameObject.tag == "Player"){
            isTouching = true;
            //transform.position.x = 1.3f;
            SceneManager.LoadScene(GameName);
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            isTouching = false;
            //gameObject.transform.scale.x = 1f;
        }
    }
}
