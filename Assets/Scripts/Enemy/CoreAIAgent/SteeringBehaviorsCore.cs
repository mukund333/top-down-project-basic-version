using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class SteeringBehaviorsCore : MonoBehaviour
{
   
    //class members
    [SerializeField] private float maxSteeringVelocity;
    [SerializeField] private float maxAcceleration;

    // mutators
    public float MaxSteeringVelocity
    {
        get { return maxSteeringVelocity; }
        set { maxSteeringVelocity = value; }
    }
    public float MaxAcceleration { 
        get { return maxAcceleration; } set { maxAcceleration = value; } }

    // required component
    [SerializeField] private Rigidbody2D rigidbody2d;
  
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    public void Steer(Vector3 linearAcceleration)
    {
        rigidbody2d.velocity += (Vector2)linearAcceleration * Time.deltaTime;

        if (rigidbody2d.velocity.magnitude > maxSteeringVelocity)
        {
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * maxSteeringVelocity;
        }
    }

    public float GetTargetDistance(Vector3 targetPosition)
    {

        Vector3 targetVelocity = targetPosition - transform.position;


        return targetVelocity.magnitude;
    }


    public Vector3 Seek(Vector3 targetPosition, float maxSeekAccel)
    {
        /* Get the direction */
        Vector3 acceleration = targetPosition - transform.position;

        acceleration.Normalize();

        /* Accelerate to the target */
        acceleration *= maxSeekAccel;



        return acceleration;
    }

    public Vector3 Seek(Vector3 targetPosition)
    {


        return Seek(targetPosition, maxAcceleration);

    }
}
