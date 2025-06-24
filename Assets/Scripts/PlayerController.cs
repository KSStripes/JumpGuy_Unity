using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jumping")]
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;

    [Header("Effects")]
    public ParticleSystem smokeFX;
    public AudioClip jumpSound;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimations();
    }

    private void HandleMovement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Flip sprite
        if (move < 0) spriteRenderer.flipX = true;
        else if (move > 0) spriteRenderer.flipX = false;

        // Play smoke effect when moving
        if (Mathf.Abs(move) > 0.01f && isGrounded && !smokeFX.isPlaying)
        {
            smokeFX.Play();
        }
    }

    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            smokeFX.Play(); //play smoke

            if (jumpSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void UpdateAnimations()
    {
        animator.SetBool("isRunning", Mathf.Abs(rb.velocity.x) > 0.01f);
        animator.SetBool("isGrounded", isGrounded);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
