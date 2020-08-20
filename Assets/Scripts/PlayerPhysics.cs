using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    PlayerMovement player;
    public float Speed;
    public float jumpForce;
    public bool isGrounded;
    private float collisionRadius = 0.02f;
    public LayerMask groundLayer;
    public bool onWall;
    public Transform groundCheck, wallCheck;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        player = GetComponentInChildren<PlayerMovement>();
    }

    public void Move(float direction)
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += direction * Speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    // TODO -> Reimplement a better jumping system.
    public void Jump()
    {
        rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce), ForceMode2D.Impulse);
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