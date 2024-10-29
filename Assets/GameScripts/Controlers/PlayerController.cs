using Assets.GameScripts.Views;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public Sprite jumpUpSprite;
    public Sprite jumpDownSprite;
    public Sprite jumpLandSprite;

    private bool isGrounded = true;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private HealthManager healthManager;
    private bool hasTakenDamage;
    public AudioClip collectSound;
    public AudioClip jumpSound;
    public AudioClip healthLossSound;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthManager = FindObjectOfType<HealthManager>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.enabled = false;
            spriteRenderer.sprite = jumpUpSprite;
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound);
        }

        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
                spriteRenderer.sprite = jumpUpSprite;
            else if (rb.velocity.y < 0)
                spriteRenderer.sprite = jumpDownSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("HealthLoss")) && !hasTakenDamage)
        {
            if (healthManager != null)
            {
                audioSource.PlayOneShot(healthLossSound);
                healthManager.TakeDamage(1);
                hasTakenDamage = true; // Prevent additional deductions from the same collision
                Debug.Log("Health deducted from collision with ice block.");
            }
        }

        if ((collision.CompareTag("Collectible")))
        {
            Debug.Log("play sound for collection?");
            audioSource.PlayOneShot(collectSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HealthLoss") )
        {
            hasTakenDamage = false; // Reset the flag when leaving the collision area
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            spriteRenderer.sprite = jumpLandSprite;
            StartCoroutine(ReEnableAnimatorAfterDelay(0.2f));
        }
    }

    private IEnumerator ReEnableAnimatorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.enabled = true;
    }
}
