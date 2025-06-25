using UnityEngine;
/*
attached to each coin
detects collision with "Player" by tag
sets collected to true
plays collected sound
informs GameManager to addCoin()
destroys coin
*/

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    private bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Trigger : when collected
    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return; // Prevent double collection

        if (other.CompareTag("Player"))
        {
            collected = true;

            // Play coin sound
            if (audioSource != null) audioSource.Play();

            // Notify GameManager to add coin
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null) gm.addCoin();

            // Hide coin visuals
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;

            // Delay destruction to allow sound to finish
            Destroy(gameObject, 0.3f);
        }
    }
}
