using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBasic : MonoBehaviour
{
    /*
        1.seek
        2.arrive ??
        3.animations
     
     */

    [SerializeField] private SteeringBasics         steeringBasics;
    [SerializeField] private PlayerMovementPhysics  target;


    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
    }


    void FixedUpdate()
    {
        Vector3 accel = steeringBasics.Seek(target.PlayerPosition);

        steeringBasics.Steer(accel);

        Vector3 accel2 = steeringBasics.Arrive(target.PlayerPosition);

        steeringBasics.Steer(accel2);

    }

}
