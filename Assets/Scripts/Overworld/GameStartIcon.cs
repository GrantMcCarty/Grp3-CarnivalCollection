using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStartIcon : MonoBehaviour
{
    // Start is called before the first frame update
   public string GameName;
   private bool isTouching = false;
   private GameObject hud;
   private TextHandler textHandler;

   private GameManager gm;

   public int ticketsToUnlock;

   private bool isUnlocked;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManager>();
        hud = GameObject.FindWithTag("HUD");
        textHandler = hud.GetComponent<TextHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching && Input.GetKeyDown("space") && isUnlocked){
            SceneManager.LoadScene(GameName);
        }
        else if(isTouching && Input.GetKeyDown("space") && !isUnlocked){
            Debug.Log("TRYING TO UNLOCK");
            UnlockGame();
            textHandler.showGameText(GameName, isUnlocked, ticketsToUnlock);

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("COLLIDE");
        isUnlocked = gm.isGameUnlocked(GameName);
        if(collision.gameObject.tag == "Player"){
            isTouching = true;
            textHandler.showGameText(GameName, isUnlocked, ticketsToUnlock);
            //SceneManager.LoadScene(GameName);
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            
            isTouching = false;
            textHandler.hideGameText();
            //gameObject.transform.scale.x = 1f;
        }
    }

    void UnlockGame(){
        if (gm.Statistics.Tickets >= ticketsToUnlock){
            gm.buyGame(ticketsToUnlock, GameName);
            isUnlocked = true;
        }
    }
}
