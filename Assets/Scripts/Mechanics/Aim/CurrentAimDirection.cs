using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAimDirection : MonoBehaviour
{

    /// <summary>
    /// try to make event based...class
    /// </summary>


    [SerializeField] private AimDirection aimDirection = AimDirection.Right;

    
   
    public AimDirection GetAimDirection()
    {
        return aimDirection;
    }
    public void SetAimDirection(float angleDegrees)
    {
        
        if (angleDegrees < -90f)
        {
            aimDirection = AimDirection.Left;

        }
        else if (angleDegrees > 90f)
        {
            aimDirection = AimDirection.Left;
        }
        else
        {
            aimDirection = AimDirection.Right;
        }

       
    }
}
