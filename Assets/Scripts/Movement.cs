using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementX();
    }

    void MovementX(){
        if (Input.GetKey("d") || Input.GetKey("right")){
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left")){
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
        }
    }
}
