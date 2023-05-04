using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float maxSpeed, maxForce;



    [SerializeField] private List<GameObject> agents;


    private void Awake()
    {
        agents = new List<GameObject>(GameObject.FindGameObjectsWithTag("Agent"));

    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }




    public Vector2 Separate()
    {

        float desiredSeperation = transform.localScale.x * 2;

        Vector2 sum = Vector2.zero;
        int count = 0;

        foreach (GameObject agent in agents)
        {
            if (agent != gameObject)
            {

                float distance = Vector2.Distance(agent.transform.position, transform.position);

                if ((distance > 0) && (distance < desiredSeperation))
                {
                    Vector2 diff = transform.position - agent.transform.position;
                    diff.Normalize();

                    diff /= distance;

                    sum += diff;
                    count++;
                }

            }
        }


        if (count > 0)
        {
            sum /= count;

            sum *= maxSpeed;

            Vector2 steer = sum - rigidbody2D.velocity;
            steer = Vector2.ClampMagnitude(steer, maxForce);


            return steer;
        }
        return Vector2.zero;
    }
}
