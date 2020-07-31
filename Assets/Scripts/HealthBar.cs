using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3 (-0.9f,1f);
    }

    public void Setsize (float sizeNormalized)
    {
        bar.localScale =  new Vector3 (sizeNormalized, 1f);
    }
}