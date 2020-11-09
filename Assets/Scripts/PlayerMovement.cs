using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics phys;
    PlayerAnimation anim;

    public float x;
    public float y;
    public int jumpCounter;
    public int direction = 1;
    public float Health = 1;
    public float attackRange = 0.1f;

    public bool canAttack;

    public float damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        phys = GetComponentInParent<PlayerPhysics>();
        anim = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

   
        if (Input.GetKeyDown("space") && jumpCounter < 2) {
            phys.Jump();
            jumpCounter++;
        }

        if (Input.GetKeyDown(KeyCode.Z)){
            anim.AttackAnimation();
            phys.AttackCollider();
        }
        
        phys.UpdateCollisions();
        phys.Move(new Vector2(x, y));
        anim.UpdateConditions();
        anim.FlipDirection();
    }
    public void TakeDamage(float damageTaken){
        if (damageTaken >= Health){
            Die();
        }
        Health -= damageTaken;
    }

    private void Die(){
        Debug.Log("ooh, i died");
        Destroy(gameObject);
        // TODO -> particle effects

    }
    
}
