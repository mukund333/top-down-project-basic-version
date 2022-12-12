using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithJoystickFlipWeapon : AimMechanicsWithJoystickBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        HandlingAim();

    }

    private void HandlingAim()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        weaponAimDirection = GetAimDirection(weaponAngleDegrees);

        SetWeaponAngle(weaponAngleDegrees);

        FlipWeaponTransform(weaponAimDirection);

        WeaponSortingOrder(weaponAngleDegrees);
    }
}
