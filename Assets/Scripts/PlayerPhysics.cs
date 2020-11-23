using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb2d;
    PlayerMovement player;
    PlayerAnimation anim;
    PlayerAudioManager audioManager;
    
    public float Speed;
    public float jumpForce;
    public bool isGrounded;
    private float collisionRadius = 0.02f;
    public LayerMask groundLayer, enemyLayer;
    public bool onWall;
    public Transform groundCheck, wallCheck, hitBox;

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        player = GetComponentInChildren<PlayerMovement>();
        anim = GetComponentInChildren<PlayerAnimation>();
        audioManager = GetComponentInChildren<PlayerAudioManager>();
    }

    public void Move(Vector2 direction)
    {
        rb2d.velocity = new Vector2(direction.x * Speed, rb2d.velocity.y);
    }

    // TODO -> Reimplement a better jumping system.
    public void Jump()
    {
        // rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb2d.velocity = Vector2.up * jumpForce;
        anim.isJumping = true;
        anim.CreateDust();
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
                    anim.isJumping = false;
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

    public void AttackCollider(){
        Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(hitBox.position, player.attackRange, enemyLayer);
        if (hitEnimies.Length == 0)
        {
            audioManager.playAirHit();
        } else {
            audioManager.playEnemyHit();
        }
        foreach(Collider2D enemy in hitEnimies){
            enemy.GetComponent<EnemyHealth>().TakeDamage(player.damage);
            enemy.GetComponent<Crystal>().TakeDamage(player.damage);
            Debug.Log("hit " + enemy.name);
        }
    }
}