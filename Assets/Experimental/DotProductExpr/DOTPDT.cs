using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTPDT : MonoBehaviour
{

   public Vector3 worldPosition;


    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
