using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithMouseSimple : AimMechanicsWithMouseBase
{
   

    protected override void Awake()
    {
        base.Awake();
       
    }

    private void HandleMosueAiming()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        SetWeaponAngle(weaponAngleDegrees);

        WeaponSortingOrder(weaponAngleDegrees);
    }

    private void Update()
    {

        HandleMosueAiming();
    }

}

