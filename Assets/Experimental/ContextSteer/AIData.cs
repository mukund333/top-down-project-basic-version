
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData : MonoBehaviour
{
    public List<Transform> targets = null;
    public Collider2D[] obstacles = null;

    public Transform currentTarget;

    
   public float[] interest = new float[8];

  public float[] danger = new float[8];


    public int GetTargetsCount() => targets == null ? 0 : targets.Count;
}