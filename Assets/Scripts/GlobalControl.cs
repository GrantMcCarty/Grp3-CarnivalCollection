using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{ 
   public PlayerStatistics savedPlayerData = new PlayerStatistics();

    public static GlobalControl Instance;
    // Start is called before the first frame update
    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
}
