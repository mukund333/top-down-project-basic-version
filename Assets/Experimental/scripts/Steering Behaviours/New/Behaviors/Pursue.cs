using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : MonoBehaviour
{
    public float maxPrediction = 1f;

    [SerializeField] SteeringBasics steeringBasics;

    private Rigidbody2D rb2d;

   

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        steeringBasics = GetComponent<SteeringBasics>();

       

       
    }

    public Vector3 GetSteering(PlayerMovementPhysics target)
    {
        /* Calculate the distance to the target */
        Vector3 displacement = target.PlayerPosition - transform.position;
        float distance = displacement.magnitude;

        /* Get the character's speed */
        float speed = rb2d.velocity.magnitude;

        /* Calculate the prediction time */
        float prediction;
        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }

        /* Put the target together based on where we think the target will be */
        Vector3 explicitTarget = (Vector2)target.PlayerPosition + target.PlayerVelocity * prediction;

        //Debug.DrawLine(transform.position, explicitTarget);

        return steeringBasics.Seek(explicitTarget);
    }
}
