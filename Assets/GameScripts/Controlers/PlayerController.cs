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
    private bool hasTakenDamage = false; // Flag to track if damage has been taken

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.enabled = false;
            spriteRenderer.sprite = jumpUpSprite;
            isGrounded = false;
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
                healthManager.TakeDamage(1);
                hasTakenDamage = true; // Prevent additional deductions from the same collision
                Debug.Log("Health deducted from collision with ice block.");
            }
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
