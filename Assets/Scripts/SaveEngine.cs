using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveEngine : MonoBehaviour
{
    PlayerStatistics stats;
    public void SaveGame(int score, int tickets, GameName gamePlayed)
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")) {
            LoadSavedGame();
        }
        SaveData save = CreateSaveDataGameObject(tickets);
        checkHighScore(score, save, gamePlayed);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    //For unlocking games IMPORTANT: lockedGames Goes in order 0:Plinko, 1:Skeeball, 2:RingToss
    public void SaveGame(int score, int tickets, GameName gamePlayed, bool[] lockedGames)
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")) {
            LoadSavedGame(lockedGames);
        }
        SaveData save = CreateSaveDataGameObject(tickets);
        checkHighScore(score, save, gamePlayed);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }
    

    public void LoadSavedGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveData save = (SaveData)bf.Deserialize(file);
            file.Close();

            SetSavedGameFields(save);
        }
    }

        public void LoadSavedGame(bool[] lockedGames)
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveData save = (SaveData)bf.Deserialize(file);
            file.Close();

            SetSavedGameFields(save, lockedGames);
        }
    }

    public SaveData CreateSaveDataGameObject(int tickets)
    {
        SaveData save = new SaveData();
        GameObject player = GameObject.FindWithTag("Player");
        save.tickets = player.GetComponent<PlayerState>().AddTickets(tickets);
        save.plinkoHighScore = player.GetComponent<PlayerState>().localPlayerData.PlinkoHighScore;
        save.ringTossHighScore = player.GetComponent<PlayerState>().localPlayerData.RingTossHighScore;
        save.skeeballHighScore = player.GetComponent<PlayerState>().localPlayerData.SkeeballHighScore;
        save.shootingGalleryHighScore = player.GetComponent<PlayerState>().localPlayerData.ShootingGalleryHighScore;
        save.UnlockedPlinko = player.GetComponent<PlayerState>().localPlayerData.UnlockedPlinko;
        save.UnlockedSkeeball = player.GetComponent<PlayerState>().localPlayerData.UnlockedSkeeball;
        save.UnlockedRingToss = player.GetComponent<PlayerState>().localPlayerData.UnlockedRingToss;
        return save;
    }

    public SaveData checkHighScore(int score, SaveData save, GameName gamePlayed) {
        if(save != null) {
            switch(gamePlayed) {
                case GameName.ShootingGallery : 
                    if(score > save.shootingGalleryHighScore) {  
                        save.shootingGalleryHighScore = score;
                    } break;
                case GameName.Plinko : 
                    if(score > save.plinkoHighScore){ 
                        save.plinkoHighScore = score;
                    } break;
                case GameName.RingToss : 
                    if(score > save.ringTossHighScore){ 
                        save.ringTossHighScore = score;
                    } break;
                case GameName.Skeeball : 
                    if(score > save.skeeballHighScore){ 
                        save.skeeballHighScore = score;
                    } break;
                default: break;
            }
        }
        return save;
    }

    public void SetSavedGameFields(SaveData save)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerState>().localPlayerData.Tickets = save.tickets;
        player.GetComponent<PlayerState>().localPlayerData.SkeeballHighScore = save.skeeballHighScore;
        player.GetComponent<PlayerState>().localPlayerData.RingTossHighScore = save.ringTossHighScore;
        player.GetComponent<PlayerState>().localPlayerData.ShootingGalleryHighScore = save.shootingGalleryHighScore;
        player.GetComponent<PlayerState>().localPlayerData.PlinkoHighScore = save.plinkoHighScore;
        player.GetComponent<PlayerState>().localPlayerData.UnlockedPlinko = save.UnlockedPlinko;
        player.GetComponent<PlayerState>().localPlayerData.UnlockedSkeeball = save.UnlockedSkeeball;
        player.GetComponent<PlayerState>().localPlayerData.UnlockedRingToss = save.UnlockedRingToss;
        stats = player.GetComponent<PlayerState>().localPlayerData;

        Debug.Log("Loaded Game"); 
        Debug.Log("Have " + stats.Tickets + " tickets!");
        Debug.Log("Shooting Gallery Highscore: " + stats.ShootingGalleryHighScore);
        Debug.Log("Plinko Highscore: " + stats.PlinkoHighScore);
        Debug.Log("Ring Toss Highscore: " + stats.RingTossHighScore);
        Debug.Log("Skeeball Highscore: " + stats.SkeeballHighScore);
    }
        public void SetSavedGameFields(SaveData save, bool[] lockedGames)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerState>().localPlayerData.Tickets = save.tickets;
        player.GetComponent<PlayerState>().localPlayerData.SkeeballHighScore = save.skeeballHighScore;
        player.GetComponent<PlayerState>().localPlayerData.RingTossHighScore = save.ringTossHighScore;
        player.GetComponent<PlayerState>().localPlayerData.ShootingGalleryHighScore = save.shootingGalleryHighScore;
        player.GetComponent<PlayerState>().localPlayerData.PlinkoHighScore = save.plinkoHighScore;
        player.GetComponent<PlayerState>().localPlayerData.UnlockedPlinko = lockedGames[0];
        player.GetComponent<PlayerState>().localPlayerData.UnlockedSkeeball = lockedGames[1];
        player.GetComponent<PlayerState>().localPlayerData.UnlockedRingToss = lockedGames[2];
        stats = player.GetComponent<PlayerState>().localPlayerData;

        Debug.Log("Loaded Game"); 
        Debug.Log("Have " + stats.Tickets + " tickets!");
        Debug.Log("Shooting Gallery Highscore: " + stats.ShootingGalleryHighScore);
        Debug.Log("Plinko Highscore: " + stats.PlinkoHighScore);
        Debug.Log("Ring Toss Highscore: " + stats.RingTossHighScore);
        Debug.Log("Skeeball Highscore: " + stats.SkeeballHighScore);
    }


    [System.Serializable]
    public class SaveData
    {
        public int tickets = 0;
        public int skeeballHighScore;
        public int shootingGalleryHighScore;
        public int ringTossHighScore;
        public int plinkoHighScore;
        public bool UnlockedPlinko;
        public bool UnlockedSkeeball;
        public bool UnlockedRingToss;
    }
    
}
