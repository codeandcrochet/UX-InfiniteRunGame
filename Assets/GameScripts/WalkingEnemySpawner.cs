using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;


public class WalkingEnemySpawner : MonoBehaviour
{
    //TODO: Fix alt snowmen prefabs & update SpawnEnemy method to spawn random enemies
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public float spawnYMin = -10f;
    public float spawnYMax = -5f;
    public float spawnInterval = 2f;
    public float enemySpeed = 2f;
    private IEnumerator coroutine;

    void Start()
    {
        StartCoroutine(spawnAfterTime());
    }

    public IEnumerator spawnAfterTime() //IEnumerator that calls SpawnEnemy() every 8-15 seconds
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f + Random.Range(8, 16));
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        // Get the right edge of the camera's view in world space
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 10f; // Change float to change x dimension spawn distance, temporary solution?

        // Determine a random Y position within the specified range
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        //Instantiate Walking Enemy
        GameObject walkingEnemy = Instantiate(enemyPrefab1, spawnPosition, Quaternion.Euler(0f, 180f, 0f));

        // Set the collectible's movement to the left at a constant speed
        Rigidbody2D rb = walkingEnemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * enemySpeed;
        }
    }
}
    
