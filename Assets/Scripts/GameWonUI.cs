using UnityEngine;
using TMPro;

public class GameWonUI : MonoBehaviour
{
    public TMP_Text scoreText;
    //private CoinUIManager coinCounter;

    // Show text and get score when script is set active by finishTrigger
    void OnEnable()
    {
        // coinCounter = CoinUIManager.Instance;

        // if (coinCounter == null)
        // {
        // Debug.LogError("CoinCounter instance not found.");
        // return;
        // }

        // int score = coinCounter.GetScore();
        // scoreText.text = $"Well Done!\nScore: {score}";

    }
}
