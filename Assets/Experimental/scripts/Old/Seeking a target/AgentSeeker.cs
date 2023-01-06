using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSeeker : MonoBehaviour
{
    [SerializeField] float r;
    [SerializeField] float maxforce;
    [SerializeField] float maxspeed;
    [SerializeField] float mass;


   

    //[SerializeField] float vehicleRotationAngle;


    private GameObject enemyGameObject;
    private Rigidbody2D rb2d;

    private void Start()
    {
        enemyGameObject = this.gameObject;
        rb2d = enemyGameObject.AddComponent<Rigidbody2D>();


        //maxspeed = 4.0f;
        //maxforce = 1f;

        r = 1.0f;
      //  mass = (4 / 3) * Mathf.PI * (Mathf.Pow(r, 3));

        rb2d.mass = mass;
        rb2d.drag = 0;
        rb2d.gravityScale = 0f;

    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector3(
           Mathf.Clamp(rb2d.velocity.x, -maxspeed, maxspeed),
           Mathf.Clamp(rb2d.velocity.y, -maxspeed, maxspeed));
    }  


    public void Seek(Vector3 target)
    {
       

        Vector2 desired = target - rb2d.transform.position;
        desired.Normalize();
        desired *= maxspeed;
        Vector3 steer = desired - rb2d.velocity;
        Debug.Log(desired);
        steer.x = Mathf.Clamp(steer.x, -maxforce, maxforce);
        steer.y = Mathf.Clamp(steer.y, -maxforce, maxforce);

        //return steer;

        ApplyForce(steer);
    }

    //Newton's second law
    //Receive a force, divide by mass, and add to acceleration
    public void ApplyForce(Vector2 force)
    {
        rb2d.AddForce(force * Time.fixedDeltaTime, ForceMode2D.Impulse);
       // CalculateVehicleRoatation(body.velocity);
    }

}
