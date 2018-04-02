using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCreeper : MonoBehaviour {
	
	public bool MoveLeft;
	public bool moveRight;
	private float maxDist;
	private float minDist;
	public int distance = -1;
	public float movingSpeed = 1f;
	void Start () {
		MoveLeft = true;
		this.gameObject.transform.position = transform.position; 
		maxDist += transform.position.x;
		minDist -= transform.position.x;



	}
	void Update ()
	{

		if (MoveLeft == true)
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (-movingSpeed, GetComponent <Rigidbody2D> ().velocity.y);

		if (moveRight == true)
			GetComponent <Rigidbody2D> ().velocity = new Vector2 (movingSpeed, GetComponent <Rigidbody2D> ().velocity.y);
			

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Wall" && MoveLeft == true) {
			MoveLeft = false;
			moveRight = true;
			transform.localRotation = Quaternion.Euler(0, 180, 0);		}
		if (other.gameObject.tag == "RightWall" && moveRight == true) {
			moveRight = false;
			MoveLeft = true;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			if (other.gameObject.tag == "Player")
				Attack ();
		}
	}
	void Attack ()
	{

	}
		

}
