using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 25f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for jump input and char on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Debug.Log("attempt jump");
            // Adjust velocity with a vector of the jumpForce and the current velocity
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Check if char is back on ground, update boolean isGrounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Detect ground contact
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //Debug.Log("player is grounded");
            animator.SetBool("isGrounded", true);
        }
    }

    // Check if char is in air, update boolean isGrounded
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //Debug.Log("player is off ground");
            animator.SetBool("isGrounded", false);
        }
    }
}
