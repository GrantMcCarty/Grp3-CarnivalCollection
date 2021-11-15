using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    PlayerStatistics localPlayerData = new PlayerStatistics();
    void Start()
    {
        localPlayerData = GlobalControl.Instance.savedPlayerData;
    }

    public void SavePlayer()
    {
        GlobalControl.Instance.savedPlayerData = localPlayerData;
    }
    
    void AddTickets(int amount){localPlayerData.Tickets += amount;}

}
