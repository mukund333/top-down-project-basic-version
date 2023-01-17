using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionUpdaterThing : MonoBehaviour
{
   [SerializeField] Vector3 _lastPosition;

    void Update()
    {
        // get current position
        Vector3 currentPosition = transform.position;

        // do anything you need to with the positions
     //   DoStuff(currentPosition, _lastPosition);

        // set last to current so the next frame of Update() is ready
        _lastPosition = transform.position;
    }

    void Start()
    {
        // set initial value for lastPosition
        _lastPosition = transform.position;
    }
}
