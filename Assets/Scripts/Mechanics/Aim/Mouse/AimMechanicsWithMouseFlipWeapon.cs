using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithMouseFlipWeapon : AimMechanicsWithMouseBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected void HandleMosueAiming()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        weaponAimDirection = GetAimDirection(weaponAngleDegrees);

        SetWeaponAngle(weaponAngleDegrees);

        FlipWeaponTransform(weaponAimDirection);

        WeaponSortingOrder(weaponAngleDegrees);

        WeaponSortingOrder(weaponAngleDegrees);
    }

    private void Update()
    {
        HandleMosueAiming();
    }
}
