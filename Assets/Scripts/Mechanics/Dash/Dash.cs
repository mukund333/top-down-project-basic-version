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


    private void Awake()
    {
        keyboardInput = GetComponent<PlayerMovementKeyboardInput>();
        coolDown = GetComponent<CoolDown>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    //private void Update()
    //{
    //    if(Input.GetKey(KeyCode.Space))
    //    {
    //        isDashing = true;
    //    }
    //    if (Input.GetKey(KeyCode.L))
    //    {
    //        isDashing = false;
    //    }
    //}

    private void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space) && coolDown.isCool)
        {
            coolDown.isCool = false;
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
            lastMovementDirection = keyboardInput.moveDirection;

        if (!coolDown.isCool && isDashing)
        {
            rb2d.velocity = lastMovementDirection * dashSpeed * Time.fixedDeltaTime;

        }
        else if (coolDown.isCool)
        {
            isDashing = false;
        }
    }
}
