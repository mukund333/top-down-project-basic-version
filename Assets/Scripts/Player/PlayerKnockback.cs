using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    Vector2 knockbackDirection;
    [SerializeField] private PlayerMovement playerMovement;

    bool isknockback;

    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;

    bool knockbackingCo;


    private Coroutine knockbackCoroutine;

    private void Awake()
    {
        playerMovement =  GetComponentInParent<PlayerMovement>();
        isknockback = false;
        knockbackingCo = false;
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy trigger");
           // Debug.Log(collision.gameObject.name);
            isknockback = true;
            knockbackDirection = (collision.transform.position - transform.position).normalized;

        }
    }

    private void FixedUpdate()
    {
        if (isknockback)
        {
            playerMovement.IsDiableInputs = true;
            playerMovement.Speed = knockbackForce;
            playerMovement.PlayerMovementDirection = -knockbackDirection;
           

            if(!knockbackingCo)
            {
                knockbackCoroutine = StartCoroutine(knockbackTimeCoroutine());
            }
        }
        else
        {
            playerMovement.IsDiableInputs = false;
        }
    }

    IEnumerator knockbackTimeCoroutine()
    {

        yield return new WaitForSeconds(knockbackTime);
        isknockback = false;
        knockbackingCo = false;

        StopCoroutine(knockbackTimeCoroutine());

    }


}
