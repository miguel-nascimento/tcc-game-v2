using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float currentHealth;
    public ParticleSystem blood;

    Animator anim;

    void Start()
    {
        currentHealth = maxHealth;    
        anim = GetComponent<Animator>();  
    }

    public void TakeDamage(float damageTaken){
        if (damageTaken >= currentHealth){
            blood.Play();
            Die();
        }
        currentHealth -= damageTaken;

        anim.SetTrigger("IsDestroy");
        
        
        blood.Play();
    }

    private void Die(){
        Debug.Log("ooh, enemy died");
        Destroy(gameObject);
        // TODO -> particle effects
    }
}
