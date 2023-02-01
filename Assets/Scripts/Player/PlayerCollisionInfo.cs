using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionInfo : MonoBehaviour
{
    [SerializeField] private bool isEnemyCollided ;
    [SerializeField] private Vector2 collisionDirection;
    public bool IsEnemyCollided { get { return isEnemyCollided; } set {isEnemyCollided = value; } }

    public Vector3 CollisionDirection { get { return collisionDirection; } }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
            isEnemyCollided = true;

            collisionDirection = collision.transform.position;

        }
    }
}