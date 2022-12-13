using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceDirection : MonoBehaviour
{
    public AimDirection faceDirection;

    private void Update()
    {
        FlipPlayerSprite(faceDirection);
    }

    //Flip player sprite transform based on player direction

    private void FlipPlayerSprite(AimDirection aimDirection)
    {
        switch (aimDirection)
        {
            case AimDirection.Right:

                
                transform.localScale = new Vector3(1f, 1f, 0f);

                break;
            case AimDirection.Left:

                
                transform.localScale = new Vector3(-1f, 1f, 0f);

                break;
        }
    }
}
