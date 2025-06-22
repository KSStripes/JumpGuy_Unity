using TMPro; 
using UnityEngine;

public class CoinUIManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

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
}
