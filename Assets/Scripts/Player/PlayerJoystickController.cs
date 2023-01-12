using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    //movement input -joysctick
    public MovementJoystick joystickInput;

    //require components
    private Rigidbody2D rb2d;
    private Vector3 moveDirection;

    float moveX = 0f;
    float moveY = 0f;

    private void Awake()
    {

        joystickInput = GameObject.Find("Movement Joystick").GetComponent<MovementJoystick>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void HandleMovement()
    {
         moveX = 0f;
         moveY = 0f;

        if (joystickInput.Horizontal > 0)
        {
            moveX = +1f;

        }

        if (joystickInput.Horizontal < 0)
        {
            moveX = -1f;

        }

        if (joystickInput.Vertical > 0)
        {
            moveY = +1f;

        }

        if (joystickInput.Vertical < 0)
        {
            moveY = -1f;

        }

        moveDirection = new Vector3(moveX, moveY).normalized;

    }

    private void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = moveDirection * speed * Time.fixedDeltaTime;
    }

}
