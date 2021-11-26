using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveEngine : MonoBehaviour
{
    public void SaveGame(int score)
    {
        SaveData save = CreateSaveDataGameObject(score);

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

    public SaveData CreateSaveDataGameObject(int score)
    {
        SaveData save = new SaveData();
        GameObject player = GameObject.FindWithTag("Player");
        save.tickets = player.GetComponent<PlayerState>().AddTickets(score);  //TODO implement ticket calc
        Debug.Log("Saving Game: " + save);
        return save;
    }

    public void SetSavedGameFields(SaveData save)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerState>().localPlayerData.Tickets = save.tickets; //TODO Get player object and set the tickets

        Debug.Log("Loaded Game: " + save);
        Debug.Log("Got " + save.tickets + " tickets!");
    }


    [System.Serializable]
    public class SaveData
    {
        public int tickets = 0;
    }
    
}
