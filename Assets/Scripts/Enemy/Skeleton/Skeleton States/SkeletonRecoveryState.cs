using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRecoveryState : BaseState
{
    private StateMachineSkeleton _stateMachine;


    public float recoveryDuration;
    private float recoverTime;
    public bool isRecoverying;

    //Curve param
    private float acc;
    private float accTime;
    private float agentDrag;
    private Vector2 lastDirection;
    private bool isTrust;

    //private float chargeDistance;
    private float targetRadius;

   

    public SkeletonRecoveryState(StateMachineSkeleton stateMachine) : base("Recovery", stateMachine)
    {

        _stateMachine = (StateMachineSkeleton)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        isRecoverying = true;
        
      
       Debug.Log("recovery state");

        recoveryDuration = 1f;
        recoverTime = 0f;
       
        _stateMachine.skeletonAgent.spriteRenderer.color = Color.white;
       
        //chargeDistance = _stateMachine.skeletonAgent.MacharchingDistance;
        targetRadius = _stateMachine.skeletonAgent.TargetRadius;
        acc = 0f;
        accTime = 1f;
        //agentVelocity = 12f;
        agentDrag = _stateMachine.skeletonAgent.AgentDrag;
        //_stateMachine.rb2d.isKinematic = true;

        //lastDirection = _stateMachine.transform.position;

        //isTrust = true;



    }


    public override void UpdateLogic()
    {
        base.UpdateLogic();

       

        if (isRecoverying)
        {
            

            recoverTime += Time.deltaTime;

            if (recoverTime > recoveryDuration)
            {
                isRecoverying = false;
                recoverTime = 0.0f;
              
                    //change State
                    stateMachine.ChangeState(_stateMachine.seekState_Skeleton);
                
            }
        }

     
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        float distanceFromTarget = _stateMachine.skeletonAgent.DistanceFromPlayer;

        if (distanceFromTarget <= targetRadius-0.2f)
        {
            _stateMachine.rb2d.velocity = Vector2.zero;
            Debug.Log("reach rb");
        }

        //decelerate rb velocity here
        acc = acc + 1f / accTime * Time.deltaTime;
        _stateMachine.rb2d.drag = agentDrag * _stateMachine.skeletonAgent.animCurve.Evaluate(acc);
        acc = Mathf.Clamp(acc, 0f, 1f);


    }



    //public override void UpdatePhysics()
    //{
    //    base.UpdatePhysics();

    //    if(isTrust)
    //    {
    //        isTrust = false;

    //        acc = acc + 1f / accTime * Time.deltaTime;

    //        _stateMachine.rb2d.velocity *=  (agentVelocity * _stateMachine.skeletonAgent.animCurve.Evaluate(acc));

    //        acc = Mathf.Clamp(acc, 0f, 1f);

    //        if (acc > 0f)
    //        {
    //            acc = _stateMachine.rb2d.velocity.magnitude / agentVelocity;
    //        }
    //    }

    //}

    // accThrust = accThrust + 1f / accTimeThrust * Time.deltaTime;
    // rb2d.velocity = transform.right* (weaponThrust* accCurveThrust.Evaluate(accDrag));
    //accThrust = Mathf.Clamp(accThrust, 0f, 1f);

    //if (accThrust > 0f)
    //{
    //	accThrust = this.rb2d.velocity.magnitude / weaponThrust;
    //}
}




