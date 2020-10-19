using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    public GameObject Player;
    public Transform bar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //Player = GetComponent<PlayerMovement>();
        bar = transform.Find("Bar");
        
    }



    void Update(){
        float NewHealth = Player.GetComponent<PlayerMovement>().Health/-100; 
        
        bar.localScale = new Vector3 (NewHealth,1f);

    }
    public void Setsize (float sizeNormalized)
    {
        bar.localScale =  new Vector3 (sizeNormalized, 1f);
    }
}
