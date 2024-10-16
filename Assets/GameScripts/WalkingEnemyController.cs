using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float leftBound;

    private void Start()
    {
        // Calculate the left boundary based on the camera's position
        leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x - 1f; // Adjusted slightly off-screen
        Debug.Log("Left Bound set to: " + leftBound); // Debug statement to confirm the boundary value
    }

    private void Update()
    {
        // Check if the enemy has moved past the left boundary
        if (transform.position.x < leftBound)
        {
            Debug.Log("Destroying object at position: " + transform.position.x); // Debug to confirm position check
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject); // Destroy enemy if it collides with player
        }
    }
}
    
