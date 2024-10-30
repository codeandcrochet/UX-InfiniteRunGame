using Assets.GameScripts.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float destroyTime = 3f;
    private HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();

        rb = GetComponent<Rigidbody2D>();  
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            healthManager.TakeDamage(1);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
