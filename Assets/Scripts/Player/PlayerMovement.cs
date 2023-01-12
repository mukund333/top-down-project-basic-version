using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerPhysics))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardInput    keyboardInput;
    [SerializeField] private PlayerPhysics          playerPhysics;
  


    [SerializeField] private Vector3                playerMovementDirection;
   

    [SerializeField] private bool                   isDiableInputs;
    
    [SerializeField] private float normalSpeed;
    [SerializeField] private float speed; 
    
    
    
    
    public float Speed {
        get {return speed; } set {speed=value; } 
    }

    public Vector3 PlayerMovementDirection  {    get {return playerMovementDirection; } 
                                                 set {playerMovementDirection = value;} 
                                            }
   
    public bool IsDiableInputs
    {
        get { return isDiableInputs; }
        set { isDiableInputs = value; }
    }



    private void Awake()
    {
        keyboardInput = GetComponent<PlayerKeyboardInput>();
        playerPhysics = GetComponent<PlayerPhysics>();
       

        PlayerMovementDirection = Vector3.zero;
       
    }

    private void Update()
    {
        if(!isDiableInputs)
        {
            PlayerMovementDirection = keyboardInput.InputDirection;
            HandleMovementDirection(PlayerMovementDirection,normalSpeed);
        }
        else
        {
            HandleMovementDirection(PlayerMovementDirection, Speed);
        }
    }

    private void HandleMovementDirection(Vector3 direction, float speed)
    {
        playerPhysics.Direction = direction;
        playerPhysics.Speed = speed;
    }






}
