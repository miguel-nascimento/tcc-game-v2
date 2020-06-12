using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    public float Speed;
    public float Force;

    



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementX();
        Jump();
        
    }

    void MovementX(){
        if (Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            animator.SetBool("Correndo", true);
            
            spriteRenderer.flipX= false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            animator.SetBool("Correndo", true);
            
            spriteRenderer.flipX= true;
        }
         else {
           
            animator.SetBool("Correndo", false);
        } 
    }
    

    void Jump(){
        //Caso o espaço ou W esteja apertada, muda a velocidade em Y, fazendo ele "subir"
        if (Input.GetKey("space")){
            rb2d.velocity = new Vector2(rb2d.velocity.x, Force);
            }
    }

}
