using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics phys;
    PlayerAnimation anim;
    PlayerAudioManager audioManager;
    public GameOver gameOver;
    public float x;
    public float y;
    public int jumpCounter;
    public int direction = 1;
    public float health = 100;
    public float attackRange = 0.1f;

    public float cooldownTimer;
    private float nextAttackTimer = 0;

    public float damage = 20;
    public GameObject respawnPoint;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        phys = GetComponentInParent<PlayerPhysics>();
        anim = GetComponentInChildren<PlayerAnimation>();
        audioManager = GetComponentInChildren<PlayerAudioManager>();
        gameOver = GetComponent<GameOver>();
        healthBar.SetMaxHealth(health);
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

    
        if (Input.GetKeyDown(KeyCode.Z) || (Input.GetKeyDown(KeyCode.J) || (Input.GetKeyDown(KeyCode.Mouse0))))
        {
            if(Time.time > nextAttackTimer)
            {
                anim.AttackAnimation();
                phys.AttackCollider();
                nextAttackTimer = Time.time + cooldownTimer;
            }
        }
            
        
        phys.UpdateCollisions();
        phys.Move(new Vector2(x, y));
        anim.UpdateConditions();
        anim.FlipDirection();
    }
    public void TakeDamage(float damageTaken)
    {
        if (damageTaken >= health){
            healthBar.SetHealth(0);
            Die();
        }
        health -= damageTaken;
        healthBar.SetHealth(health);
    }

    private void Die()
    {
        Debug.Log("ooh, i died");
        gameOver.GameOverEvent();
        // CINEMACHINE STOP FOLLOWING!
        Destroy(gameObject);
        // TODO -> particle effects
    }
}
