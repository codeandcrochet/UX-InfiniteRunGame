using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float spawnInterval = 2f;
    public float spawnYMin = -3f;
    public float spawnYMax = 3f;
    public float spawnX = 10f; // Position to the right of the screen
    public float collectibleSpeed = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnCollectible", 1f, spawnInterval);
    }

    private void SpawnCollectible()
    {
        // Randomly determine the height of the collectible
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Create the collectible at the spawn position
        GameObject collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);

        // Set the collectible's movement to the left
        collectible.GetComponent<Rigidbody2D>().velocity = Vector2.left * collectibleSpeed;
    }
}