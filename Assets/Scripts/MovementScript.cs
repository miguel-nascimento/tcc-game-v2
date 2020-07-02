using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    AnimationScript anim;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public float Speed;
    public float Force;
    public float wallJumpLerp;

 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        
        Vector2 direction = new Vector2(x, y);
        Run(direction);
        anim.SetHorizontalMovementToAnim(x, y, rb2d.velocity.y);

        
    }

    void MovementX(){

    }
    
    

    void Jump(){
        //Caso o espaço ou W esteja apertada, muda a velocidade em Y, fazendo ele "subir"
        if (Input.GetKey("space")){
            rb2d.velocity = new Vector2(rb2d.velocity.x, Force);
        }
    }

    private void Run(Vector2 direction)
    {
        rb2d.velocity = Vector2.Lerp(rb2d.velocity, (new Vector2(direction.x * Speed, rb2d.velocity.y)), wallJumpLerp * Time.deltaTime);
    }

}
