
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private PlayerMovementKeyboardInput keyboardInput;

    [SerializeField] private Vector3 lastMovementDirection;

    [SerializeField] private CoolDown coolDown;
    [SerializeField] private float dashSpeed = 40f;
    [SerializeField] private Rigidbody2D rb2d;

    public bool isDashing = false;

    [SerializeField] private float shortDistance = 0f;
    public Vector3 hitPoint;


    private void Awake()
    {
        keyboardInput = GetComponent<PlayerMovementKeyboardInput>();
        coolDown = GetComponent<CoolDown>();
        rb2d = GetComponent<Rigidbody2D>();
    }
   
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            coolDown.isCool = false;
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
            lastMovementDirection = keyboardInput.moveDirection;



        if (isDashing)
        {

            if(CheckDiagoanlMovement())
            {
                
                HandleDiagonalDash();
            }
            else
            {
                coolDown.cooldownTimer = 0.1f;
                HandleVerticalAndHorizontalDash();
            }
          

        }
        
        if (coolDown.isCool)
        {
            isDashing = false;
        }
    }


    bool CheckDiagoanlMovement()
    {
        if (lastMovementDirection.x != 0 && lastMovementDirection.y != 0)
        {
            return true;
        }
        return false;
    }

    bool isObstacle(Vector3 dir, float distance)
    {
        int layerMask = 1 << 6;


        layerMask = ~layerMask;

        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position, dir, distance, layerMask);

        if (hit.collider != null)
        {

            hitPoint = hit.point;

            Debug.Log("hit.point: "+hit.point);
            Debug.DrawRay(transform.position, dir * distance, Color.red);
            return true;

        }
        else
        {
            Debug.DrawRay(transform.position, dir * distance, Color.green);
            return false;
        }



    }

    void HandleVerticalAndHorizontalDash()
    {
        //Debug.Log("Dash");

        rb2d.velocity = lastMovementDirection * dashSpeed * Time.fixedDeltaTime;
    }
    void HandleDiagonalDash()
    {

       // Debug.Log("DiagonalDash");

        if(isObstacle(lastMovementDirection, 5f))
        {
            coolDown.cooldownTimer = 0.3f;
            Vector3 displacementFromTarget = hitPoint - transform.position;
            Vector3 directionToTarget = displacementFromTarget.normalized;

            float distanceToTarget = displacementFromTarget.magnitude;

            if(distanceToTarget>1f)
                rb2d.velocity = directionToTarget * dashSpeed * Time.fixedDeltaTime;
        }
        else
        {
            coolDown.cooldownTimer = 0.1f;
            rb2d.velocity = lastMovementDirection * dashSpeed * Time.fixedDeltaTime;
        }
       
    }
}
