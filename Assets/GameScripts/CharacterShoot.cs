using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
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
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
