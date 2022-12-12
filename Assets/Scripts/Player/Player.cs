using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#region Require Component
[DisallowMultipleComponent]
[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
#endregion


public class Player : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer spriteRenderer; // is public modifier right ??
    [HideInInspector] public Animator animator; // is public modifier right ??


    private void Awake()
    {
        // Load components
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
}
