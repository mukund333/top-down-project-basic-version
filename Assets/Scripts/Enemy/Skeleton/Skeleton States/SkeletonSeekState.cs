using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSeekState : BaseState
{
    private StateMachineSkeleton _stateMachine;

    private float seekVelocity;

    private float maxSeekAcceleration;

    private float chargeDistance;

    public SkeletonSeekState(StateMachineSkeleton stateMachine) : base("Seeking", stateMachine)
    {
        _stateMachine = (StateMachineSkeleton)stateMachine;
      
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("skeleton seek state");
        _stateMachine.rb2d.drag = 0f;
        seekVelocity = 5f;
        maxSeekAcceleration = _stateMachine.skeletonAgent.MaxSeekAcceleration;
        chargeDistance = _stateMachine.skeletonAgent.ChargeDistance;
        _stateMachine.skeletonAgent.spriteRenderer.color = Color.green;
       
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (_stateMachine.skeletonAgent.DistanceFromPlayer > chargeDistance)
        {
            Seeking();
        }

        if (_stateMachine.skeletonAgent.DistanceFromPlayer < chargeDistance)
        {
            stateMachine.ChangeState(_stateMachine.chargeState_Skeleton);
        }
    }

    private void Seeking()
    {
        _stateMachine.steeringBehaviorsCore.MaxSteeringVelocity = seekVelocity;

        Vector3 accel = _stateMachine.steeringBehaviorsCore.Seek(_stateMachine.skeletonAgent.target.transform.position,maxSeekAcceleration);

       _stateMachine.steeringBehaviorsCore.Steer(accel);

    }

}
