using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBasics : MonoBehaviour
{
    [Header("General")]

    public float maxVelocity = 3.5f;

    public float maxAcceleration = 10f;

    public float turnSpeed = 20f;

    private Rigidbody2D rb2d;

    private float distance;

    /// <summary>
    /// The radius from the target that means we are close enough and have arrived
    /// </summary>
    public float targetRadius = 0.005f;

    /// <summary>
    /// The radius from the target where we start to slow down
    /// </summary>
    public float slowRadius = 1f;

    /// <summary>
    /// The time in which we want to achieve the targetSpeed
    /// </summary>
    public float timeToTarget = 0.1f;





    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void Steer(Vector3 linearAcceleration)
    {
        rb2d.velocity += (Vector2)linearAcceleration * Time.deltaTime;

        if (rb2d.velocity.magnitude > maxVelocity)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxVelocity;
        }
    }

    public Vector3 Seek(Vector3 targetPosition, float maxSeekAccel)
    {
        /* Get the direction */
        Vector3 acceleration = targetPosition - transform.position;

        acceleration.Normalize();

        /* Accelerate to the target */
        acceleration *= maxSeekAccel;

        return acceleration;
    }

    public Vector3 Seek(Vector3 targetPosition)
    {
        return Seek(targetPosition, maxAcceleration);
    }

    public Vector3 Arrive(Vector3 targetPosition)
    {
      //  Debug.DrawLine(transform.position, targetPosition, Color.cyan, 0f, false);

        /* Get the right direction for the linear acceleration */
        Vector3 targetVelocity = targetPosition - transform.position;

        /* Get the distance to the target */
         distance = targetVelocity.magnitude;


        /* If we are within the stopping radius then stop */
        if (distance < targetRadius)
        {
            rb2d.velocity = Vector3.zero;
            return Vector3.zero;
        }

        /* Calculate the target speed, full speed at slowRadius distance and 0 speed at 0 distance */
        float targetSpeed;
        if (distance > slowRadius)
        {
            targetSpeed = maxVelocity;
        }
        else
        {
            targetSpeed = maxVelocity * (distance / slowRadius);
        }


        /* Give targetVelocity the correct speed */
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        /* Calculate the linear acceleration we want */
        Vector3 acceleration = (Vector2)targetVelocity - rb2d.velocity;
        /* Rather than accelerate the character to the correct speed in 1 second, 
         * accelerate so we reach the desired speed in timeToTarget seconds 
         * (if we were to actually accelerate for the full timeToTarget seconds). */
        acceleration *= 1 / timeToTarget;

        /* Make sure we are accelerating at max acceleration */
        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration.Normalize();
            acceleration *= maxAcceleration;
        }
        //Debug.Log("Accel " + acceleration.ToString("f4"));
        return acceleration;
    }



}
