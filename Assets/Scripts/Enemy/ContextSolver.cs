using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextSolver : MonoBehaviour
{
    [SerializeField]
    private bool showGizmos = true;

    [SerializeField] private ContextData contextData;

    public Vector2 resultDirection = Vector2.zero;

    private float rayLength = 2;

    [SerializeField] private float[] interest = new float[8];

    private void Start()
    {
        contextData = transform.parent.Find("Data").GetComponent<ContextData>();

        InvokeRepeating("GetDirectionToMove", 0, 0.05f);
    }



    public void GetDirectionToMove()
    {




        //subtract danger values from interest array
        for (int i = 0; i < Directions.eightDirections.Count; i++)
        {
            interest[i] = Mathf.Clamp01(contextData.Interest[i] - contextData.Danger[i]);
            //interest[i] = contextData.Interest[i];
        }

        //get the average direction
        Vector2 outputDirection = Vector2.zero;
        for (int i = 0; i < Directions.eightDirections.Count; i++)
        {
            outputDirection += Directions.eightDirections[i] * interest[i];
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
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, resultDirection * rayLength);
        }
    }
}
