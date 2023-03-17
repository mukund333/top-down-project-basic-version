using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{

    [SerializeField]
    private bool showGizmos = true;

    [SerializeField] private AIData aiData;

    Vector2 resultDirection = Vector2.zero;

    private float rayLength = 2;

    private void Start()
    {
        aiData = GetComponent<AIData>();
    }

    private void Update()
    {
        GetDirectionToMove();
    }

    public void GetDirectionToMove()
    {
       
       


        //subtract danger values from interest array
        for (int i = 0; i < 8; i++)
        {
            aiData.interest[i] = Mathf.Clamp01(aiData.interest[i] - aiData.danger[i]);
        }

        //get the average direction
        Vector2 outputDirection = Vector2.zero;
        for (int i = 0; i < 8; i++)
        {
            outputDirection += Directions.eightDirections[i] * aiData.interest[i];
        }

        outputDirection.Normalize();

        resultDirection = outputDirection;

        ////return the selected movement direction
        //return resultDirection;

    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && showGizmos)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, resultDirection * rayLength);
        }
    }
}
