using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : BaseState
{

    private StateMachineSkeleton _stateMachine;

    public SkeletonIdleState(StateMachineSkeleton stateMachine) : base("Idle", stateMachine)
    {
        _stateMachine = (StateMachineSkeleton)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("skeleton Idle state");

        _stateMachine.rb2d.velocity = Vector2.zero;
        stateMachine.ChangeState(_stateMachine.seekState_Skeleton);
    }



}
