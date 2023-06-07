using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithMouseFlipWeapon : AimMechanicsWithMouseBase
{
    [SerializeField] private CurrentAimDirection currentAimDirection;
    [SerializeField] private FlipWeaponTransform flipWeaponTransform;
    public float weaponAngleDegrees;


   protected override void Awake()
    {
        base.Awake();
        currentAimDirection = GetComponent<CurrentAimDirection>();
        flipWeaponTransform = GetComponent<FlipWeaponTransform>();


    }

    protected void HandleMosueAiming()
    {
        Vector3 weaponDirection = GetWeaponDirection();

         weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        currentAimDirection.SetAimDirection(weaponAngleDegrees);

        flipWeaponTransform.FlipWeapon(currentAimDirection.GetAimDirection());

        SetWeaponAngle(weaponAngleDegrees);
        
        WeaponSortingOrder(weaponAngleDegrees);


    }

    private void Update()
    {
        HandleMosueAiming();
    }
}
