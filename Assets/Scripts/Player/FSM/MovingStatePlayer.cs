using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStatePlayer : BaseState
{
    private PlayerStateMachine _stateMachine;

    [SerializeField] private Vector2 input;

    private float normalSpeed;

    public MovingStatePlayer(PlayerStateMachine stateMachine) : base("Moving", stateMachine)
    {
        _stateMachine = (PlayerStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        input = Vector2.zero;
        normalSpeed = 400f;
        
        _stateMachine.keyboardInput.IsDisableInput = false;
       // _stateMachine.colliderController.collider2D.enabled = true;

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //continuous  inputs value init

        input = _stateMachine.keyboardInput.InputDirection;

        //Moving State Logic

        _stateMachine.playerPhysics.Direction = input;
        _stateMachine.playerPhysics.Speed = normalSpeed;

        //State Change Events

        if (input==Vector2.zero)
        {
            stateMachine.ChangeState(_stateMachine.idleState);// <---  The stateMachine in this line comes from BaseState...
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            _stateMachine.keyboardInput.IsDisableInput = true;
          //  _stateMachine.colliderController.collider2D.enabled = false;

            stateMachine.ChangeState(_stateMachine.dashState);
        }

        if (_stateMachine.playerCollisionInfo.IsEnemyCollided)
        {
            _stateMachine.keyboardInput.IsDisableInput = true;
            stateMachine.ChangeState(_stateMachine.knockbackState);
        }

    }
}
