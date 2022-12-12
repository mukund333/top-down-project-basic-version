using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceDirection : MonoBehaviour
{
   // event based code

   [SerializeField] private AimDirection aimDirection = AimDirection.Right;

    [SerializeField] private int FacingDirection = 1;

    private void Update()
    {

        if (aimDirection == AimDirection.Right)
        {
            FacingDirection = 1;
        }
        else if (aimDirection == AimDirection.Left)
        {
            FacingDirection = -1;
        }

        Flip();
    }

    protected void Flip()
    {     
        Vector3 theScale = transform.localScale;
        theScale.x = FacingDirection;
        transform.localScale = theScale;
    }
}
