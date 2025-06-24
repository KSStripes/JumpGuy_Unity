using UnityEngine;
using TMPro;

public class GameWonUI : MonoBehaviour
{
    public TMP_Text scoreText;   

    // Show text and get score when script is set active by finishTrigger
    void OnEnable()
    {
        // Show whe activated
        scoreText.text = $"You won!";
    }
}
