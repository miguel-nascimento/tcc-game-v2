using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;

    int idChangeValue = 1;

    public List<Transform> points;

    public int nextID = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update(){
        
        MoveToNextPoint();
    }

    void MoveToNextPoint(){
        Transform goalPoint = points[nextID];
        
        if(goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,Speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, goalPoint.position)<1f)
        {
            if(nextID == points.Count - 1)
                idChangeValue = -1;
            
            if (nextID == 0)
                idChangeValue = 1;

            nextID += idChangeValue;

        }
         
    }
    // quando tirar o casco, aumentar a velocidade
}
