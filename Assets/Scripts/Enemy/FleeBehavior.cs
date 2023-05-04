using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : MonoBehaviour
{
    [SerializeField] private float maxSteeringVelocity;



    public Vector3 Flee(Vector3 targetPosition, float maxSeekAccel)
    {
        /* Get the direction */
        Vector3 acceleration = targetPosition - transform.position;

        acceleration.Normalize();

        /* Accelerate to the target */
        acceleration *= maxSeekAccel;



        return acceleration;
    }

    public Vector3 Flee(Vector3 targetPosition)
    {


        Vector2 fleeVector = -Flee(targetPosition, maxSteeringVelocity);


        return fleeVector;
    }
}
