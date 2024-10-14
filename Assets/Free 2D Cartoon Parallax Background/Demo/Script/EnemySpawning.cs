using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public GameObject Player;
    //interval is in seconds
    [SerializeField] private float interval = 5f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Instantiates an enemy every 5 seconds
        if (timer >= interval) 
        {
            timer = 0f;
            Instantiate(enemyPrefab1, Player.transform.position + new Vector3(25, 0, 0), new Quaternion(0, 180, 0, 0));
        }
    }
}