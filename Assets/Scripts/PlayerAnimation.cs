using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    SpriteRenderer spriteRenderer;
    PlayerMovement player;
    PlayerPhysics phys;
    public bool isRunning;
    public bool isMoving;
    public bool isMovingInHorizontal;
    public bool isMovingInVertical;
    public bool isWithHood;
    public bool isJumping;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        player = GetComponentInChildren<PlayerMovement>();
        phys = GetComponentInChildren<PlayerPhysics>();
    }

    public void UpdateConditions()
    {
        anim.SetFloat("xVel", phys.rb2d.velocity.x);
        anim.SetFloat("yVel", phys.rb2d.velocity.y);
        HorizontalUpdate();
        VerticalUpdate();
        HoodUpdate();
        JumpingUpdate();
        GroundUpdate();
        JumpCounterUpdate();
        onWallUpdate();
        isFallingUpdate();
    }

    public void FlipDirection()
    {
        if ((player.x > 0 && player.direction == -1) || (player.x < 0 && player.direction == 1))
        {
            player.direction *= -1;
            transform.Rotate(0f, 180f, 0);
        }
    }

    // TODO -> transfer isMovingInHorizontal bool to PlayerPhysics script.
    private void HorizontalUpdate()
    {
        if (player.x == 0) 
        {
            isMovingInHorizontal = false;
            anim.SetBool("isMovingInHorizontal", isMovingInHorizontal);
        } else {
            isMovingInHorizontal = true;
            anim.SetBool("isMovingInHorizontal", isMovingInHorizontal);
        }
    }

    // TODO -> transfer isMovingInVertical bool to PlayerPhysics script.
    private void VerticalUpdate()
    {
        if (player.y == 0) 
        {
            isMovingInVertical = false;
            anim.SetBool("isMovingInVertical", isMovingInVertical);
        } else {
            isMovingInVertical = true;
            anim.SetBool("isMovingInVertical", isMovingInVertical);
        }
    }

    // TODO -> transfer isJumping bool to PlayerPhysics script.
    private void JumpingUpdate()
    {
        anim.SetBool("isJumping", isJumping);
    }

    private void HoodUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("TirandoTouca"))
        {
            isWithHood = false;
            anim.SetBool("isWithHood", isWithHood);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("ColocandoTouca"))
        {
            isWithHood = true;
            anim.SetBool("isWithHood", isWithHood);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("JumpComTouca"))
        {
            isWithHood = false;
            anim.SetBool("isWithHood", isWithHood);
        }
    }

    private void GroundUpdate()
    {
        anim.SetBool("isGrounded", phys.isGrounded);
    }

    private void JumpCounterUpdate()
    {
        anim.SetInteger("JumpCounter", player.jumpCounter);
    }
    
    private void onWallUpdate(){
        anim.SetBool("onWall", phys.onWall);
    }

    private void isFallingUpdate(){
        if (phys.rb2d.velocity.y < 0){
            anim.SetBool("isFalling", true);
        } else {
            anim.SetBool("isFalling", false);
        }
    }
}