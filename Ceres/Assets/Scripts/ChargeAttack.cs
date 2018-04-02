using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour
	{
		private bool playerIsAttacking = false; // Bool which determines whether or not the player is in the Attack State; Is set to false;//
		private float attackTimer = 1; // Float for how long the box collider will stay on; set to 0.5;//
		private float attackCd = 0.5f; 
		public float chargeAttackTime = 0; // Float which tells how long the charge attack is being held; Is set to zero;//
		public Collider2D chargeAttackTrigger; // Grabs the BoxCollider2D from Child Game Object; Child Game Object is called "ChargeAttackTrigger";//


	void Start () 
		{
			chargeAttackTrigger.enabled = false; // Disables the Child Object's BoxCollider2D;//
		}


	void Update () 
		{

			if(Input.GetKey("f")) // If player presses the key "f";//
				{
					chargeAttackTime += Time.deltaTime; // The float variable chargeAttackTime will begin to count upwards relative of the function Time.deltaTime;
				}

			if(Input.GetKeyUp("f") && !playerIsAttacking && (chargeAttackTime > 2)) // If the player releases the "f" key after the chargeAttackTimer has gone past 2 and if the state of playerIsAttacking is false;//
				{
					playerIsAttacking = true; // playerIsAttacking becomes true;
					attackTimer = attackCd; // Timer for how long the Child GameObject's box collider is on is set to 0.5f;//
					chargeAttackTrigger.enabled = true; // The Child GameObject's BoxCollider2D becomes enabled;//
					GetComponent<Rigidbody2D>().velocity = new Vector2 (5, 1); // The player is moved forward;//
					chargeAttackTime = 0; // The float for chargeAttackTime is reset back to zero;//
				}

			if (Input.GetKeyUp ("f") && (chargeAttackTime < 2)) // If the "f" key is released before the chargeAttackTime has reached two;//
				{
					chargeAttackTime = 0; // The chargeAttackTime will be reset back to zero, and the charge will cancel;//
				}

			if (playerIsAttacking) // If the bool playerIsAttaking is true;//
				{
					if (attackTimer > 0)  //Check to see if the attackTimer is greater than zero
						{
							attackTimer -= Time.deltaTime; // If it is, attackTimer will decrease relative to the function Time.deltaTime;//
						} 
					else   // // If attackTimer is below 0;//
						{
							playerIsAttacking = false; // The Bool playerIsAttacking is set to false;//
							chargeAttackTrigger.enabled = false; // The Child GameObject's BoxCollider2D is set to false;/
						}
				}
		}
	}
	


