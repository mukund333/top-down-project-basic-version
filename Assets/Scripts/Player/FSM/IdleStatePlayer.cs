using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStatePlayer : BaseState
{
    private PlayerStateMachine _stateMachine;


    [SerializeField] private Vector2 input;

   public IdleStatePlayer(PlayerStateMachine stateMachine):base ("Idle",stateMachine)
    {
        _stateMachine = (PlayerStateMachine)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
       input = Vector2.zero;
        _stateMachine.playerPhysics.Speed = 0;
    }


    public override void UpdateLogic()
    {
        base.UpdateLogic();

        input = _stateMachine.keyboardInput.InputDirection;

        if (input != Vector2.zero)
        {
            stateMachine.ChangeState(_stateMachine.movingState);// <---  The stateMachine in this line comes from BaseState...
            
        }

        if(_stateMachine.playerCollisionInfo.IsEnemyCollided)
        {
            _stateMachine.keyboardInput.IsDisableInput = true;
            stateMachine.ChangeState(_stateMachine.knockbackState);
        }

    }

}
