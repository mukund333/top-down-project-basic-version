using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public ColliderController colliderController;

    private void Awake()
    {
        colliderController = GetComponent<ColliderController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Disabling circle collider...");
            colliderController.col.enabled = false;
            Debug.Log("Circle collider disabled.");
        }
    }
}
