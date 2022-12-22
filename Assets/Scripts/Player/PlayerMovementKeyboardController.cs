using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementKeyboardController : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    //require components
    private Rigidbody2D rb2d;
    private Vector3 moveDirection;
    public Vector3 lastMoveDirection ;

    float moveX = 0f;
    float moveY = 0f;

    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleMovement();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = moveDirection * speed * Time.fixedDeltaTime;
    }

    private void HandleMovement()
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

        
        moveDirection = new Vector3(moveX,moveY).normalized;
        lastMoveDirection = moveDirection;
        
    }

}


