using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimMechanicsBase : MonoBehaviour
{
   

    [SerializeField] protected Transform weaponRotationPointTransform;

    [SerializeField] protected AimDirection weaponAimDirection = AimDirection.Right;

    [SerializeField] protected SpriteRenderer spriteRenderer;


    protected virtual void Awake()
    {
        weaponRotationPointTransform = GameObject.Find("Aim").transform;
        spriteRenderer = GameObject.Find("Weapon").GetComponent<SpriteRenderer>();
        
       
    }

    // Get the angle in degrees from adirection vector
    public float GetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);

        float degrees = radians * Mathf.Rad2Deg;

        return degrees;
    }

    //Get AimDirection enum value from passed in angleDegrees
    public AimDirection GetAimDirection(float angleDegrees)
    {
        AimDirection aimDirection = AimDirection.Right;

        
         if(angleDegrees < -90f )
        {
            aimDirection = AimDirection.Left;

        }else if(angleDegrees > 90f)
        {
            aimDirection = AimDirection.Left;
        }
        else
        {
            aimDirection = AimDirection.Right;
        }

        return aimDirection;
    }

    // set angle of weapon transform

    protected void SetWeaponAngle(float aimAngle)
    {
        weaponRotationPointTransform.eulerAngles = new Vector3(0f, 0f, aimAngle);
    }

    //Aim the Weapon
    protected void FlipWeaponTransform(AimDirection aimDirection)
    {
        
        //Flip weapon transform based on player direction

        switch (aimDirection)
        {
            case AimDirection.Right:

                weaponRotationPointTransform.localScale = new Vector3(1f,1f,0f);

                break;
            case AimDirection.Left:

                weaponRotationPointTransform.localScale = new Vector3(1f, -1f, 0f);

                break;
        }

    }

    protected void WeaponSortingOrder(float angleDegrees)
    {

        if(angleDegrees > 35f && angleDegrees < 145f)
        {
            spriteRenderer.sortingOrder = 1;
        }
        else
        {
            spriteRenderer.sortingOrder = 2;
        }

        
    }

}
