using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 initialPosition;
    private GameManager gameManager;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jumping")]
    public float jumpForce = 12f;
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.7f, 0.05f);
    public float groundCheckRadius = 1f;
    public LayerMask groundLayer; // check if touching ground



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
        initialPosition = transform.position; // Save starting position
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimations();
    }

    private void Move()
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

    private void Jump()
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
            Gizmos.DrawCube(groundCheck.position, groundCheckSize);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDies();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("KillZone"))
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        // Immediately return the player to start
        transform.position = initialPosition;

        // Optional: Reset velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        // Notify GameManager
        if (gameManager != null)
        {
            gameManager.UpdateLives();
        }
        else
        {
            Debug.LogWarning("GameManager not found!");
        }
    }
    
    
}
