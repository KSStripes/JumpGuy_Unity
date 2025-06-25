using UnityEngine;
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
AddCoin();
GetScore();
UpdateLives();
WinGame();
LoseGame()
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
    public void AddCoin()
    {
        gameState.coinCount++;
        uiManager.UpdateCoinUI(gameState.coinCount);
    }
    // public method to make current score available to final screens
    public int GetScore()
    {
        return gameState.coinCount;
    }

    // method to manage lives
    public void UpdateLives()
    {
        gameState.lives--;

        if (gameState.lives > 0)
        {
            uiManager.UpdateLivesUI(gameState.lives);
        }
        else if (gameState.lives <= 0)
        {
            gameState.gameOver = true;
            LoseGame();

        }
    }
    // method to end game
    public void LoseGame()
    {
        gameState.gameOver = true;
        uiManager.ShowGameOver();
    }

    public void WinGame()
    {
        gameState.gameWon = true;
        uiManager.UpdateUI(gameState);
        Time.timeScale = 0f; // freeze game

        // Disable player input
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerController controller = player.GetComponent<PlayerController>(); // Replace with your actual script name
            if (controller != null)
            {
                controller.enabled = false;
            }
        }
    }


}
