using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    [SerializeField] private float dashDistance = 100f;
    [SerializeField] private PlayerMovementKeyboardController keyboardController;
    [SerializeField] private Vector3 moveDirection;
   
    private void Awake()
    {
        keyboardController = GetComponent<PlayerMovementKeyboardController>();
    }

   


    private bool CanMove(Vector3 dir, float distance)
    {
        bool isMove = true;
        //int layerMask = LayerMask.GetMask("Player");
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6 (player layer).
        // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.

        layerMask = ~layerMask;

        RaycastHit2D hit;
       
        //Get the first object hit by the ray
        hit = Physics2D.Raycast(transform.position, dir, distance,layerMask);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            isMove = false;
            
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
            Debug.DrawRay(transform.position, dir * distance, Color.red);
           
        }
        else
        {
            isMove = true;
        }

     
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, dir*distance, Color.green);

        Debug.Log(isMove);
        return isMove;
    }

   

    private void Update()
    {
        HandleDash();


       // Debug.DrawRay(transform.position, transform.position + Vector3.right , Color.green);
    }
    private void HandleDash()
    {

        //moveDirection = keyboardController.lastMoveDirection;

        
       
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position += keyboardController.lastMoveDirection * dashDistance;
            TryMove(keyboardController.lastMoveDirection, dashDistance);


        }
    }


    private bool TryMove(Vector3 baseMoveDir, float distance)
    {
        Vector3 moveDir = baseMoveDir;

        bool canMoveable = CanMove(moveDir, distance);
      //  Debug.Log(canMoveable);
        if (!canMoveable)
        {
            // Cannot move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMoveable = moveDir.x != 0 && CanMove(moveDir, distance);
            if (!canMoveable)
            {
                
                   // Cannot move horizonatally
                 moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMoveable = moveDir.y != 0f && CanMove(moveDir, distance);
              
            }
        }


        if (canMoveable)
        {
            keyboardController.lastMoveDirection = moveDir;
            transform.position += moveDir * distance;
            // Debug.Log("true");
            return true;
          
        }
        else
        {
            
            // Debug.Log("false");
            return false;
           
        }

    }

}
