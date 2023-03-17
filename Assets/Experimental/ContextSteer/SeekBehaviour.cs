using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : MonoBehaviour
{
    [SerializeField]
    private float targetDetectionRange = 5;

    [SerializeField]
    private LayerMask obstaclesLayerMask, playerLayerMask;

    [SerializeField]
    private float targetRechedThreshold = 0.5f;

    [SerializeField]
    float[] interest = new float[8];

    [SerializeField]
    private bool showGizmo = true;

    bool reachedLastTarget = true;

    public Transform targetPosition;
    private float[] interestsTemp;


    [SerializeField] private AIData aiData;

    private void Start()
    {
        aiData = GetComponent<AIData>();
    }


    void Awake()
    {
        targetPosition = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        GetSteering();
    }


    private void GetSteering()
    {

        



        Vector2 directionToTarget = (targetPosition.position - transform.position);

        RaycastHit2D hit =
               Physics2D.Raycast(transform.position, directionToTarget, targetDetectionRange, obstaclesLayerMask);

        //Make sure that the collider we see is on the "Player" layer
        if (hit.collider != null && (playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
        {
            Debug.DrawRay(transform.position, directionToTarget * targetDetectionRange, Color.magenta);
           
        }


        for (int i = 0; i < interest.Length; i++)
        {
            float result = Vector2.Dot(directionToTarget.normalized, Directions.eightDirections[i]);

            if(result <=0)
            {
                float valueToPutIn = result;
                if (valueToPutIn < interest[i])
                {
                    interest[i] = valueToPutIn;
                }
            }

            //accept only directions at the less than 90 degrees to the target direction
            if (result > 0)
            {
                float valueToPutIn = result;
                if (valueToPutIn > interest[i])
                {
                    interest[i] = valueToPutIn;
                }

            }
        }
        aiData.interest = interest;
        interestsTemp = interest;
    }


    private void OnDrawGizmos()
    {

        if (showGizmo == false)
            return;
        Gizmos.DrawSphere(targetPosition.position, 0.2f);

        if (Application.isPlaying && interestsTemp != null)
        {
            if (interestsTemp != null)
            {
                Gizmos.color = Color.green;
                for (int i = 0; i < interestsTemp.Length; i++)
                {
                    Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * interestsTemp[i] * 2);
                }
                if (reachedLastTarget == false)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(targetPosition.position, 0.1f);
                }
            }
        }
    }
}
