using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour
{
    private Vector3 inputDirection;

    public Vector3 InputDirection
    {
        get { return inputDirection; }
        set { inputDirection = value; } 
    }

    private float moveX = 0f;
    private float moveY = 0f;

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }


        inputDirection = new Vector3(moveX, moveY).normalized;

    }
}
