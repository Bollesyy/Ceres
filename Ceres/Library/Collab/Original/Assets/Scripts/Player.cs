﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 3.5f; //how high the player jumps
	public float timeToJumpApex = .4f; //how long it takes to reach the jump apex
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float jumpVelocity;
	float moveSpeed = 6;
	float velocityXSmoothing;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;



	Vector3 velocity;
	Controller2D controller;

	void Start () 
	{
		controller = GetComponent<Controller2D>();
		gravity =  - (2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		Debug.Log("Gravity: " + gravity + " jumpVelocity: " + jumpVelocity);
	}

	void Update () 
	{
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		int wallDirX = (controller.collisions.left) ? -1:1;
		if(Mathf.Sign(velocity.x) == -1){
			Debug.Log("Moving Left");
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		}
		else {
			Debug.Log("Moving Right");
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)? accelerationTimeGrounded:accelerationTimeAirborne);

		bool wallSliding = false;
		if((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0){
			wallSliding = true;

			if(velocity.y < -wallSlideSpeedMax){
				velocity.y = -wallSlideSpeedMax;
			}

			if(timeToWallUnstick > 0){
				velocityXSmoothing = 0;
				velocity.x = 0;
				if(input.x != wallDirX && input.x != 0){
				timeToWallUnstick -= Time.deltaTime;
				}
				else{
					timeToWallUnstick = wallStickTime;
				}
			}
			else{
				timeToWallUnstick = wallStickTime;
			}

		}
		if (controller.collisions.above || controller.collisions.below) 
		{
			velocity.y = 0;
		}
			
		

		if (Input.GetKeyDown (KeyCode.Space)) //if space bar pressed and on ground, jump!
		{
			if(wallSliding){
				if(wallDirX == input.x){
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				}
				else if(input.x == 0){
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				}
				else{
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				}
			}
			if(controller.collisions.below){
			velocity.y = jumpVelocity;
			Debug.Log ("Im Jumping!");
			Debug.Log (velocity.y.ToString ());}

		}
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime, input);
	}
}
