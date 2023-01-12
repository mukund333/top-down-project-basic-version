using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovementStateMachine : StateMachine
{
    public SteeringBasics steeringBasics;

    public PlayerPhysics target;

    private void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        target = GameObject.Find("player").GetComponent<PlayerPhysics>();
    }



}
