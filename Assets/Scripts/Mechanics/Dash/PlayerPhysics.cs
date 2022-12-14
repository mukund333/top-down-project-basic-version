using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerPhysics : MonoBehaviour
{
    // all rigidbody related logic 

    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private Vector2 playerVelocity;
    [SerializeField] private Vector3 direction;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    public Vector2 PlayerVelocity
    {
        get { return playerVelocity; }
        
    }
    

    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;

    }

   

    private void FixedUpdate()
    {
        playerVelocity = rb2d.velocity;
        rb2d.velocity = direction * speed * Time.fixedDeltaTime;
    }


}
