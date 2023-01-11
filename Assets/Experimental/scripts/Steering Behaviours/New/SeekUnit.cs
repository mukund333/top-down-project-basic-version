using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekUnit : MonoBehaviour
{
    public Transform target;

    [SerializeField] SteeringBasics steeringBasics;

    

    void Start()
    {
        steeringBasics = GetComponent<SteeringBasics>();
    }


    void FixedUpdate()
    {
        Vector3 accel = steeringBasics.Seek(target.position);

        steeringBasics.Steer(accel);
        
    }
}
