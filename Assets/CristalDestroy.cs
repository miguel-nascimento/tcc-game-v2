using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalDestroy : StateMachineBehaviour
{
    PlayerMovement Player;
    Transform player;
    Animator anim;
    Rigidbody2D rb2d;

    public Transform groundCheck, wallCheck, hitBox;

    public LayerMask groundLayer, enemyLayer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Player = player.GetComponent<PlayerMovement>();
        rb2d = animator.GetComponent<Rigidbody2D>();
        
    }

    
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider2D[] Destroy = Physics2D.OverlapCircleAll(hitBox.position, Player.attackRange, enemyLayer);

        if(Destroy.Length == 1){
            animator.ResetTrigger("IsDestroy");
        }
        else
        {

        }
    }
}
    
    

