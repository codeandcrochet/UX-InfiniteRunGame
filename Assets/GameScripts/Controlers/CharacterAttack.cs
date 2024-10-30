using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask attackableLayer;

    private RaycastHit2D[] hits;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    { 
            anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
            anim.SetTrigger("Attack");
        }
    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.tag == "Enemy")
            {
                Destroy(hits[i].collider.gameObject);
            }
        }
    }
}
