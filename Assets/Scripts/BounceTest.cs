using UnityEngine;

public class BounceTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HIT: " + collision.gameObject.name);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
}
