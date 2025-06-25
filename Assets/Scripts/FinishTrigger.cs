using UnityEngine;
/*
attached to a FinishPost
detects collision with "Player" by tag
plays win sound
informs GameManager
*/
public class FinishTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // play winning sound
            if (audioSource != null) audioSource.Play();

            // Notify GameManager that gameWon
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null) gm.WinGame();
        }
    }
}
