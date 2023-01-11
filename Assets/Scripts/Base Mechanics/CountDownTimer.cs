using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{

    public bool  isCounting;
    public float timer;

    [SerializeField] private float countTime;
    

    private void Awake()
    {
        isCounting = false;
        countTime = 0.0f;
    }

   private void Update()
    {

        if (isCounting)
        {

            countTime += Time.deltaTime;
            if (countTime > timer)
            {
                isCounting = false;
                countTime = 0.0f;
                
            }
        }
    }

}
