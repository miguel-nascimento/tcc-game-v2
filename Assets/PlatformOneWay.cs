using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOneWay : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D effector2D;
    public float waitTime;
    PlayerController controller;
    private float y;

    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
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
    void Update()
    {
        Vector2 Movement = controller.Player.Movement.ReadValue<Vector2>();
        y = Movement.y;
        if (y < 0){
            if (waitTime <= 0){
                effector2D.rotationalOffset = 180f;
                waitTime = .5f;
            } else {
                waitTime -= Time.deltaTime;
            }
        }
        controller.Player.Jump.performed += _ => effector2D.rotationalOffset = 0;
    }
}
