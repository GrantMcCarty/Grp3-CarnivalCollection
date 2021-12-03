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
            case "Plinko": return PlinkoHighScore;
            case "Skeeball": return SkeeballHighScore;
            case "RingToss": return RingTossHighScore;
            default: return 0;
        }
    }
}
