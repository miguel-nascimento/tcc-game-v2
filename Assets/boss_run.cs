using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb2d;
    Boss boss;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.GetComponent<Boss>();
        rb2d = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb2d.position.y);

        if (player.position.y >= -8.75 && (player.position.y <= -5.883))
        {
            Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, boss.speed * Time.fixedDeltaTime);
            if (player.position.x <=23.32 && (player.position.x >= 8.68))
            {
                rb2d.MovePosition(newPos);
                boss.dustPlay();
                boss.LookAtPlayer();
            }
            if (Vector2.Distance(player.position, rb2d.position) <= boss.attackRange)
            {
                animator.SetTrigger("Attack");
            }
        } else {
            animator.Play("Idle");
        }
        //else 
        //{
            // boss.MoveToNextPoint();
        // }
    }

    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     // boss.LookAtPlayer();
    //     Vector2 target = new Vector2(player.position.x, rb2d.position.y);

    //     if (player.position.y >= -8.75 && (player.position.y <= -7.38))
    //     {
    //         Vector2 newPos = Vector2.MoveTowards(rb2d.position, target, boss.speed * Time.fixedDeltaTime);
    //         rb2d.MovePosition(newPos);
    //         boss.dustPlay();
    //         boss.LookAtPlayer();
    //         if (Vector2.Distance(player.position, rb2d.position) <= boss.attackRange)
    //         {
    //             animator.SetTrigger("Attack");
    //         }
    //     } else {
    //         boss.MoveToNextPoint();
    //     }
    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
