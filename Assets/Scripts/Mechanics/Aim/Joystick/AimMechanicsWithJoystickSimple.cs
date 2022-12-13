using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithJoystickSimple : AimMechanicsWithJoystickBase
{
    [SerializeField] private CurrentAimDirection currentAimDirection;

    protected override void Awake()
    {
        base.Awake();
        currentAimDirection = GetComponent<CurrentAimDirection>();
    }

    private void Update()
    {
        HandlingAim();

    }

    void HandlingAim()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        currentAimDirection.SetAimDirection(weaponAngleDegrees);

        SetWeaponAngle(weaponAngleDegrees);

        WeaponSortingOrder(weaponAngleDegrees);


    }
}
