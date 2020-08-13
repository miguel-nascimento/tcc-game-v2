using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    PlayerMovement player;
    public float Speed;
    public float wallJumpLerp;
    public float jumpForce;
    public bool isGrounded;
    public float collisionRadius = 0.02f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    public LayerMask groundLayer;
    public bool onWall;
    public Transform groundCheck, wallCheck;
    public bool isTouchingWall;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        player = GetComponentInChildren<PlayerMovement>();
    }

    public void Run(Vector2 direction)
    {
        rb2d.velocity = Vector2.Lerp(rb2d.velocity, (new Vector2(direction.x * Speed, rb2d.velocity.y)), wallJumpLerp * Time.deltaTime);
    }

    // TODO -> Reimplement a better jumping system.
    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }

    public void UpdateCollisions(){
        UpdateGrounded();
        UpdateWallColisions();
    }

    public void UpdateGrounded()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, collisionRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded) //Acabou de pisar no chão
                {
                    player.jumpCounter = 0;
                }
            }
        }
    }

    public void UpdateWallColisions()
    {
        onWall = Physics2D.OverlapCircle(wallCheck.position, collisionRadius, groundLayer);
        if (onWall){
            player.jumpCounter = 0;
        }
    }
}