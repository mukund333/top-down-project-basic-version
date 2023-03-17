using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleAvoidanceBehaviour : MonoBehaviour
{
    [SerializeField]
    private float radius = 2f, agentColliderSize = 0.6f;

    [SerializeField] float[] danger = new float[8];

    [SerializeField]
    private bool showGizmo = true;

    //gizmo parameters
    [SerializeField]
    float[] dangersResultTemp = new float[8];

    [SerializeField] private AIData aiData;

    private void Start()
    {
        aiData = GetComponent<AIData>();
    }

    private void Update()
    {
        GetSteering();
    }
    private void GetSteering()
    {
        if (aiData.obstacles.Length == 0)
        {
            Array.Clear(danger, 0, danger.Length);
        }


        foreach (Collider2D obstacleCollider in aiData.obstacles)
        {

            //calculate Closest Obstacle
            Vector2 directionToObstacle
                = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;

            float distanceToObstacle = directionToObstacle.magnitude;

            //calculate weight based on the distance Enemy<--->Obstacle
            float weight
                = distanceToObstacle <= agentColliderSize
                ? 1
                : (radius - distanceToObstacle) / radius;

            Vector2 directionToObstacleNormalized = directionToObstacle.normalized;

            //Add obstacle parameters to the danger array
            for (int i = 0; i < Directions.eightDirections.Count; i++)
            {
                float result = Vector2.Dot(directionToObstacleNormalized, Directions.eightDirections[i]);

             

                float valueToPutIn = result * weight;

                //override value only if it is higher than the current one stored in the danger array
                if (valueToPutIn > danger[i])
                {
                    danger[i] = valueToPutIn;
                }

               

            }
            aiData.danger = danger;
            dangersResultTemp = danger;
        }
    }


    private void OnDrawGizmos()
    {
        if (showGizmo == false)
            return;

        if (Application.isPlaying)
        {
            //if (dangersResultTemp != null)
            //{
                Gizmos.color = Color.red;
                for (int i = 0; i < dangersResultTemp.Length; i++)
                {
                    Gizmos.DrawRay(
                        transform.position,
                        Directions.eightDirections[i] * dangersResultTemp[i] * 2
                        );
                }
            //}
        }

    }

}

public static class Directions
{
    public static List<Vector2> eightDirections = new List<Vector2>{
            new Vector2(0,1).normalized,
            new Vector2(1,1).normalized,
            new Vector2(1,0).normalized,
            new Vector2(1,-1).normalized,
            new Vector2(0,-1).normalized,
            new Vector2(-1,-1).normalized,
            new Vector2(-1,0).normalized,
            new Vector2(-1,1).normalized
        };
}
