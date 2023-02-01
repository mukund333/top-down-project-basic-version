using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveExperments : MonoBehaviour
{
    public AnimationCurve animationCurve;

    [SerializeField] private float acc;
    [SerializeField] private float accTime;
    [SerializeField] private float agentVelocity;
    [SerializeField] private Vector2 lastDirection;

    public bool isTrust ;

    [SerializeField] private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isTrust = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isTrust = true;
        }
    }

    private void FixedUpdate()
    {
        if(isTrust)
        {
            isTrust = false;

            acc = acc + 1f / accTime * Time.deltaTime;

            rb2d.velocity = transform.right * (agentVelocity * animationCurve.Evaluate(acc));

            acc = Mathf.Clamp(acc, 0f, 1f);

            if (acc > 0f)
             {
                  acc = rb2d.velocity.magnitude / agentVelocity;
             }
        }
        
    }
}
