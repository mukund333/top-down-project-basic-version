using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeathState : BaseState
{
    private StateMachineSkeleton _stateMachine;

    public SkeletonDeathState(StateMachineSkeleton stateMachine) : base("Death", stateMachine)
    {

        _stateMachine = (StateMachineSkeleton)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _stateMachine.skeletonAgent.spriteRenderer.color = Color.black;

    }

}
