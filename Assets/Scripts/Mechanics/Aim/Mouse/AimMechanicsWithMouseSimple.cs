using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithMouseSimple : AimMechanicsWithMouseBase
{
    [SerializeField] private CurrentAimDirection currentAimDirection;

    protected override void Awake()
    {
        base.Awake();
        currentAimDirection = GetComponent<CurrentAimDirection>();

    }

    private void HandleMosueAiming()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        currentAimDirection.SetAimDirection(weaponAngleDegrees);

        SetWeaponAngle(weaponAngleDegrees);

        WeaponSortingOrder(weaponAngleDegrees);
    }

    private void Update()
    {

        HandleMosueAiming();
    }

}

