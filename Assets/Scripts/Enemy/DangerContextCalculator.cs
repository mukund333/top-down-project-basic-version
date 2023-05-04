using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DangerContextCalculator : MonoBehaviour
{

    [SerializeField] private bool showGizmo = true;
    [SerializeField] private float[] dangerTemp;
    [SerializeField] private GameObject target;
    [SerializeField] private ContextData contextData;


    [SerializeField] private float radius = 2f;
    [SerializeField] private float agentColliderSize = 0.6f;

    private void Awake()
    {
        contextData = transform.parent.Find("Data").GetComponent<ContextData>();
        InvokeRepeating("DangerContextCalacalations", 0, 0.05f);

    }


    private void DangerContextCalacalations()
    {
        if (contextData.obstacles.Length == 0)
        {
            Array.Clear(contextData.Danger, 0, contextData.Danger.Length);
        }


        foreach (Collider2D obstacleCollider in contextData.obstacles)
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
                if (valueToPutIn > contextData.Danger[i])
                {
                    contextData.Danger[i] = valueToPutIn;
                }

                //if (valueToPutIn < contextData.Danger[i])
                //{
                //    contextData.Danger[i] = valueToPutIn;
                //}
            }

            dangerTemp = contextData.Danger;
        }

    }


    private void OnDrawGizmos()
    {

        if (showGizmo == false)
            return;


        if (Application.isPlaying && dangerTemp != null)
        {

            Gizmos.color = Color.red;
            for (int i = 0; i < dangerTemp.Length; i++)
            {
                Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * dangerTemp[i] * 2);
            }


        }
    }
}
