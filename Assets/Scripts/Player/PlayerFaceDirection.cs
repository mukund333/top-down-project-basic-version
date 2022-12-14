using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceDirection : MonoBehaviour
{
    [SerializeField] private CurrentAimDirection currentAimDirection;

    private void Awake()
    {
        currentAimDirection = GameObject.Find("Aim").GetComponent<CurrentAimDirection>();
    }

    private void Update()
    {
        FlipPlayerSprite(currentAimDirection.GetAimDirection());
    }

    //Flip player sprite transform based on player direction

    private void FlipPlayerSprite(AimDirection aimDirection)
    {
        switch (aimDirection)
        {
            case AimDirection.Right:

                
                transform.localScale = new Vector3(-1f, 1f, 0f);

                break;
            case AimDirection.Left:

                
                transform.localScale = new Vector3(1f, 1f, 0f);

                break;
        }
    }
}
