using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 0; // Tracks number of coins collected


    // called when this coin enters a trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // check for collectable tag
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject); // delete the coin from screen
            coinCount++; //increase coinCount by 1
            Debug.Log("Collected Coins: " + coinCount);
        }
    }
}
