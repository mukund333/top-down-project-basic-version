using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveUnit : MonoBehaviour
{
   

    SteeringBasics steeringBasics;

    [SerializeField] private PlayerMovementPhysics target;

    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        target = GameObject.Find("player").GetComponent<PlayerMovementPhysics>();
    }

    void FixedUpdate()
    {

       
        Vector3 accel = steeringBasics.Arrive(target.PlayerPosition);

        steeringBasics.Steer(accel);
       
    }
}
