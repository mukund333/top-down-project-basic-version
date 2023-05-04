using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrafingBehavior : MonoBehaviour
{
    public float maxSpeed = 2f;

    [SerializeField] private float strafeRange;
    [SerializeField] private Rigidbody2D rb;
    private Transform player;
    private BehaviorsManager behaviorsManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        behaviorsManager = GetComponent<BehaviorsManager>();
    }

    public Vector2 Strafing()
    {
        strafeRange = behaviorsManager.strafeRange;


        Vector2 direction = (player.position - transform.position).normalized;

        if (Vector2.Distance(transform.position, player.position) < strafeRange)
        {

            Vector2 strafeDirection = new Vector2(direction.y, -direction.x).normalized;
            return strafeDirection * maxSpeed;

        }


        return Vector2.zero;

    }

}
