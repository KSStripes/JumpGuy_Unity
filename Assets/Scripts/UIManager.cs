using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
Parameters:
Receives GameState.cs struct
Receives coins, lives, gameWon & gameOver from GameManager

Methods
updateCoinUI();
updateLivesUI();
showGameWon();
showGameOver();
*/

public class UIManager : MonoBehaviour
{
    // Assign input params in inspector
    public TMP_Text coinText;
    public TMP_Text livesText;
   // public GameObject gameWonPanel;
    //public GameObject gameOverPanel;

    // Method to update UI according to gameState
    // Pass in global struct gameState
    public void UpdateUI(GameState gameState)
    {
        updateCoinUI(gameState.coinCount);
    }

    public void updateCoinUI(int coinCount)
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {coinCount}";
        }
    }


    public void updateLivesUI(int lives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
    }
    void showGameWon()
    {
        //do something
    }
    void showGameOver()
    {
        //do something
    }
}
