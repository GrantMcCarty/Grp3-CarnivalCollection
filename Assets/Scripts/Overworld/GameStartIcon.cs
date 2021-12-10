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
   Component[] icons;
   private GameManager gm;

   public int ticketsToUnlock;
   public GameObject instructions; 
   private bool isUnlocked;

   private bool isInstructions;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManager>();
        hud = GameObject.FindWithTag("HUD");
        textHandler = hud.GetComponent<TextHandler>();
        icons = GetComponentsInChildren<SpriteRenderer>();
        HideIcons();
        instructions.gameObject.SetActive(false);
        isInstructions = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching && Input.GetKeyDown("space") && isUnlocked){
            ShowInstuctions();  
        }
        else if(isTouching && Input.GetKeyDown("space") && !isUnlocked){
            Debug.Log("TRYING TO UNLOCK");
            UnlockGame();
            textHandler.showGameText(GameName, isUnlocked, ticketsToUnlock);

        }
        if(isTouching && isUnlocked && Input.GetKeyDown("f") && isInstructions)
        {
            SceneManager.LoadScene(GameName);
        }
        if(isTouching && isUnlocked && Input.GetKeyDown("escape") && isInstructions)
        {
            HideInstructions();
        }
        if(!isTouching && isInstructions){
            HideInstructions();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("COLLIDE");
        isUnlocked = gm.isGameUnlocked(GameName);
        if(collision.gameObject.tag == "Player"){
            ShowIcons();
            isTouching = true;
            textHandler.showGameText(GameName, isUnlocked, ticketsToUnlock);
            //SceneManager.LoadScene(GameName);
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            HideIcons();
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

    void ShowIcons(){
        foreach(SpriteRenderer icon in icons){
            if(icon.tag == "Icon"){
                icon.gameObject.SetActive(true);
            }
        }
    }

    void HideIcons(){
        foreach(SpriteRenderer icon in icons){
            if(icon.tag == "Icon"){
                icon.gameObject.SetActive(false);
            }
        }
    }
    void ShowInstuctions(){
        isInstructions = true;
        instructions.gameObject.SetActive(true);
    }
    void HideInstructions(){
    instructions.gameObject.SetActive(false);
    }
}
