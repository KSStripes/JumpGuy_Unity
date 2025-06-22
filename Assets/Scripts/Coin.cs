using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource;
    private bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //at start get sound
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

            // Notify coinUI Manager
            CoinUIManager ui = FindObjectOfType<CoinUIManager>();
            if (ui != null) ui.AddCoin();

            // Hide coin visuals
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Delay destruction to allow sound to finish
            Destroy(gameObject, 0.3f);
        }
    }
}
