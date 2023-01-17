using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour
{
    [SerializeField] private Vector3 _inputDirection;
    [SerializeField] private Vector3 _lastInputDirection;
    [SerializeField] private bool _isDisableInput;
    public  Vector3 InputDirection
    {
        get { return _inputDirection; }
        set { _inputDirection = value; } 
    }
    public Vector3 LastInputDirection
    {
        get { return _lastInputDirection; }
       
    }

    public bool IsDisableInput
    {
        get { return _isDisableInput; }
        set { _isDisableInput = value; }
    }

    private float moveX = 0f;
    private float moveY = 0f;


    private void Start()
    {
        _lastInputDirection = InputDirection;
        _isDisableInput = false;
    }

    private void Update()
    {

        _lastInputDirection = InputDirection;

        if (!_isDisableInput)
            HandleMovementInput();

    }

    private void HandleMovementInput()
    {
        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }


        _inputDirection = new Vector3(moveX, moveY).normalized;

    }
}
