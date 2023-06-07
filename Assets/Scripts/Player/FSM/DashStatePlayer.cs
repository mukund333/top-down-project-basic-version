using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStatePlayer : BaseState
{
    private PlayerStateMachine _stateMachine;

   

    [SerializeField] private Vector3 lastMovementDirection;

    private bool checkObstacle = false;
    private bool isObstacle = false;
    [SerializeField] Vector3 hitPoint;


    [SerializeField] private float dashSpeed = 2000f;

    [SerializeField] private bool isDashing;
    [SerializeField] private float dashTimeDuration;
    [SerializeField] private float dashTime;
    



    public DashStatePlayer(PlayerStateMachine stateMachine) : base("Dashing", stateMachine)
    {
        _stateMachine = (PlayerStateMachine)stateMachine;
       
    }

    public override void Enter()
    {
        base.Enter();


       // _stateMachine.colliderController.collider2D.enabled = false;

        dashTime = 0.0f;
        
        isDashing = true;

        lastMovementDirection = _stateMachine.keyboardInput.LastInputDirection;


        if (CheckDiagoanlMovement())
        {
            
            checkObstacle = true;
        }
        else
        {
            dashTimeDuration = 0.12f;
            checkObstacle = false;
        }

      

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (checkObstacle)
        {
            isObstacle = DetectingObstacle(lastMovementDirection, 5f);
            if(isObstacle)
            {
                dashTimeDuration = 0.3f;
            }
            else
            {
                dashTimeDuration = 0.15f;
            }
        }



        if (isDashing)
        {

            dashTime += Time.deltaTime;
            if (dashTime > dashTimeDuration)
            {

              

                isDashing = false;
                dashTime = 0.0f;
                stateMachine.ChangeState(_stateMachine.movingState);
                

            }

        }

       
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

       if(isDashing)
        {
            HandleDash(); 
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

    private void HandleDash()
    {
        _stateMachine.playerPhysics.Direction = lastMovementDirection;
        _stateMachine.playerPhysics.Speed = dashSpeed;
    }

    bool DetectingObstacle(Vector3 dir, float distance)
    {
        int layerMask = 1 << 6;


        layerMask = ~layerMask;

        RaycastHit2D hit;


        hit = Physics2D.Raycast(_stateMachine.transform.position, dir, distance, layerMask);

        if (hit.collider != null)
        {

            hitPoint = hit.point;

           // Debug.Log("hit.point: " + hit.point);
            Debug.DrawRay(_stateMachine.transform.position, dir * distance, Color.red);
            return true;

        }
        else
        {
            Debug.DrawRay(_stateMachine.transform.position, dir * distance, Color.green);
            return false;
        }



    }


    //void HandleVerticalAndHorizontalDash()
    //{


    //    _stateMachine.playerPhysics.Direction = lastMovementDirection;
    //    _stateMachine.playerPhysics.Speed = dashSpeed;

    //}

    //void HandleDiagonalDash()
    //{



    //// Debug.Log("DiagonalDash");

    //if (isObstacle(lastMovementDirection, 5f))
    //{
    //     dashTimeDuration = 0.3f;
    //    Vector3 displacementFromTarget = hitPoint - _stateMachine.transform.position;
    //    Vector3 directionToTarget = displacementFromTarget.normalized;

    //    float distanceToTarget = displacementFromTarget.magnitude;

    //    if (distanceToTarget > 1f)
    //    {

    //        _stateMachine.playerPhysics.Direction = directionToTarget;
    //        _stateMachine.playerPhysics.Speed = dashSpeed;

    //    }

    //}
    //else
    //{
    //   dashTimeDuration = 0.1f;

    //    _stateMachine.playerPhysics.Direction = lastMovementDirection;
    //}

    //}


}
