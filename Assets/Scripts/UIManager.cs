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
    public GameObject gameWonPanel;
    public GameObject gameOverPanel;

    // Method to update UI according to gameState
    // Pass in global struct gameState
    public void UpdateUI(GameState gameState)
    {
        UpdateCoinUI(gameState.coinCount);
        UpdateLivesUI(gameState.lives);
        if (gameState.gameWon) ShowGameWon(gameState);
        if (gameState.gameOver) ShowGameOver();
    }

    public void UpdateCoinUI(int coinCount)
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {coinCount}";
        }
    }


    public void UpdateLivesUI(int lives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
    }
    public void ShowGameWon(GameState gameState)
    {
        if (gameWonPanel != null && !gameWonPanel.activeSelf)
        {
            gameWonPanel.SetActive(true);
            TMP_Text winText = gameWonPanel.GetComponentInChildren<TMP_Text>();
            if (winText != null)
            {
                winText.text = $"You Won! Final Score {gameState.coinCount}!";
            }

        }
    }
    public void ShowGameOver()
    {
        if (gameOverPanel != null && !gameOverPanel.activeSelf)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
