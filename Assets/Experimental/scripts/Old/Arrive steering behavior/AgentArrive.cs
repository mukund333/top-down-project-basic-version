using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class AgentArrive : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float maxforce;
    [SerializeField] float maxspeed;
    [SerializeField] float mass;


    public LayerMask collisionMask;

    private GameObject enemyGameObject;
    private Rigidbody2D rb2d;

    private void Start()
    {
        enemyGameObject = this.gameObject;
        rb2d = enemyGameObject.AddComponent<Rigidbody2D>();

        rb2d.gravityScale = 0f;

    }


    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(
                         Mathf.Clamp(rb2d.velocity.x, -maxspeed, maxspeed),
                         Mathf.Clamp(rb2d.velocity.y, -maxspeed, maxspeed)
                        );

    }

    public void Arrive(Vector3 target)
    {

        Vector2 desired = target -  rb2d.transform.position;
        float distance = desired.magnitude;
        desired = desired.normalized;

        //desired = desired - new Vector2(2f,2f);

        if (distance < radius)
        {
            float m = math.remap(0f, 3f, 0, maxspeed, distance);
            desired *= m;
            
            //Debug.Log("near" + desired);
        }
        else
        {
            desired *= maxspeed;
            //Debug.Log("far" + desired);
        }

        Vector2 steer = desired - rb2d.velocity;
        //Debug.Log(steer);
        ApplyForce(steer);
        Debug.DrawLine(rb2d.transform.position, steer + (Vector2) rb2d.transform.position);
    }


    //Newton's second law
    //Receive a force, divide by mass, and add to acceleration
    public void ApplyForce(Vector2 force)
    {
        rb2d.AddForce(force * Time.fixedDeltaTime, ForceMode2D.Impulse);
        
    }

}
