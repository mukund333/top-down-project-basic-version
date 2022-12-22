using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementPhysics : MonoBehaviour
{

    [SerializeField] private float normalSpeed = 40f;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private PlayerMovementKeyboardInput keyboardInput;
    [SerializeField] private Dash dash;



    private void Awake()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;

        keyboardInput = GetComponent<PlayerMovementKeyboardInput>();
        dash = GetComponent<Dash>();
    }

    private void FixedUpdate()
    {
        if (!dash.isDashing)
        {
            rb2d.velocity = keyboardInput.moveDirection * normalSpeed * Time.fixedDeltaTime;
        }
    }


}
