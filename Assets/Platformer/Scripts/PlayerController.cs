using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float runMultiplier = 1.5f;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;

    // Add a reference to the GameManager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveVelocity = horizontalInput * moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? runMultiplier : 1f);

        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Check if the player is grounded
    void FixedUpdate()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.IsTouchingLayers(col, LayerMask.GetMask("Ground"));
    }

    // Handle interactions with blocks and spikes
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Brick") || other.CompareTag("Question"))
        {
            // Check if hitting from below
            if (IsHittingFromBelow(other))
            {
                // Destroy the brick or question block
                Destroy(other.gameObject);

                // Increment score
                GameManager.Instance.IncrementScore(100);
            }
        }
        else if (other.CompareTag("Spike"))
        {
            // Handle spike damage (e.g., reduce player health)
            Destroy(gameObject);
        }
        else if (other.CompareTag("Goal"))
        {
            // Handle reaching the goal (e.g., end the level)
            EndGame();
        }
    }
    
    bool IsHittingFromBelow(Collider2D otherCollider)
    {
        // Calculate the player's lower bounds
        float playerLowerBounds = col.bounds.min.y;

        // Check if the player is above the other object
        return playerLowerBounds > otherCollider.bounds.max.y;
    }

    void EndGame()
    {
        // Implement your end game logic here
        Debug.Log("Game Over!");
        // You might want to load a new scene or display a game over screen
    }
}