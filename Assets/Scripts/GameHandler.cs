using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform playerTransform;
    public CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow.Setup(() => playerTransform.position);
        cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position);
    }
}
