using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerStateMachine : StateMachine
{
    //States 
    public IdleStatePlayer      idleState;
    public MovingStatePlayer    movingState;
    public KnockbackStatePlayer knockbackState;
    public DashStatePlayer      dashState;


    //Required components
    public PlayerKeyboardInput  keyboardInput;
    public PlayerPhysics        playerPhysics;
    public PlayerCollisionInfo  playerCollisionInfo;
    public ColliderController colliderController;

    public ImmortalityStatePlayer immortalityStatePlayer;


    private void Awake()
    {
        //States initialization
        idleState       = new IdleStatePlayer(this);
        movingState     = new MovingStatePlayer(this);
        dashState       = new DashStatePlayer(this);
        knockbackState  = new KnockbackStatePlayer(this);

        //Required components
        keyboardInput       = GetComponent<PlayerKeyboardInput>();
        playerPhysics       = GetComponent<PlayerPhysics>();
        playerCollisionInfo = GetComponent<PlayerCollisionInfo>();
        immortalityStatePlayer = GetComponent<ImmortalityStatePlayer>();
        colliderController = GetComponent<ColliderController>();
      

    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    public BaseState GetCurrentState()
    {
     
        return currentState;
    
    }



}
