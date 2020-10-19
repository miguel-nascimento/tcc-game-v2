using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float damege = 20;
    public float maxHealth = 80;
    private float currentHealth;
    void Start()
    {
        
        currentHealth = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken){
        if (damageTaken >= currentHealth){
            Die();
        }
        currentHealth -= damageTaken;
    }

    private void Die(){
        Debug.Log("ooh, i died");
        Destroy(gameObject);
        // TODO -> particle effects

    }


}
