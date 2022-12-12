using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    //require components
    private Rigidbody2D rb2d;


    //movement physics
    public float MoveSpeed = 15f;

    //movement input - pc 
    private float vertical;
    private float horizontal;


    private void Awake()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal*MoveSpeed,vertical*MoveSpeed);
    }



    #region additional functionality
    /*

    // limit movement speed diagonally, so you move at 70% speed

    float moveLimiter = 0.7f;

    void FixedUpdate()
    {
       if (horizontal != 0 && vertical != 0) // Check for diagonal movement
       {
          // limit movement speed diagonally, so you move at 70% speed
          horizontal *= moveLimiter;
          vertical *= moveLimiter;
       } 
       body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }


     */
    #endregion
}


