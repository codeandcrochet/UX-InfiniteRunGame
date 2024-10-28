using UnityEngine;

public class IceBlockSpawner : MonoBehaviour
{
    public GameObject iceBlockPrefab;
    private float spawnIntervalMin = 5f;
    private float spawnIntervalMax = 7f;
    private float spawnYMin = -5f;
    private float spawnYMax = 0f;
    public float collectibleSpeed = 2f;
    public float horizontalOffsetRange = 1f;
    public float minSpacing = 1.5f; 


    void Start()
    {
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn()
    {
        float interval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke("SpawnIceBlock", interval);
    }

    void SpawnIceBlock()
    {
        Vector2 spawnPosition = default;
        bool positionIsValid = false;

        // Attempt to find a valid spawn position within minSpacing
        for (int i = 0; i < 10; i++) // Try up to 10 times to avoid an infinite loop
        {
            // Randomize X and Y spawn position
            float baseX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f;
            float spawnX = baseX + Random.Range(-horizontalOffsetRange, horizontalOffsetRange);
            float spawnY = Random.Range(spawnYMin, spawnYMax);
            spawnPosition = new Vector2(spawnX, spawnY);

            // Check for overlap within the minSpacing radius
            Collider2D hitCollider = Physics2D.OverlapCircle(spawnPosition, minSpacing);
            if (hitCollider == null)
            {
                positionIsValid = true;
                break;
            }
        }

        // Only spawn if we found a valid position
        if (positionIsValid)
        {
            GameObject collectible = Instantiate(iceBlockPrefab, spawnPosition, Quaternion.identity);

            // Set the movement to the left
            Rigidbody2D rb = collectible.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.left * collectibleSpeed;
            }
        }

        // Schedule the next spawn
        ScheduleNextSpawn();
    }

    void OnDrawGizmosSelected()
    {
        // Draws the minSpacing radius in the Editor to visualize the overlap check
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minSpacing);
    }
}
