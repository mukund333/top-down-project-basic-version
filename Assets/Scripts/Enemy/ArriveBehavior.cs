using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private float targetRadius;
    [SerializeField] private float slowRadius;
    [SerializeField] private float timeToTarget;

    [SerializeField] private float maxChargeVelocity;
    [SerializeField] private float maxAcceleration;

    public bool isReachSlowRadius;

    [SerializeField] private BehaviorsManager behaviorsManager;

    private void Start()
    {
        behaviorsManager = GetComponent<BehaviorsManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        isReachSlowRadius = false;
        slowRadius = behaviorsManager.chargeRange;
    }


    public Vector3 Arrive(Vector3 targetPosition)
    {

        //  Debug.DrawLine(transform.position, targetPosition, Color.cyan, 0f, false);

        /* Get the right direction for the linear acceleration */
        Vector3 targetVelocity = targetPosition - transform.position;

        /* Get the distance to the target */
        float distance = targetVelocity.magnitude;

        /* If we are within the stopping radius then stop */
        if (distance < targetRadius)
        {
            rigidbody2D.velocity = Vector3.zero;
            return Vector3.zero;
        }

        /* Calculate the target speed, full speed at slowRadius distance and 0 speed at 0 distance */
        float targetSpeed;
        if (distance > slowRadius)
        {

            targetSpeed = maxChargeVelocity;

            isReachSlowRadius = false;
        }
        else
        {
            targetSpeed = maxChargeVelocity * (distance / slowRadius);

            isReachSlowRadius = true;
        }


        /* Give targetVelocity the correct speed */
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        /* Calculate the linear acceleration we want */
        Vector3 acceleration = (Vector2)targetVelocity - rigidbody2D.velocity;
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
