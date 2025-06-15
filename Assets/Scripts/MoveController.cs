using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed = 5f; // speed of horizontal movement

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal"); // get movement with arrows left/right
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y); // apply horizontal velocity

        //Flip sprite when direction changes
        if (move < 0) spriteRenderer.flipX = true;
        else if (move > 0) spriteRenderer.flipX = false;

        // Update animation
        bool isRunning = Mathf.Abs(move) > 0.01f;
        animator.SetBool("isRunning", isRunning);
    }
}
