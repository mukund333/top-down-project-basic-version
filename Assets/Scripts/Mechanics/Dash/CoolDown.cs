using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    [HideInInspector]
    public float cooldownTimer = 0.5f;
    [SerializeField] private float cooldownTime;
    public bool isCool = true;

    void Start()
    {
        cooldownTime = 0.0f;
    }


    private void Update()
    {

        if (!isCool)
        {

            cooldownTime += Time.deltaTime;
            if (cooldownTime > cooldownTimer)
            {
                isCool = true;
                cooldownTime = 0.0f;

            }
        }
    }

}
