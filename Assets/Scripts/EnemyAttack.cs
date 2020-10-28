using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
     public float damage, attackRange;

     public LayerMask playerLayer;
     public Transform Hitbox;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(Hitbox.position, attackRange, playerLayer);
        foreach(Collider2D enemy in hitEnimies){
            enemy.GetComponent<PlayerMovement>().TakeDamage(damage);
            Debug.Log("hit " + enemy.name);
        
        }
    }
}
