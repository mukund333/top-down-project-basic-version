using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorsManager : MonoBehaviour
{

    // Define states
    public enum State { Ideal, FOV, Seek, Avoidance, Strafe, Charge, Attack, Recovery, Flee, Death }

    [SerializeField] private State currentState;


    // Define state machine

    // Define steer behavior components

    #region steer behavior
    private SteeringBehaviors steeringBehaviors;
    //   private SeekBehavior            seekBehavior;
    private AIMovement SeekBehaviorwithobascatelavoidance;
    private SeparationBehavior separationBehavior;
    private FleeBehavior fleeBehavior;
    private StrafingBehavior strafingBehavior;
    private ArriveBehavior arriveBehavior;


    #endregion

    #region steer behavior params


    public float strafeRange;
    [SerializeField] private float fleeRange;
    public float chargeRange;

    public bool isCharged;
    [SerializeField] private float chargeTime;
    [SerializeField] private float chargeDuration;




    [SerializeField] private float attackTime;
    [SerializeField] private float attackDuration;
    [SerializeField] private float attackVelocity;
    public bool isAttacking;
    private float targetRadius;
    public float recoveryDuration;
    private float recoverTime;
    public bool isRecovering;

    //Curve param
    private float acc;
    private float accTime;
    [SerializeField] private float agentDrag;

    [SerializeField] private AnimationCurve animCurve;



    #endregion




    #region common component

    [SerializeField] private Rigidbody2D rigidbody2D;
    public Transform target;
    [SerializeField] private SpriteRenderer spriteRenderer;
    #endregion





    #region steer beahvior weight system params

    [SerializeField] private float seekScale;
    [SerializeField] private float obtsacleAvoidScale;
    [SerializeField] private float separationScale;
    [SerializeField] private float fleeScale;
    [SerializeField] private float StrafeScale;
    [SerializeField] private float attackScale;

    #endregion




    private void Awake()
    {

        #region getting steer behavior components
        steeringBehaviors = GetComponent<SteeringBehaviors>();

        //seekBehavior                      = GetComponent<SeekBehavior>();
        SeekBehaviorwithobascatelavoidance = GetComponent<AIMovement>();
        separationBehavior = GetComponent<SeparationBehavior>();
        fleeBehavior = GetComponent<FleeBehavior>();
        strafingBehavior = GetComponent<StrafingBehavior>();
        arriveBehavior = GetComponent<ArriveBehavior>();
        #endregion

        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isCharged = false;
        isAttacking = false;
        isRecovering = false;

        steeringBehaviors.MaxSteeringVelocity = 5f;


    }

    private void Start()
    {
        currentState = State.Ideal; // Initialize to Move state

        chargeTime = 0f;

        acc = 0f;
        accTime = 1f;

    }

    private void Update()
    {
        float dist = (target.position - transform.position).magnitude;

        //state trasition logic

        switch (currentState)
        {


            case State.Seek:
                spriteRenderer.color = Color.white;

                if (dist < strafeRange)
                {

                    currentState = State.Strafe;
                    rigidbody2D.velocity = Vector2.zero;

                }
                break;

            case State.Strafe:

                if (dist > strafeRange)
                {
                    currentState = State.Seek;

                }

                if (dist < fleeRange)
                    currentState = State.Flee;

                if (isCharged && dist <= strafeRange)
                    currentState = State.Attack;


                break;

            case State.Flee:

                if (dist > fleeRange)
                    currentState = State.Strafe;



                break;

            case State.Attack:



                attackTime += Time.deltaTime;

                if (attackTime > attackDuration)
                {
                    isAttacking = false;
                    attackTime = 0.0f;

                    //change State
                    currentState = State.Recovery;
                }


                break;

            case State.Recovery:



                recoverTime += Time.deltaTime;

                if (recoverTime > recoveryDuration)
                {
                    // isRecoverying = false;
                    recoverTime = 0.0f;

                    //change State
                    currentState = State.Seek;


                }


                break;
        }
    }

    private void FixedUpdate()
    {
        //calculate distance between player and angent

        float dist = (target.position - transform.position).magnitude;

        //get behavior steering vector

        Vector2 seek = SeekBehaviorwithobascatelavoidance.Move();
        Vector2 separation = separationBehavior.Separate();
        Vector2 flee = fleeBehavior.Flee(target.position);
        Vector2 strafe = strafingBehavior.Strafing();
        Vector2 attack = arriveBehavior.Arrive(target.position);




        //state behavior logic

        switch (currentState)
        {
            case State.Ideal:

                currentState = State.Seek;

                break;

            case State.Seek:

                rigidbody2D.drag = 0;

                // chase state and no charged
                if (!isCharged)
                    spriteRenderer.color = Color.white;

                separationScale = 1f;
                seekScale = 1f;



                fleeScale = 0f;
                StrafeScale = 0f;
                attackScale = 0f;


                break;

            case State.Avoidance:

                //we build interset context map then this state totally individual,right now it tight up with seek behavior

                break;

            case State.Strafe:

                // no charged enemy in strafe state


                if (isCharged)
                {
                    strafeRange = chargeRange + 1f;
                    fleeRange = strafeRange - 1f;

                    //currentState = State.Charge;
                }

                if (dist >= fleeRange)
                {
                    StrafeScale = 1f;
                    separationScale = 5f;

                    seekScale = 0f;
                    fleeScale = 0f;
                    attackScale = 0f;
                }


                break;



            case State.Flee:

                // flee state


                if (dist < fleeRange && !isCharged)
                {
                    fleeScale = 1f;
                    separationScale = 5f;
                    StrafeScale = 0f;
                    attackScale = 0f;
                }

                if (dist < fleeRange && isCharged)
                {
                    fleeScale = 1f;
                    separationScale = 5f;
                    StrafeScale = 0f;
                    attackScale = 0f;
                }
                break;



            case State.Charge:


                break;

            case State.Attack:

                spriteRenderer.color = Color.red;
                steeringBehaviors.MaxSteeringVelocity = attackVelocity;


                Debug.Log("Attack state");

                attackScale = 5f;

                seekScale = 0f;
                fleeScale = 0f;
                separationScale = 0f;
                StrafeScale = 0f;




                break;

            case State.Recovery:

                steeringBehaviors.MaxSteeringVelocity = 5f;

                Debug.Log("recovery state");

                isCharged = false;

                spriteRenderer.color = Color.yellow;

                seekScale = 0f;
                attackScale = 0f;

                if (dist <= targetRadius - 0.2f)
                {
                    rigidbody2D.velocity = Vector2.zero;
                    Debug.Log("reach rb");
                }

                //decelerate rb velocity here
                acc = acc + 1f / accTime * Time.deltaTime;
                rigidbody2D.drag = agentDrag * animCurve.Evaluate(acc);
                acc = Mathf.Clamp(acc, 0f, 1f);



                break;

            case State.Death:
                break;

        }


        // add calculated weighting scale to steering vector

        attack *= attackScale;
        seek *= seekScale;

        separation *= separationScale;
        flee *= fleeScale;
        strafe *= StrafeScale;




        ApplyForce(seek);
        ApplyForce(strafe);
        ApplyForce(flee);
        ApplyForce(separation);
        ApplyForce(attack);



    }

    public void ApplyForce(Vector2 force)
    {
        steeringBehaviors.Steer(force);
    }
}
