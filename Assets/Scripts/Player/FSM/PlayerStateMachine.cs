using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerStateMachine : StateMachine
{
    public IdleStatePlayer idleState;

    public MovingStatePlayer movingState;

    public DashStatePlayer dashStatePlayer;

    public KnockbackStatePlayer knockbackState;

    public PlayerKeyboardInput keyboardInput;

    public PlayerPhysics playerPhysics;

    public PlayerCollisionInfo playerCollisionInfo;

    private void Awake()
    {
        idleState = new IdleStatePlayer(this);
        movingState = new MovingStatePlayer(this);
        dashStatePlayer = new DashStatePlayer(this);
        knockbackState = new KnockbackStatePlayer(this);


        keyboardInput = GetComponent<PlayerKeyboardInput>();
        playerPhysics = GetComponent<PlayerPhysics>();
        playerCollisionInfo = GetComponent<PlayerCollisionInfo>();
      

    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

}
