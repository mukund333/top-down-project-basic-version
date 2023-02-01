using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAgent : MonoBehaviour
{

    [SerializeField] private float distance_From_Player;
  
   
    

    [SerializeField] private Vector3 targetDirection;
    [SerializeField] private float maxSeekAcceleration;

    [SerializeField] private float maxChargeAcceleration;
    [SerializeField] private float maxChargeVelocity;

    public SpriteRenderer spriteRenderer;
  



    /// <summary>
    /// The radius from the target that means we are close enough and have arrived
    /// </summary>
    [SerializeField] private float targetRadius = 0.005f;

    /// <summary>
    /// The radius from the target where we start to slow down
    /// </summary>
    [SerializeField] private float chargeRadius = 1f;

    /// <summary>
    /// The time in which we want to achieve the targetSpeed
    /// </summary>
    [SerializeField] private float timeToTarget = 0.1f;

    [SerializeField] private float chargeTimeDuration;

    [SerializeField] private float attackTimeDuration;


      [SerializeField] private float recoveryTimeDuration;


    [SerializeField] private float agentDrag;

    [SerializeField] private bool isSeekRadius;
    [SerializeField] private bool isChargeRadius;
    [SerializeField] private bool isAttackRadius;



    public float DistanceFromPlayer
    {
        get { return distance_From_Player; }
        set { distance_From_Player = value; }
    }
    public float ChargeDistance { 
        get { return chargeRadius; } set { chargeRadius = value; } }

    public AnimationCurve animCurve;

    public float MaxSeekAcceleration { get { return maxSeekAcceleration; }}

    public Vector3 TargetDirection { get { return targetDirection; } }

    public float TargetRadius { get { return targetRadius; } }

    public float SlowRadius { get { return chargeRadius; } }

    public float TimeToTarget { get { return timeToTarget; } }

    public float MaxArriveAcceleration { get { return maxChargeAcceleration; } }

    public float MaxArriveChargeVelocity { get { return maxChargeVelocity; } }

    public float ChargeTimeDuration { get { return chargeTimeDuration; } }

    public float AttackTimeDuration { get { return attackTimeDuration; } }

    public float RecoveryTimeDuration { get { return recoveryTimeDuration; } }

    public float AgentDrag { get { return agentDrag; } set { agentDrag = value; } }

    public bool IsSeekRadius { get { return isSeekRadius; } }
    public bool IsChargeRadius { get { return isChargeRadius; } }
    public bool IsAttackRadius { get { return isAttackRadius; } }


    // required components
    [SerializeField] private SteeringBehaviorsCore   steeringBehaviorsCore;

    public Rigidbody2D rigidbody2d;

    // required scripts
    public PlayerPhysics target;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        steeringBehaviorsCore = GetComponent<SteeringBehaviorsCore>();

        target = GameObject.Find("Player").GetComponent<PlayerPhysics>();

        rigidbody2d = GetComponent<Rigidbody2D>();

        distance_From_Player = 5f;
    }

    private void FixedUpdate()
    {
        /* Get the distance */
        distance_From_Player = steeringBehaviorsCore.GetTargetDistance(target.transform.position);

       /* Get the direction */
        targetDirection = target.transform.position - transform.position;
    }


}
