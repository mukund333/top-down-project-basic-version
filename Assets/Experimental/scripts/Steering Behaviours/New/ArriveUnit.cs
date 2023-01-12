using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveUnit : MonoBehaviour
{
   

    SteeringBasics steeringBasics;

    [SerializeField] private PlayerPhysics target;

    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        target = GameObject.Find("player").GetComponent<PlayerPhysics>();
    }

    void FixedUpdate()
    {

       
        Vector3 accel = steeringBasics.Arrive(target.transform.position);

        steeringBasics.Steer(accel);
       
    }
}
