using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Controller2D))]
public class Player : MonoBehaviour {

	
	public float jumpHeight = 3.5f; //how high the player jumps
	public float timeToJumpApex = .4f; //how long it takes to reach the jump apex
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	//public float wallSlideSpeedMax = 3;
	//public float wallStickTime = .25f;
	float timeToWallUnstick;
	public int wallDirX;

	float gravity;
	float jumpVelocity;
	public float moveSpeed = 6;
	float velocityXSmoothing;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	Vector2 input;
	Vector3 velocity;
	Controller2D controller;
	public PlayerStates playerState;
	public Transform pausecanvas; //to grab the canvas and display it

	

	void Start () {
		controller = GetComponent<Controller2D>();
		SetGravity();
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		Debug.Log("Gravity: " + gravity + " jumpVelocity: " + jumpVelocity);
	}

	void Update () {
		SetPlayerState();
		input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		wallDirX = (controller.collisions.left) ? -1:1;

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)? accelerationTimeGrounded:accelerationTimeAirborne);

		if(playerState == PlayerStates.onWall){
			StartCoroutine(WallStick());
		}

		if (controller.collisions.above || controller.collisions.below){
			velocity.y = 0;
		}
			
		if (Input.GetKeyDown (KeyCode.Space)){ //if space bar pressed and on ground, jump!
			if(playerState == PlayerStates.onWall){
				if(wallDirX != input.x){
					WallJump();
					}
				}
			if(controller.collisions.below){
				Jump();
				}

		}
		if(playerState != PlayerStates.onWall){
			velocity.y += gravity * Time.deltaTime;
			}

		controller.Move (velocity * Time.deltaTime);

		if (pausecanvas.gameObject.activeInHierarchy == false && Input.GetKeyDown (KeyCode.Escape)){
			Pause();
			}
	}

	void SetGravity(){
		gravity =  - (2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
	}

	void Jump(){
		velocity.y = jumpVelocity;
		Debug.Log ("Im Jumping!");
		Debug.Log (velocity.y.ToString ());
	}

	void WallJump(){
		velocity.x = -wallDirX * wallLeap.x;
		velocity.y = wallLeap.y;
	}

	IEnumerator WallStick(){
		velocity.y = 0;
		yield return new WaitForSeconds(2);
		}

	void Pause(){
		pausecanvas.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	void SetPlayerState(){
		if(controller.collisions.below && !controller.collisions.above){
			playerState = PlayerStates.walking;
		}
		else if(!controller.collisions.below && (!controller.collisions.right && !controller.collisions.left)){
			playerState = PlayerStates.jumping;
		}
		else if((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0){
			playerState = PlayerStates.onWall;
		}
	}
	public enum PlayerStates{
		walking,
		jumping,
		dead,
		ramming,
		onWall
	}
}
