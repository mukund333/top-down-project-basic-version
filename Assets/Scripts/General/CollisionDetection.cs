using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionDetection : MonoBehaviour
{
	public LayerMask collisionMask;


	const float skinWidth = .015f;
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

	float horizontalRaySpacing;
	float verticalRaySpacing;

	BoxCollider2D boxCollider2D;
	RaycastOrigins raycastOrigins;
	public CollisionInfo collisionInfo;



	public float rayLength = 10f;


	void Start()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();
		CalculateRaySpacing();
	}

	void Update()
	{
		collisionInfo.Reset();
		UpdateRaycastOrigins();
		VerticalCollisions();
		HorizontalCollisions();


		Debug.Log("collision below :" + collisionInfo.below);
		Debug.Log("collision above :" + collisionInfo.above);
		Debug.Log("collision left :" + collisionInfo.left);
		Debug.Log("collision right :" + collisionInfo.right);

	}

	void VerticalCollisions()
	{
		//collisionInfo.Reset();

		// Bottom rays
		for (int i = 0; i < verticalRayCount; i++)
		{


			Vector2 rayOrigin = raycastOrigins.bottomLeft + Vector2.right * verticalRaySpacing * i;

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.green);

			if (hit.collider != null)
			{
				//Debug.Log("Hitting: " + hit.collider.tag);
				Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red);

				collisionInfo.below = true;
			}
		}

		//Top rays

		for (int i = 0; i < verticalRayCount; i++)
		{
			Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * verticalRaySpacing * i;

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.green);

			if (hit.collider != null)
			{
				//Debug.Log("Hitting: " + hit.collider.tag);
				Debug.DrawRay(rayOrigin, Vector2.up * rayLength, Color.red);

				collisionInfo.above = true;
			}
		}


	}

	void HorizontalCollisions()
	{
		//collisionInfo.Reset();

		//left rays

		for (int i = 0; i < horizontalRayCount; i++)
		{
			Vector2 rayOrigin = raycastOrigins.bottomLeft + Vector2.up * verticalRaySpacing * i;

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.left, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.left * rayLength, Color.green);

			if (hit.collider != null)
			{
				//Debug.Log("Hitting: " + hit.collider.tag);
				Debug.DrawRay(rayOrigin, Vector2.left * rayLength, Color.red);

				collisionInfo.left = true;
			}
		}


		// right rays

		for (int i = 0; i < horizontalRayCount; i++)
		{
			Vector2 rayOrigin = raycastOrigins.bottomRight + Vector2.up * verticalRaySpacing * i;

			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLength, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * rayLength, Color.green);

			if (hit.collider != null)
			{
				//Debug.Log("Hitting: " + hit.collider.tag);
				Debug.DrawRay(rayOrigin, Vector2.right * rayLength, Color.red);

				collisionInfo.right = true;
			}
		}

	}

	void UpdateRaycastOrigins()
	{
		Bounds bounds = boxCollider2D.bounds;
		bounds.Expand(skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	void CalculateRaySpacing()
	{
		Bounds bounds = boxCollider2D.bounds;
		bounds.Expand(skinWidth * -2);

		horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}

	struct RaycastOrigins
	{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

	public struct CollisionInfo
	{
		public bool above, below;
		public bool left, right;

		public void Reset()
		{
			above = below = false;
			left = right = false;
		}
	}
}
