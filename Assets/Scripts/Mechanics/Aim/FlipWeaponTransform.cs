using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWeaponTransform : MonoBehaviour
{

    public void FlipWeapon(AimDirection aimDirection)
    {

        //Flip weapon transform based on player direction

        switch (aimDirection)
        {
            case AimDirection.Right:

                transform.localScale = new Vector3(1f, 1f, 0f);

                break;
            case AimDirection.Left:

                transform.localScale = new Vector3(1f, -1f, 0f);

                break;
        }

    }
}
