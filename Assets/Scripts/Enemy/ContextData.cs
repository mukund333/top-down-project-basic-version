using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextData : MonoBehaviour
{
    // calculate 8 values becouse --->Our dot product calculations are based on a fixed 8-direction approach

    [SerializeField] private float[] danger = new float[8];
    [SerializeField] private float[] interest = new float[8];

    [SerializeField] private float[] dangerSeparation = new float[8];



    public float[] Interest { get { return interest; } set { interest = value; } }
    public float[] Danger { get { return danger; } set { danger = value; } }

    public float[] DangerSeparation { get { return dangerSeparation; } set { dangerSeparation = value; } }



    public Collider2D[] obstacles = null;
    public List<Transform> targets = null;

    public Transform currentTarget;

    public int GetTargetsCount() => targets == null ? 0 : targets.Count;

}
