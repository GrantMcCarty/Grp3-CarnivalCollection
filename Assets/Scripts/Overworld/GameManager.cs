using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private PlayerStatistics statistics;
    public PlayerStatistics Statistics{get {return statistics;}}
    private GameObject hud;
     private TextHandler textHandler;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
        gameObject.GetComponent<SaveEngine>().LoadSavedGame();
        statistics = gameObject.GetComponent<PlayerState>().localPlayerData;
        hud = GameObject.FindWithTag("HUD");
        textHandler = hud.GetComponent<TextHandler>();
        textHandler.showTickets();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isGameUnlocked(string name){
        switch(name){
            case "ShootingGallery": return true;
            case "Plinko":
            Debug.Log(name); 
            Debug.Log(statistics.UnlockedPlinko);
            return statistics.UnlockedPlinko;
            case "Skeeball": return statistics.UnlockedSkeeball;
            case "RingToss": return statistics.UnlockedRingToss;
            default: return false;
        }
    }

    public void buyGame(int tickets, string name){
        tickets = tickets * -1;
        unlockGame(name);
        Debug.Log("BEFORE SAVE: " + statistics.UnlockedPlinko);
        bool[] lockedGames = new bool[] {statistics.UnlockedPlinko, statistics.UnlockedSkeeball, statistics.UnlockedRingToss};
        gameObject.GetComponent<SaveEngine>().SaveGame(0, tickets, GameName.Overworld, lockedGames);
        
    }

    private void unlockGame(string name){
        switch(name){

            case "Plinko": statistics.UnlockedPlinko = true;
            break;
            case "Skeeball": statistics.UnlockedSkeeball = true;
            break; 
            case "RingToss": statistics.UnlockedRingToss = true;
            break;
            default: break;
        }
    }
}
