using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : BaseState
{
    private StateMachineSkeleton _stateMachine;

    private IEnumerator attackCoroutine;

    [SerializeField] private bool isTimerStarted;
    [SerializeField] private float timeDuration;

    private float attackDuration;
    private float attackTime;
    private bool isAttacking;

    [SerializeField] private int health=100;

    public SkeletonAttackState(StateMachineSkeleton stateMachine) : base("Attacking", stateMachine)
    {
        _stateMachine = (StateMachineSkeleton)stateMachine;

    }

    public override void Enter()
    {
        base.Enter();
        health = 100;
        Debug.Log("Attack state");

        //_stateMachine.IsTimerStarted = true;
        //_stateMachine.TimeDuration = _stateMachine.skeletonAgent.AttackTimeDuration;

        isAttacking = true;
        attackDuration = _stateMachine.skeletonAgent.AttackTimeDuration;
        attackTime = 0f;

        isTimerStarted = true;
        timeDuration = 1f;//
        _stateMachine.skeletonAgent.spriteRenderer.color = Color.red;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if(isAttacking)
        {
            attackTime += Time.deltaTime;
            if (attackTime > attackDuration)
            {
                isAttacking = false;
                attackTime = 0.0f;

                //change State
                stateMachine.ChangeState(_stateMachine.recovery_Skeleton);

            }
        }

        if (health <= 0)
        {
            // change state to death
            stateMachine.ChangeState(_stateMachine.deathState_Skeleton);  
        }

    }

    public override void UpdatePhysics()
    {
       
       
        base.UpdatePhysics();

        //if (isTimerStarted)
        //{
        //    attackCoroutine = WaitingTimer();
        //    _stateMachine.StartCoroutine(attackCoroutine);

        //}

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    health = 0;
        //}

    }

    //IEnumerator WaitingTimer()
    //{
    //    float counter = 0;
    //    while (counter < (timeDuration))
    //    {
    //        counter += Time.deltaTime;
    //        //  Debug.Log(" playing Attack animation");


    //        if (health <= 0)
    //        {

    //            isTimerStarted = false;
    //            // Debug.Log(" death animation");
    //            _stateMachine.StopCoroutine("WaitingTimer");

    //            // change state to death
    //            stateMachine.ChangeState(_stateMachine.deathState_Skeleton);
    //            yield break;
    //        }

    //        yield return null;
    //    }

    //   // Debug.Log("finish playing Attack animation");

    //    isTimerStarted = false;
    //    _stateMachine.StopCoroutine("WaitingTimer");


    //    // change state to recovery
    //    stateMachine.ChangeState(_stateMachine.recovery_Skeleton);
    //    yield break;


    //}


    //public IEnumerator PlayAndWaitForAnim(string stateName)
    //{
    //    animStateIndex.SetData(2);
    //    animator.speed = 0.5f;
    //    //Wait until we enter the current state
    //    while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
    //    {
    //        yield return null;

    //    }




    //    float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;

    //    float counter = 0;
    //    while (counter < (waitTime))
    //    {
    //        counter += Time.deltaTime;
    //        Debug.Log("counter ");
    //        yield return null;
    //    }

    //    //Done playing. Do something below!
    //    callKillMixin.Action();

    //    yield break;
    //}

}
