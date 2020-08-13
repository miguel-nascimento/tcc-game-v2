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

    // Start is called before the first frame update
    void Start()
    {
        phys = GetComponentInParent<PlayerPhysics>();
        anim = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        phys.UpdateCollisions();
        if (Input.GetButtonDown("Jump") && jumpCounter < 2){
            phys.Jump();
            jumpCounter++;
        }

        phys.Run(direction);
        anim.UpdateConditions();
        anim.FlipDirection();
    }
}
