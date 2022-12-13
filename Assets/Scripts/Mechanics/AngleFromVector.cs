using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleFromVector : MonoBehaviour
{
   [SerializeField] private float degrees = 0f;

    public float GetAngleFromVector()
    {
        return degrees;
    }


    public void SetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);

        float degrees = radians * Mathf.Rad2Deg;
    }
}
