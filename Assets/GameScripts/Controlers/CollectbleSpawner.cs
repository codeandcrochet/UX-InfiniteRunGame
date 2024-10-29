using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 2f;
    public float spawnYMin = -3f;
    public float spawnYMax = 3f;
    public float collectibleSpeed = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    private void SpawnCollectible()
    {
        // Get the right edge of the camera's view in world space
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f;

        // Determine a random Y position within the specified range
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instantiate the collectible at the calculated position
        GameObject collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);

        // Set the collectible's movement to the left at a constant speed
        Rigidbody2D rb = collectible.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * collectibleSpeed;
        }
    }
}