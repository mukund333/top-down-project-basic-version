using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueUnit : MonoBehaviour
{
   [SerializeField] private SteeringBasics steeringBasics;
   [SerializeField] private Pursue pursue;
   [SerializeField] private PlayerPhysics target;


    void Awake()
    {
        target = GameObject.Find("player").GetComponent<PlayerPhysics>();
        steeringBasics = GetComponent<SteeringBasics>();
        pursue = GetComponent<Pursue>();
    }

    void FixedUpdate()
    {
        Vector3 accel = pursue.GetSteering(target);

        steeringBasics.Steer(accel);
       
    }
}
