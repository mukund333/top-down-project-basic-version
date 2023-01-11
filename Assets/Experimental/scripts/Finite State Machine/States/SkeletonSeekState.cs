using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSeekState : BaseState
{
    private SkeletonMovementStateMachine _skeletonSM;


    public SkeletonSeekState(SkeletonMovementStateMachine stateMachine) : base("Seeking", stateMachine)
    {
        _skeletonSM = (SkeletonMovementStateMachine)stateMachine;
    }

   
    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //if(_skeletonSM.steeringBasics.targetDistace < 5f)
        //{
        //    //stateMachine.ChangeState();
        //}

    }


    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector3 accel = _skeletonSM.steeringBasics.Arrive(_skeletonSM.target.PlayerPosition);

        _skeletonSM.steeringBasics.Steer(accel);
    }



}
