using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage, attackRange;
    public LayerMask playerLayer;
    public Transform Hitbox;
    public float cooldownTimer = 1;
    private float nextAttackTimer = 0;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(Hitbox.position, attackRange, playerLayer);
        foreach(Collider2D enemy in hitEnimies){
            if(Time.time > nextAttackTimer){
                enemy.GetComponent<PlayerMovement>().TakeDamage(damage);
                Debug.Log("hit " + enemy.name);
                nextAttackTimer = Time.time + cooldownTimer;
            }
        }
    }
}
