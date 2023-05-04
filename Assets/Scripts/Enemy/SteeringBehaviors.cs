using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SteeringBehaviors : MonoBehaviour
{
    //class members
    [SerializeField] private float maxSteeringVelocity;


    // mutators
    public float MaxSteeringVelocity
    {
        get { return maxSteeringVelocity; }
        set { maxSteeringVelocity = value; }
    }


    // required component
    [SerializeField] private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }




    public void Steer(Vector3 linearAcceleration)
    {
        rigidbody2d.velocity += (Vector2)linearAcceleration * Time.deltaTime;

        if (rigidbody2d.velocity.magnitude > maxSteeringVelocity)
        {
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxSteeringVelocity;

            //  Debug.DrawRay(transform.position, rigidbody2d.velocity.normalized * 5f, Color.magenta);

        }
    }

}
