using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimMechanicsWithJoystickBase : AimMechanicsBase
{

    [SerializeField] private AimJoystick aimJoystickInput;
    
    protected override void Awake()
    {
        base.Awake();
        aimJoystickInput = GameObject.Find("AimJoystick").GetComponent<AimJoystick>();
    }

    protected Vector3 GetWeaponDirection()
    {
        Vector3 weaponDirection = new Vector2(aimJoystickInput.Horizontal, aimJoystickInput.Vertical);

        return weaponDirection;
    }

}
