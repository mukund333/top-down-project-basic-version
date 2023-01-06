using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementPhysics : MonoBehaviour
{

    [SerializeField] private float normalSpeed = 40f;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private PlayerMovementKeyboardInput keyboardInput;

    //[SerializeField] private Dash dash;

    [SerializeField] private Vector2 playerVelocity;
    [SerializeField] private Vector3 playerPosition; 
    public Vector2 PlayerVelocity
    {
        get { return playerVelocity; }
        
    }
    public Vector3 PlayerPosition
    {
        get { return this.transform.position; }
    }

    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;

        keyboardInput = GetComponent<PlayerMovementKeyboardInput>();
       // dash = GetComponent<Dash>();
    }

    //private void FixedUpdate()
    //{
    //    if (!dash.isDashing)
    //    {
    //        rb2d.velocity = keyboardInput.moveDirection * normalSpeed * Time.fixedDeltaTime;
    //    }
    //}

    private void FixedUpdate()
    {
        playerVelocity = rb2d.velocity;
        rb2d.velocity = keyboardInput.moveDirection * normalSpeed * Time.fixedDeltaTime;
    }


}
