using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 0; // Tracks number of coins collected

    // increment a coin count, which will be referenced in coin.cs, when item is picked up
    public void IncCoinCount()
    {
        coinCount++;
        Debug.Log("Collected Coins: " + coinCount);
    }
}
