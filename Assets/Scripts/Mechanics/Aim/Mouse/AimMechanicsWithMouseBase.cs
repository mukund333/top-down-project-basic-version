using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AimMechanicsWithMouseBase : AimMechanicsBase
{
    public Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();

    }

    // Get the mouse world position
    protected Vector3 GetMouseWolrdPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector3 mouseScreenPosition = Input.mousePosition;

        //Clamp mouse position to screen size
        mouseScreenPosition.x = Mathf.Clamp(mouseScreenPosition.x, 0f, Screen.width);
        mouseScreenPosition.y = Mathf.Clamp(mouseScreenPosition.y, 0f, Screen.height);

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

        worldPosition.z = 0f;

        return worldPosition;
    }

    protected Vector3 GetWeaponDirection()
    {
        Vector3 mouseWolrdPosition = GetMouseWolrdPosition();

        //  Vector3 weaponDirection = (mouseWolrdPosition - weaponRotationPointTransform.position).normalized;
        Vector3 weaponDirection = (mouseWolrdPosition - transform.position).normalized;

        return weaponDirection;
    }

   

}
