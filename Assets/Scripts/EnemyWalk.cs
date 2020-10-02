using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update(){
        if (isRight()){
            rb2d.velocity = new Vector2(-Speed, 0);
        } else {
            rb2d.velocity = new Vector2(Speed, 0);
        }
    }

    private bool isRight(){
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision){
        transform.localScale = new Vector2((Mathf.Sign(rb2d.velocity.x)), transform.localScale.y);
    }
    // quando tirar o casco, aumentar a velocidade
}
