﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    public float currentHealth;
    public ParticleSystem blood;

    void Start()
    {
        currentHealth = maxHealth;        
    }

    public void TakeDamage(float damageTaken){
        if (damageTaken >= currentHealth){
            blood.Play();
            Die();
        }
        currentHealth -= damageTaken;
        
        blood.Play();
    }

    private void Die(){
        Debug.Log("ooh, enemy died");
        // SceneManager.LoadScene("Creditos");
        Destroy(gameObject);
        // TODO -> particle effects
    }
}
