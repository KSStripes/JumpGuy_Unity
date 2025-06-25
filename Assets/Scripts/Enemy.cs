using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // player to chase
    public float chaseSpeed = 2f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; 
    private bool isGrounded;
    private bool shouldJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Is Grounded ? 
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);

        // Player Direction?
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        // Flip sprite based on direction
        if (direction != 0)
        {
            spriteRenderer.flipX = direction > 0; // flip if moving left
        }

        // Player above detection
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);

        if (isGrounded)
        {
            // Chase player
            rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);

            // Jump if there's gap ahead and no ground in front
            // else if there's player above and platform above

            // If Ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);
            // If Gap
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);

            if (!groundInFront.collider && !gapAhead.collider)
            {
                shouldJump = true;
            }
        }
    }

    // get player to jump
    private void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 direction = (player.position - transform.position).normalized;

            Vector2 jumpDirection = direction * jumpForce;

            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }
}
