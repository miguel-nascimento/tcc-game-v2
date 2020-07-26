using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float Speed;

     Animator anim;
    public float jumpForce;
    public float wallJumpLerp;

    public float fallMultiplier = 2.5f;
    
    public float lowJumpMulplier = 2f;

    private Vector2 velocity;

    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool isRunning ;
    public bool isMoving ;
    public bool isGrounded;

    bool isMovingInHorizontal;
    bool isMovingInVertical;
    bool isRunning;
    bool isWithHood;
 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);

        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        
        if (x == 0) 
        {
            isMovingInHorizontal = false;
            anim.SetBool("isMovingInHorizontal", isMovingInHorizontal);
        } else {
            isMovingInHorizontal = true;
            anim.SetBool("isMovingInHorizontal", isMovingInHorizontal);
        }

        if (y == 0) 
        {
            isMovingInVertical = false;
            anim.SetBool("isMovingInVertical", isMovingInVertical);
        } else {
            isMovingInVertical = true;
            anim.SetBool("isMovingInVertical", isMovingInVertical);
        }

        if (x > 0.1 || x < -0.1)
        {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);
        } else {
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
        }


        if (x > 0) {
            spriteRenderer.flipX = false;
        } else if (x < 0) {
            spriteRenderer.flipX = true;
        }

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

        anim.SetFloat("HorizontalVelocity", x);
        anim.SetFloat("VerticalVelocity", y);
        anim.SetBool("isGrounded", isGrounded);
        Run(direction);
        Jump();
        // BetterJump();
    }

    // TODO: Fail in input checking
    // void BetterJump(){
    //     if(rb2d.velocity.y < 0){
    //         rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    //     }
    //     else if (rb2d.velocity.y > 0 ){
    //         rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMulplier - 1) * Time.deltaTime; 
    //     }
    // }

    void Jump(){
        //Caso o espaço ou W esteja apertada, muda a velocidade em Y, fazendo ele "subir"
        if (Input.GetKey("w") && isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private void Run(Vector2 direction)
    {
        rb2d.velocity = Vector2.Lerp(rb2d.velocity, (new Vector2(direction.x * Speed, rb2d.velocity.y)), wallJumpLerp * Time.deltaTime);
    }

}
