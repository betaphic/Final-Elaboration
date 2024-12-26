using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;
    public bool isGrounded;

    public Animator anim;
    public bool moving;

    public CoinManager coinManager;

    // Audio
    public AudioClip jumpSound;  // Drag and drop the jump sound effect in the Inspector
    private AudioSource audioSource;  // Audio source for playing sounds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Add an AudioSource if not already attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
            moving = true;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
            moving = true;
        }

        if (Input.GetKey("w") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("Jump");
            isGrounded = false;
            moving = false;

            // Play jump sound
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            moving = false;
        }

        transform.position = newPosition;
        transform.localScale = newScale;
        anim.SetBool("moving", moving);
        anim.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Merged OnCollisionExit2D method to handle both Ground and MovingPlatform logic
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        // Detach the player from the platform when they leave
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
        }
    }

    // Add this method for platform interaction
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // Move the player with the platform
            transform.parent = collision.transform;  // Attach the player to the platform
        }
    }
}
