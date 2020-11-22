using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float attackDamage;
    public bool isAngry;
    public LayerMask playerLayer;
    public Transform hitBox;
    public Transform player;
    public float attackRange;
    private float currentHealth;
    public bool isFlipped = false;
    public ParticleSystem dust_1;
    public ParticleSystem dust_2;

    public AudioSource attack1;
    public AudioSource attack2;
    public AudioSource attack3;
    public AudioSource growl;


    public void Attack() 
    {
        Collider2D colliderHit = Physics2D.OverlapCircle(hitBox.position, attackRange, playerLayer);

        if (colliderHit != null)
        {
            colliderHit.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
        }
    }

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
}
