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
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

   
        if (Input.GetKeyDown("space") && jumpCounter < 2) {
            phys.Jump();
            jumpCounter++;
        }
        phys.UpdateCollisions();
        phys.Move(x);
        anim.UpdateConditions();
        anim.FlipDirection();
    }
}
