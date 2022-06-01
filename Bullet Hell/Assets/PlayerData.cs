using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public int credits;
    public int currentShip;

    public bool[] boughtShip;

    public PlayerData(gameController player)
    {
        credits = player.credits;
        currentShip = player.currentShip;
        boughtShip = player.boughtShips;
        
    }
}
