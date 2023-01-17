using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackStatePlayer : BaseState
{
    private PlayerStateMachine _stateMachine;
    
    private Vector3 knockbackDirection;
    
    private float knockbackForce;
    private float knockbackTimeDuration;
    private float knockbackTime;

    private bool isknockback;

    public KnockbackStatePlayer(PlayerStateMachine stateMachine) : base("Knockback", stateMachine)
    {
        _stateMachine = (PlayerStateMachine)stateMachine;

    }


    public override void Enter()
    {
        base.Enter();
        knockbackDirection = (_stateMachine.playerCollisionInfo.CollisionDirection - _stateMachine.transform.position).normalized;
        _stateMachine.playerCollisionInfo.IsEnemyCollided = false;
        knockbackTime = 0.0f;
        knockbackTimeDuration = 0.2f;
        isknockback = true;
        knockbackForce = 500f;
        

      
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (isknockback)
        {

            knockbackTime += Time.deltaTime;
            if (knockbackTime > knockbackTimeDuration)
            {
                isknockback = false;
                _stateMachine.keyboardInput.IsDisableInput = false;
                knockbackTime = 0.0f;
                stateMachine.ChangeState(_stateMachine.idleState);


            }

        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (isknockback)
        {
            _stateMachine.playerPhysics.Direction = -knockbackDirection;
            _stateMachine.playerPhysics.Speed = knockbackForce;
        }
    }



}
