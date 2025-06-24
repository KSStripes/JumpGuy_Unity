using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Stats")]
    public int lives = 3;
    public int maxLives = 3;

    [Header("UI")]
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        else
        {
            // Reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        UpdateLivesUI();
    }

    public void ResetGame()
    {
        lives = maxLives;
        UpdateLivesUI();
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Load Game Over scene or show Game Over UI here
    }
}
