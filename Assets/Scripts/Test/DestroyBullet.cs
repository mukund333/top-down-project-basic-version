using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
   

    private void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
