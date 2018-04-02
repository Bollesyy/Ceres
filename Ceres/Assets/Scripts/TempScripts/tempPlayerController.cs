using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerController : MonoBehaviour {

		float speed = 0.1f;


		void FixedUpdate(){
			if (Input.GetAxis("Horizontal") < 0) {
				MoveLeft ();
			}
			if(Input.GetAxis("Horizontal") > 0)
			{
				MoveRight ();
			}
			if (Input.GetButton("Jump"))
			{
				//Write Jump code here;
			}

		}

		void MoveLeft()
		{
			transform.position += new Vector3 (-speed, 0, 0);
		}

		void MoveRight()
		{
			transform.position += new Vector3 (speed, 0, 0);
		}

	public GameObject checkpoint;

	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Enemy")
		{

			this.gameObject.transform.position = checkpoint.transform.position; 

		}
	}
	}
