using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    bool flip;
    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 headingDirection;
    [SerializeField]
    float speed = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //TODO: Damage Player once health is implemented
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
        //Math magic from https://github.com/Tutorials-By-Kaupenjoe/Unity-Evergreen-Tutorials/blob/eg27-projectiles/Assets/Scripts/BoltProjectile.cs
        //Essentially get the angle of the current velocity in Radians and converts it to degrees to work with Quaterniun.Euler to ponit
        //the worm in the direction of its current velocity.

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }


}
