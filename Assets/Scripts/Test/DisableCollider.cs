using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollider : MonoBehaviour
{

    public CircleCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collider.enabled = false;
        }
    }
}
