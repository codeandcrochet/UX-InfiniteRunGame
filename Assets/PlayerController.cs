using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.enabled = false; // Disable the Animator
            spriteRenderer.sprite = jumpUpSprite; // Set to jump up sprite
            isGrounded = false;
        }

        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
            {
                  spriteRenderer.sprite = jumpUpSprite; // Rising sprite
            }
            else if (rb.velocity.y < 0)
            {
                spriteRenderer.sprite = jumpDownSprite; // Falling sprite
            }
        }
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            spriteRenderer.sprite = jumpLandSprite; // Set landing sprite
            await Task.Run(() =>
            {
                Thread.Sleep(200);
            });
            animator.enabled = true;

        }
    }
}
