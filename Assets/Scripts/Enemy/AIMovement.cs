using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private ContextSolver contextSolver;

    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private float maxSteeringVelocity;

    [SerializeField] private ContextData contextData;

    public bool following;





    [SerializeField] private Vector2 targetPositionCached;

    private void Start()
    {

        contextData = GetComponentInChildren<ContextData>();

        contextSolver = GetComponentInChildren<ContextSolver>();

        rigidbody2D = GetComponent<Rigidbody2D>();

        following = false;
    }

    private void Update()
    {



        //First check if we have reached the target

    }

    private void FixedUpdate()
    {
        if (contextData.currentTarget == null)
        {
            rigidbody2D.velocity = Vector2.zero;
            following = false;
        }


        if (contextData.currentTarget != null)
        {

            following = true;

        }
        else if (contextData.GetTargetsCount() > 0)
        {
            contextData.currentTarget = contextData.targets[0];

            float distance = Vector2.Distance(contextData.currentTarget.position, transform.position);
            following = true;

        }
        else
        {
            following = false;
        }

        Move();
    }

    public Vector3 Move()
    {
        if (following)
        {
            return contextSolver.resultDirection * maxSteeringVelocity;
        }

        return Vector3.zero;
        //rigidbody2D.velocity = contextSolver.resultDirection * maxSteeringVelocity * Time.deltaTime;

    }






}
