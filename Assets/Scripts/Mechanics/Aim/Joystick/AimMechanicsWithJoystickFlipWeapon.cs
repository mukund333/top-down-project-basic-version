using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMechanicsWithJoystickFlipWeapon : AimMechanicsWithJoystickBase
{
    [SerializeField] private CurrentAimDirection currentAimDirection;
    [SerializeField] private FlipWeaponTransform flipWeaponTransform;
    protected override void Awake()
    {
        base.Awake();
        currentAimDirection = GetComponent<CurrentAimDirection>();
        flipWeaponTransform = GetComponent<FlipWeaponTransform>();
    }

    private void HandlingAim()
    {
        Vector3 weaponDirection = GetWeaponDirection();

        float weaponAngleDegrees = GetAngleFromVector(weaponDirection);

        currentAimDirection.SetAimDirection(weaponAngleDegrees);

        flipWeaponTransform.FlipWeapon(currentAimDirection.GetAimDirection());

        SetWeaponAngle(weaponAngleDegrees);
        
        WeaponSortingOrder(weaponAngleDegrees);
    }


    private void Update()
    {
        HandlingAim();

    }

}
