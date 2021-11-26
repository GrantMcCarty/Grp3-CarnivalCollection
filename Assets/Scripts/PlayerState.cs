using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
        public PlayerStatistics localPlayerData = new PlayerStatistics();

        // public void SavePlayer()
        // {
        //     GlobalControl.Instance.savedPlayerData = localPlayerData;
        // }

        public int AddTickets(int amount) 
        { 
            localPlayerData.Tickets += amount;
        return localPlayerData.Tickets;
        }

}
