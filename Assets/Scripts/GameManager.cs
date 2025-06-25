using UnityEngine;
using UnityEngine.Analytics;

/*
Parameters:
Receives GameState.cs struct
Receives UIManager reference

Sets up and manages: 
coinCount
lives
isGameOver
isGameWon

Methods
addCoin();
getScore();
updateLives();
endGame();
*/
public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    private GameState gameState;

    void Start()
    {
        // Initialize game state
        gameState = new GameState
        {
            coinCount = 0,
            lives = 3,
            gameWon = false,
            gameOver = false
        };

        // Initial UI update
        uiManager.UpdateUI(gameState);
    }

    // methods to manage coinCount
    public void addCoin()
    {
        gameState.coinCount++;
        uiManager.updateCoinUI(gameState.coinCount);
    }
    // public method to make current score available to final screens
    public int GetScore()
    {
        return gameState.coinCount;
    }

    // method to manage lives
    void updateLives()
    {
        gameState.lives--;

        if (gameState.lives > 0)
        {
            uiManager.updateLivesUI(gameState.lives);
        }
        else if (gameState.lives <= 0)
        {
            gameState.gameOver = true; 
            
        }
    }
    // method to end game
    void endGame()
    {
        
    }
}
