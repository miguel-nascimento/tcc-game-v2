using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public PlayerMovement player;
    public Transform bar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        bar = transform.Find("Bar");
    }

    void Update()
    {
        float NewHealth = player.Health/100; 
        Debug.Log("NewHealth = " + NewHealth);
        Debug.Log("PlayerHealth = " + player.Health);
        bar.localScale = new Vector3 (NewHealth,1f);
    }
}