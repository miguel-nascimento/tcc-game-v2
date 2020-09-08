using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOneWay : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D effector2D;
    public float waitTime;
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        if (y < 0){
            if (waitTime <= 0){
                effector2D.rotationalOffset = 180f;
                waitTime = .5f;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
        if (y > 0){
            effector2D.rotationalOffset = 0;
        }  
    }
}