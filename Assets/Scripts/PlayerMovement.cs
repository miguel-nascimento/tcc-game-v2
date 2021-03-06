using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics phys;
    PlayerAnimation anim;
    PlayerAudioManager audioManager;
    public GameOver gameOver;
    public CinemachineVirtualCameraBase cam;
    public CinemachineVirtualCameraBase bossCam;

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

    GameObject bossObject;
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        phys = GetComponentInParent<PlayerPhysics>();
        anim = GetComponentInChildren<PlayerAnimation>();
        audioManager = GetComponentInChildren<PlayerAudioManager>();
        gameOver = GetComponent<GameOver>();
        healthBar.SetMaxHealth(health);
        bossObject = GameObject.FindGameObjectWithTag("Boss");
        boss = bossObject.GetComponent<Boss>();
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

        if (!bossObject.scene.IsValid())
        {
            SceneManager.LoadScene("Creditos");
        }
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

    public void Die()
    {
        Debug.Log("ooh, i died");
        cam.Follow = null;
        gameOver.GameOverEvent();
        // CINEMACHINE STOP FOLLOWING!
        Destroy(this);
        // TODO -> particle effects
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Boss Scene event collider")
        {
            Debug.Log("ok");
            boss.On();
            cam.gameObject.SetActive(false);
            bossCam.gameObject.SetActive(true);
            Destroy(GameObject.Find("Boss Scene event collider"));
        }
    }
}
