using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SkeletonChargeState : BaseState
{
    private StateMachineSkeleton _stateMachine;

    private float distanceFromTarget;
    private float chargeDistance;

    private float targetRadius ;
    private float slowRadius;
    private float timeToTarget ;

    private float maxChargeVelocity;
    private float maxAcceleration;

    private Rigidbody2D rb2d;

    private float chargeDuration;
    private float chargeTime;
    private bool isCharged;
    //private IEnumerator chargeCoroutine;

   
   
   

    public SkeletonChargeState(StateMachineSkeleton stateMachine) : base("Arriving", stateMachine)
    {
        _stateMachine = (StateMachineSkeleton)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        chargeDistance      = _stateMachine.skeletonAgent.ChargeDistance;

        Debug.Log("Charge state");

        _stateMachine.skeletonAgent.spriteRenderer.color = Color.yellow;

        rb2d                = _stateMachine.skeletonAgent.rigidbody2d;

        maxChargeVelocity   = _stateMachine.skeletonAgent.MaxArriveChargeVelocity;
        maxAcceleration     = _stateMachine.skeletonAgent.MaxArriveAcceleration;

        targetRadius        = _stateMachine.skeletonAgent.TargetRadius;
        slowRadius          = chargeDistance;
        timeToTarget        = _stateMachine.skeletonAgent.TimeToTarget;

        _stateMachine.steeringBehaviorsCore.MaxSteeringVelocity = maxChargeVelocity;
        _stateMachine.steeringBehaviorsCore.MaxAcceleration = maxAcceleration;

        chargeDuration = _stateMachine.skeletonAgent.ChargeTimeDuration;
        isCharged = true;

        chargeTime = 0f;
        _stateMachine.rb2d.drag = 0f;

    }

   


    public override void UpdatePhysics()
    {
        base.UpdatePhysics();


        //Debug.Log("chargeTime :" + chargeTime);
        distanceFromTarget = _stateMachine.skeletonAgent.DistanceFromPlayer;

        if (distanceFromTarget > chargeDistance)
        {
            stateMachine.ChangeState(_stateMachine.seekState_Skeleton);
        }

        if (distanceFromTarget <= chargeDistance)
        {
            if (isCharged)
            {
               
                //chargeCoroutine = ChargeTimer();
                //_stateMachine.StartCoroutine(chargeCoroutine);

                Vector3 SteeringSpeed = Arrive(_stateMachine.skeletonAgent.target.transform.position);
                _stateMachine.steeringBehaviorsCore.Steer(SteeringSpeed);

                if (distanceFromTarget <= targetRadius)
                {
                    chargeTime = 0f;
                    stateMachine.ChangeState(_stateMachine.attackState_Skeleton);
                }
                else
                {
                    chargeTime += Time.deltaTime;
                    if (chargeTime > chargeDuration)
                    {
                        isCharged = false;
                        chargeTime = 0.0f;

                        //change State
                        stateMachine.ChangeState(_stateMachine.recovery_Skeleton);
                       

                    }
                }

                

            }
              
        }

        //if (distanceFromTarget <= targetRadius)
        //{
        //    isCharged = false;
        //    _stateMachine.StopCoroutine("ChargeTimer");
        //    // change state to attack
        //    stateMachine.ChangeState(_stateMachine.attackState_Skeleton);
        //}

    }

    public Vector3 Arrive(Vector3 targetPosition)
    {

        //  Debug.DrawLine(transform.position, targetPosition, Color.cyan, 0f, false);

        /* Get the right direction for the linear acceleration */
        Vector3 targetVelocity = targetPosition -_stateMachine.transform.position;

        /* Get the distance to the target */
        float distance = targetVelocity.magnitude;

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

            targetSpeed = maxChargeVelocity;
        }
        else
        {
            targetSpeed = maxChargeVelocity * (distance / slowRadius);
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

    //IEnumerator ChargeTimer()
    //{

    //    float counter = 0;
    //    while (counter < (chargeDuration))
    //    {
    //        counter += Time.deltaTime;
    //        //Debug.Log("  charged");


    //        if (distanceFromTarget <= targetRadius)
    //        {
    //            // Debug.Log("attack");
    //            isCharged = false;
    //            _stateMachine.StopCoroutine("ChargeTimer");
    //            // change state to attack
    //            stateMachine.ChangeState(_stateMachine.attackState_Skeleton);

    //            yield break;
    //        }

    //        yield return null;
    //    }

    //   // Debug.Log("  charge end");
    //    isCharged = false;
    //    _stateMachine.StopCoroutine("ChargeTimer");
    //    // change state to recovery
    //    stateMachine.ChangeState(_stateMachine.recovery_Skeleton);
    //    yield break;

    //}


}
