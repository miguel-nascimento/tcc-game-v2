using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackDamage;
    public LayerMask playerLayer;
    public Transform hitBox;
    public Transform player;
    public float attackRange;
    public bool isFlipped = false;
    public ParticleSystem dust_1;
    public ParticleSystem dust_2;

    public AudioSource attack1;
    public AudioSource attack2;
    public AudioSource attack3;
    public AudioSource growl;
    public AudioSource soundtrack;
    Animator animator;
    public float speed;
    float health;
    SoundController soundController;
    int idChangeValue = 1;
    public List<Transform> points;
    public int nextID = 0;

    public void Start()
    {
        animator = GetComponent<Animator>();
        GameObject soundObj = GameObject.FindGameObjectWithTag("SoundController");
        soundController = soundObj.GetComponent<SoundController>();
        float health = GetComponent<EnemyHealth>().currentHealth;
        growl.volume = 0.5f;
        soundtrack.volume = 0.6f;
    }
    public void Attack() 
    {
        Collider2D colliderHit = Physics2D.OverlapCircle(hitBox.position, attackRange, playerLayer);

        if (colliderHit != null)
        {
            colliderHit.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
        }
    }

    // public void Update()
    // {
    //     if (health <= 200)
    //     {
    //         growl.Play();
    //         speed = 2.7f;
    //         attackRange = 1.65f;
    //         Debug.Log("angry!");
    //     }
    //     Debug.Log(health);
    // }

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    public void dustPlay()
    {
        dust_1.Play();
        dust_2.Play();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(hitBox.position, attackRange);
    }

    public void playAttackSound()
    {
        int index = Random.Range(1,3);
        attack1.volume = Random.Range(0.1f, 0.3f);
        attack2.volume = Random.Range(0.1f, 0.3f);
        attack3.volume = Random.Range(0.1f, 0.3f);

        if (index == 1) 
        {
            attack1.Play();
        } 
        else if (index == 2)
        {
            attack2.Play();
        } 
        else 
        {
            attack3.Play();
        }
    }

    public void On()
    {
        Debug.Log("hello from boss!");
        soundController.StopBGM();
        growl.Play();
        soundtrack.Play();
        animator.SetTrigger("EventTrigger");
    }

    public void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        
        if(goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if(nextID == points.Count - 1)
                idChangeValue = -1;
            
            if (nextID == 0)
                idChangeValue = 1;

            nextID += idChangeValue;
        }
    }
}
