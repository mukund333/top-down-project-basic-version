using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineSkeleton : StateMachine
{
    public SkeletonIdleState        idleState_Skeleton;
    public SkeletonSeekState        seekState_Skeleton;
    public SkeletonChargeState      chargeState_Skeleton;
    public SkeletonAttackState      attackState_Skeleton;
    public SkeletonRecoveryState    recovery_Skeleton;
    public SkeletonDeathState       deathState_Skeleton;





    public  Rigidbody2D rb2d;

    
    public SteeringBehaviorsCore steeringBehaviorsCore;
    public SkeletonAgent skeletonAgent;

    private void Awake()
    {
        //States initialization
        idleState_Skeleton      = new SkeletonIdleState(this);
        seekState_Skeleton      = new SkeletonSeekState(this);
        chargeState_Skeleton    = new SkeletonChargeState(this);
        attackState_Skeleton    = new SkeletonAttackState(this);
        recovery_Skeleton       = new SkeletonRecoveryState(this);
        deathState_Skeleton     = new SkeletonDeathState(this);
    
        //Required components 
        skeletonAgent = GetComponent<SkeletonAgent>();
        rb2d = GetComponent<Rigidbody2D>();
        steeringBehaviorsCore = GetComponent<SteeringBehaviorsCore>();


       
    }

    protected override BaseState GetInitialState()
    {
        return idleState_Skeleton;
    }

    
}
