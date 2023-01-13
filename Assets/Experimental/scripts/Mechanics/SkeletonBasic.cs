using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBasic : MonoBehaviour
{
    /*
        1.seek
        2.arrive ??
        3.animations SkeletonMovementStateMachine
     
     */

    [SerializeField] private SteeringBasics         steeringBasics;
    [SerializeField] private GameObject  target;

    [SerializeField] private SpriteRenderer spriteRenderer;
   




    [SerializeField] private float marchingDistance;
    [SerializeField] private float chargeVelocity;
    [SerializeField] private float seekVelocity;
    [SerializeField] private float marchTime;
    [SerializeField] private float recoverTime;
    [SerializeField] private float attackTime;

    float distanceFromPlayer;
    private Rigidbody2D rb2d;

   public bool isRecovered;
    bool isMarched;
    bool isAttacking;
    bool isRecoveringTime;

    private Coroutine marchCoroutine;
    private Coroutine recoveryCoroutine;
    private Coroutine attackCoroutine;



    private void Awake()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");

        isRecovered = true;
        isRecoveringTime = false;
        isMarched = false;
        isAttacking = false;


    }

    private void Update()
    {
      
    }

    void FixedUpdate()
    {
        
        distanceFromPlayer = steeringBasics.GetTargetDistance(target.transform.position);
      
        if (distanceFromPlayer > marchingDistance )
        {
            Seeking();

            if(marchCoroutine!=null)
            {
                StopCoroutine(marchCoroutine);
                isMarched = false;
            }
           
            spriteRenderer.color = Color.blue;
        }
        

        if (distanceFromPlayer <= marchingDistance && isRecovered )
        {
           

            Marching();

            if (!isMarched)
            {
                marchCoroutine = StartCoroutine(MarchingTimeCoroutine());
                isMarched = true;
            }


            spriteRenderer.color = Color.white;
        }
        
        if (distanceFromPlayer <= steeringBasics.targetRadius && isRecovered)
        {
            Attacking();

           if(!isAttacking)
            {
                attackCoroutine = StartCoroutine(AttackTimeCoroutine());
                isAttacking = true;
            }
            spriteRenderer.color = Color.red;
        }

        if (!isRecovered)
        {
            Recovering();
            if(!isRecoveringTime)
            {
                recoveryCoroutine = StartCoroutine(RecoveryTimeCoroutine());
                isRecoveringTime = true;
            }
           
            spriteRenderer.color = Color.yellow;
        }

    }


    #region mechanics
    private void Seeking()
    {
       // Debug.Log("Seeking");

        steeringBasics.maxVelocity = seekVelocity;

        Vector3 accel = steeringBasics.Seek(target.transform.position);

        steeringBasics.Steer(accel);
    }

    private void Marching()
    { 
       // Debug.Log("charge");

        steeringBasics.maxVelocity = chargeVelocity;

        Vector3 accel = steeringBasics.Arrive(target.transform.position);

        steeringBasics.Steer(accel);

        
    }

    private void Attacking()
    {
        //attack animation
      // Debug.Log("Attacking");
        rb2d.velocity = Vector2.zero;
    }

    private void Recovering()
    {
        //Recover animation 
       // Debug.Log("Recovering");
        rb2d.velocity = Vector2.zero;
    }
    #endregion


    #region 
    IEnumerator MarchingTimeCoroutine()
    {
        //Debug.Log("MarchingCoroutine: " + marchTime);
        yield return new WaitForSeconds(marchTime);
        isRecovered = false;
        isMarched = false;

      
        StopCoroutine(MarchingTimeCoroutine());

    }

    IEnumerator RecoveryTimeCoroutine()
    {

        yield return new WaitForSeconds(recoverTime);
        isRecovered = true;
        isRecoveringTime = false;

        StopCoroutine(RecoveryTimeCoroutine());

    }

    IEnumerator AttackTimeCoroutine()
    {

        yield return new WaitForSeconds(attackTime);
        isRecovered = false;
        isAttacking = false;

        StopCoroutine(AttackTimeCoroutine());

    }

    #endregion
}
