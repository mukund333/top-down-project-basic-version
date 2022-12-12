using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithJoystickSimple : AimMechanicsWithJoystickBase
{
   
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        HandlingAim();

    }

    void HandlingAim()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        SetWeaponAngle(weaponAngleDegrees);

        WeaponSortingOrder(weaponAngleDegrees);


    }
}
