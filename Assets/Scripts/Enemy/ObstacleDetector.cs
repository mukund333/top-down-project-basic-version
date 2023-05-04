using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 2;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private bool showGizmos = true;

    [SerializeField] private Collider2D[] colliders;

    [SerializeField] private ContextData contextData;

    [SerializeField] private Vector2 directionToObstacle;

    private void Start()
    {
        contextData = transform.parent.Find("Data").GetComponent<ContextData>();

        InvokeRepeating("Detect", 0, 0.05f);
    }


    public void Detect()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
        contextData.obstacles = colliders;
    }




    private void OnDrawGizmos()
    {
        if (showGizmos == false)
            return;

        if (Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach (Collider2D obstacleCollider in colliders)
            {
                Gizmos.DrawSphere(obstacleCollider.transform.position, 0.2f);
            }
        }
    }

}
