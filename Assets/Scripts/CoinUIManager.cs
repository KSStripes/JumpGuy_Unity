using TMPro; 
using UnityEngine;

public class CoinUIManager : MonoBehaviour
{
    public static CoinUIManager Instance { get; private set;  } // public instance of coinCounter
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep across scenes
    }

    // Called from coin.cs to add a count to the UI counter
    public void AddCoin()
    {
        coinCount++; ;
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinText.text = "Coins: " + coinCount;
    }

    // public method to make current score available to final screens
    public int GetScore()
    {
        return coinCount;
    }
}
