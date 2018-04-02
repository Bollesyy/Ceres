using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour {

	public LayerMask collisionMask;	
	public const float skinWidth = .015f;
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

	[HideInInspector]
	public BoxCollider2D collider;
	public RaycastOrigins raycastOrigins;
	
	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]	
	public float verticalRaySpacing;

public virtual void Awake()
	{
		collider = GetComponent<BoxCollider2D>();
		
	}

public virtual void Start(){
	CalculateRaySpacing();
}

public void UpdateRaycastOrigins()
	{
		Bounds bounds = collider.bounds; //get bounds of our collider
		bounds.Expand(skinWidth * - 2); //shrink the bounds so it is inset by skinWidth

		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}
public void CalculateRaySpacing()
	{
		Bounds bounds = collider.bounds;
		bounds.Expand(skinWidth * - 2);

		//making sure the rayCounts are >= 2, need one in each corner
		horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

		//spacing in between 2 rays = entire length of bounds
		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing =  bounds.size.x / (verticalRayCount - 1);
	}

public struct RaycastOrigins //corners of the boxCollider
	{
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}

public struct CollisionInfo
	{
		public bool above, below;
		public bool left, right;
		public bool climbingSlope;
		public bool descendingSlope;
		public float slopeAngle, slopeAngleOld;
		public Vector3 velocityOld;

		public void Reset()
		{
			above = below = false;
			left = right = false;
			climbingSlope = false;
			descendingSlope = false;

			slopeAngleOld = slopeAngle;
			slopeAngle = 0;
		}
	}
}
