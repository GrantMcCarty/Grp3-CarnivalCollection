using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics
{
    public int Tickets;
    public int SkeeballHighScore;
    public int PlinkoHighScore;
    public int ShootingGalleryHighScore;
    public int RingTossHighScore;

    public bool UnlockedPlinko = false;

    public bool UnlockedSkeeball = false;
    public bool UnlockedRingToss = false;
    public int GetHighscore(string GameName){
        switch(GameName){
            case "ShootingGallery": return ShootingGalleryHighScore;
            break;
            case "Plinko": return PlinkoHighScore;
            break;
            case "Skeeball": return SkeeballHighScore;
            break; 
            case "RingToss": return RingTossHighScore;
            break;
            default: return 0;
            break;
        }
    }
}
