using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool isGrounded;
    
    private LineRenderer belowLine;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        RaycastHit2D BelowDistance = Physics2D.Raycast(transform.position, Vector2.down, distance);
        belowLine.SetPosition(0, transform.position);
        if (!BelowDistance){
            Debug.DrawLine(transform.position, BelowDistance.point, Color.red);
            belowLine.SetPosition(1, BelowDistance.point);
        } else {
            Debug.DrawLine(transform.position, transform.position * distance, Color.green);
            belowLine.SetPosition(1, transform.position * distance);

        }

        belowLine.SetPosition(0, transform.position);

    }
}
