using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    PlayerPhysics phys;
    PlayerAnimation anim;

    private PlayerController controller;
    private Vector2 movement;
    public float x;
    public float y;
    public int jumpCounter;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        phys = GetComponentInParent<PlayerPhysics>();
        anim = GetComponentInChildren<PlayerAnimation>();
    }

    void Awake()
    {
        controller = new PlayerController();
    }
    void OnEnable()
    {
        controller.Enable();
    }

    void OnDisable()
    {
        controller.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = controller.Player.Movement.ReadValue<Vector2>();
        x = movement.x;
        y = movement.y;

        phys.UpdateCollisions();
        if (Input.GetButtonDown("Jump") && jumpCounter > 0){
            phys.Jump();
            jumpCounter--;
        }
    }
}
