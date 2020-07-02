using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimationScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private MovementScript move;
    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void SetHorizontalMovementToAnim(float x, float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
    }
}
