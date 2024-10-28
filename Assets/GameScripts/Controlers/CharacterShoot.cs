using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    [SerializeField] private float interval = 1f;
    private float timer = 0f;
    private bool isThrown = false;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        //Throws a snowball after interval time
        if (timer >= interval && isThrown == false)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            isThrown = true;
        }
    }
}
