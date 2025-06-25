using UnityEngine;

/// Summary: Manages core game state: coins, lives, win/lose conditions.
public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    private GameState gameState;
    private AudioSource audioSource;

    void Start()
    {
        gameState = new GameState
        {
            coinCount = 0,
            lives = 3,
            gameWon = false,
            gameOver = false
        };

        audioSource = GetComponent<AudioSource>();
        uiManager.UpdateUI(gameState);
    }

    public void AddCoin()
    {
        gameState.coinCount++;
        uiManager.UpdateCoinUI(gameState.coinCount);
    }

    public int GetScore() => gameState.coinCount;

    public void UpdateLives()
    {
        gameState.lives--;

        if (gameState.lives > 0)
        {
            uiManager.UpdateLivesUI(gameState.lives);
        }
        else
        {
            gameState.gameOver = true;
            LoseGame();
        }
    }

    public void LoseGame()
    {
        HandleGameEnd(gameOver: true, gameWon: false);
    }

    public void WinGame()
    {
        HandleGameEnd(gameOver: false, gameWon: true);
    }

    private void HandleGameEnd(bool gameOver, bool gameWon)
    {
        gameState.gameOver = gameOver;
        gameState.gameWon = gameWon;

        uiManager.UpdateUI(gameState);

        // Play sound if available
        if (audioSource != null) audioSource.Play();

        // Freeze game
        Time.timeScale = 0f;

        // Disable player input
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = false;
            }
        }
    }
}
