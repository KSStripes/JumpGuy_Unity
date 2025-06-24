using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject gameWonUI; // Inspector reference to gameWonUI

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioListener.pause = true;
            Time.timeScale = 0f; // freeze
            gameWonUI.SetActive(true); // make gameWonUI visible
        }
    }
}
