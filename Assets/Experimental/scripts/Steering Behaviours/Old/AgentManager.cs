using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentManager : MonoBehaviour
{
   
    [SerializeField] GameObject Enemy;
    


    private AgentSeeker agent;
    private AgentArrive agent2;

    private void Start()
    {

         agent = Enemy.GetComponent<AgentSeeker>();
        //agent2 = Enemy.GetComponent<AgentArrive>();
    }

    private void FixedUpdate()
    {

        agent.Seek(this.transform.position);
        //agent2.Arrive(this.transform.position);


    }

    Vector2 MousePosition(Camera camera)
    {
        // Track the Vector2 of the mouse's position
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
