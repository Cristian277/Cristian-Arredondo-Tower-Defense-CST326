using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    int playerCoins = 0;

    public void increaseCoinCount()
    {
        playerCoins += 10;
        Debug.Log("Player has " + playerCoins + " coins.");
    }
}
