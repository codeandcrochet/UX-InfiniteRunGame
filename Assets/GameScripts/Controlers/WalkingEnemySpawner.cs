using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.GameScripts.Models;


public class WalkingEnemySpawner : MonoBehaviour
{
    //TODO: Fix alt snowmen prefabs & update SpawnEnemy method to spawn random enemies
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    List<GameObject> prefabList = new List<GameObject>();
    public float enemySpeed = 2f;
    private int listSize;
    void Start()
    {
        if (GameVars.Difficulty == Difficulty.Hard) {
            prefabList.Add(enemyPrefab1);
            prefabList.Add(enemyPrefab2);
            prefabList.Add(enemyPrefab3);
            prefabList.Add(enemyPrefab4);
            prefabList.Add(enemyPrefab5);
            StartCoroutine(spawnAfterTime());
            listSize = 5;
        } else
        {
            prefabList.Add(enemyPrefab4);
            prefabList.Add(enemyPrefab5);
            listSize = 2;
        }
        
        StartCoroutine(spawnAfterTime());
    }

    public IEnumerator spawnAfterTime() //IEnumerator that calls SpawnEnemy() every 7-10 seconds
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f + Random.Range(7, 11));
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        int prefabIndex = Random.Range(0, listSize);
        // Get the right edge of the camera's view in world space
        float spawnX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + 1f; 
        Vector2 spawnPosition = new Vector2(spawnX, -5.9f);

        //Instantiate Walking Enemy
        GameObject walkingEnemy = Instantiate(prefabList[prefabIndex], spawnPosition, Quaternion.Euler(0f, 180f, 0f));

        // Set the collectible's movement to the left at a constant speed
        Rigidbody2D rb = walkingEnemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * enemySpeed;
        }
    }
}
    
