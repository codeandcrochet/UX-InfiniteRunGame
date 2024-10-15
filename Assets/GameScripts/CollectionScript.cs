using UnityEngine;

public class Collectible : MonoBehaviour
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
        // Check if the collectible has moved past the left boundary
        if (transform.position.x < leftBound)
        {
            Debug.Log("Destroying object at position: " + transform.position.x); // Debug to confirm position check
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy collectible if collected by the player
        }
    }
}