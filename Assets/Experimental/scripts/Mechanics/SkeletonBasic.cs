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
    [SerializeField] private PlayerPhysics  target;

    [SerializeField] private SpriteRenderer spriteRenderer;
   




    [SerializeField] private float marchingDistance;
    [SerializeField] private float chargeVelocity;
    [SerializeField] private float seekVelocity;
    [SerializeField] private float marchTime;
    [SerializeField] private float recoverTime;

    float distanceFromPlayer;
    private Rigidbody2D rb2d;

   public bool isRecovered;
    bool isMarched;
    bool isRecoveringTime;
    private Coroutine marchCoroutine;



    private void Awake()
    {
        steeringBasics = GetComponent<SteeringBasics>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        isRecovered = true;
        isRecoveringTime = false;
        isMarched = false;

       
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
                marchCoroutine = StartCoroutine(MarchingCoroutine());
                isMarched = true;
            }


            spriteRenderer.color = Color.white;
        }
        
        if (distanceFromPlayer <= 1.3f && isRecovered)
        {
            Attacking();
           

            spriteRenderer.color = Color.red;
        }

        if (!isRecovered)
        {
            Recovering();
            if(!isRecoveringTime)
            {
                StartCoroutine(RecoveryCoroutine());
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
        Debug.Log("charge");

        steeringBasics.maxVelocity = chargeVelocity;

        Vector3 accel = steeringBasics.Arrive(target.transform.position);

        steeringBasics.Steer(accel);

        
    }

    private void Attacking()
    {
        //attack animation
       Debug.Log("Attacking");
    }

    private void Recovering()
    {
        //Recover animation 
        Debug.Log("Recovering");

        rb2d.velocity = Vector2.zero;
    }
    #endregion


    #region 
    
    IEnumerator MarchingCoroutine()
    {
        Debug.Log("MarchingCoroutine: " + marchTime);
        yield return new WaitForSeconds(marchTime);
        isRecovered = false;
        isMarched = false;

      
        StopCoroutine(MarchingCoroutine());

    }

    IEnumerator RecoveryCoroutine()
    {

        yield return new WaitForSeconds(recoverTime);
        isRecovered = true;
        isRecoveringTime = false;

        StopCoroutine(RecoveryCoroutine());

    }

    IEnumerator AttackCoroutine()
    {

        yield return new WaitForSeconds(1);
        isRecovered = false;

        StopCoroutine(AttackCoroutine());

    }

    #endregion
}
