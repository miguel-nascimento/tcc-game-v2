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
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    public LayerMask groundLayer;
    public bool onRightWall, onLeftWall;

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
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        if (isGrounded) player.jumpCounter = 0;
    }
    public void UpdateWallColisions()
    {
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
        if (onRightWall || onLeftWall) player.jumpCounter = 0;
    }
}



