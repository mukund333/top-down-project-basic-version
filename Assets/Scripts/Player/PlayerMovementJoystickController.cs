using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJoystickController : MonoBehaviour
{
    //require components
    private Rigidbody2D rb2d;


    //movement physics
    public float moveSpeed = 15f;
    private Vector3 moveDirection;
    private float moveX = 0f;
    private float moveY = 0f;

    //movement input -joysctick
    public MovementJoystick joystickInput;
   

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        joystickInput = GameObject.Find("Movement Joystick").GetComponent<MovementJoystick>();
    }

    private void Update()
    {

        if (joystickInput.Horizontal == 0)
        {
            moveX = 0;
        }
        if (joystickInput.Vertical == 0)
        {
            moveY = 0;
        }


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
        //Debug.Log(moveDirection);

     
    }

    private void FixedUpdate()
    {
        rb2d.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }
}
