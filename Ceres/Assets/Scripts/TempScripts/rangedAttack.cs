using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttack : MonoBehaviour {


	public Rigidbody2D rb2D;
	// Use this for initialization
	void Start (){

		rb2D = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("g"))
			{
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right);
			if (hit.collider == GameObject.FindGameObjectWithTag("Enemy"))
				{
					Debug.Log("I hit him!");
				}
			}
		
	}



}
