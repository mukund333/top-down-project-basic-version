using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeyboardInput : MonoBehaviour
{
    public Vector3 moveDirection;

    float moveX = 0f;
    float moveY = 0f;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
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


        moveDirection = new Vector3(moveX, moveY).normalized;

    }
}
