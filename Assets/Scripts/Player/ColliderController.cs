using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public CircleCollider2D col;

    private void Awake()
    {
        col = GetComponent<CircleCollider2D>();
    }

    public void SetColliderEnabled(bool enabled)
    {
        col.enabled = enabled;

        Debug.Log(col.enabled);
    }
}
