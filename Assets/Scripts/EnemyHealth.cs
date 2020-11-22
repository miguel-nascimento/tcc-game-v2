using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;        
    }

    public void TakeDamage(float damageTaken){
        if (damageTaken >= currentHealth){
            Die();
        }
        currentHealth -= damageTaken;
    }

    private void Die(){
        Debug.Log("ooh, enemy died");
        Destroy(gameObject);
        // TODO -> particle effects
    }
}
