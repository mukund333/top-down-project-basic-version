using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IntersetContextCalculator : MonoBehaviour
{
    [SerializeField] private bool showGizmo = true;
    [SerializeField] private float[] interestsTemp;
    [SerializeField] private Vector3 targetPositionCached;

    [SerializeField] private ContextData contextData;

    [SerializeField] private float targetRechedThreshold = 0.5f;

    bool reachedLastTarget = true;



    private void Awake()
    {
        contextData = transform.parent.Find("Data").GetComponent<ContextData>();

    }

    private void Start()
    {

        InvokeRepeating("IntersetCalacalations", 0, 0.05f);
    }
    private void Update()
    {

    }


    private void IntersetCalacalations()
    {
        if (reachedLastTarget)
        {
            if (contextData.targets == null || contextData.targets.Count <= 0)
            {
                contextData.currentTarget = null;

            }
            else
            {
                reachedLastTarget = false;
                contextData.currentTarget = contextData.targets.OrderBy
                    (target => Vector2.Distance(target.position, transform.position)).FirstOrDefault();
            }

        }


        if (contextData.currentTarget != null && contextData.targets != null && contextData.targets.Contains(contextData.currentTarget))
            targetPositionCached = contextData.currentTarget.position;


        if (Vector2.Distance(transform.position, targetPositionCached) < targetRechedThreshold)
        {
            reachedLastTarget = true;
            contextData.currentTarget = null;



        }

        //If we havent yet reached the target do the main logic of finding the interest directions
        //Vector2 directionToTarget = target.transform.position - transform.position;

        Vector2 directionToTarget = targetPositionCached - transform.position;

        for (int i = 0; i < contextData.Interest.Length; i++)
        {
            float result = Vector2.Dot(directionToTarget.normalized, Directions.eightDirections[i]);


            if (result <= 0)
            {
                float valueToPutIn = result;
                if (valueToPutIn < contextData.Interest[i])
                {
                    contextData.Interest[i] = valueToPutIn;
                }
            }

            //accept only directions at the less than 90 degrees to the target direction
            if (result > 0)
            {
                float valueToPutIn = result;
                if (valueToPutIn > contextData.Interest[i])
                {
                    contextData.Interest[i] = valueToPutIn;
                }

            }
        }

        interestsTemp = contextData.Interest;
    }


    private void OnDrawGizmos()
    {

        if (showGizmo == false)
            return;


        if (Application.isPlaying && interestsTemp != null)
        {

            Gizmos.color = Color.green;
            for (int i = 0; i < interestsTemp.Length; i++)
            {
                Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * interestsTemp[i] * 2);
            }


        }
    }
}
