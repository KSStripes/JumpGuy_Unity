using UnityEngine;
using UnityEngine.Video;

public class KillZone : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // play falling sound
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (audioSource != null)
            {
                audioSource.Play();
            }
            GameManager.Instance?.LoseLife();
        }
    }
}
