using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class magicBeam : MonoBehaviour 
		{
			public GameObject magicBeamClones;
			public float magicBeamForce = 200; // Creates a float for the force of the Magic Beam; Sets it to 200;//
			public Collider2D attackTrigger;

		void Update ()
			{
				if (Input.GetKeyDown ("g")) // If the  key "g" is pressed down;//
					{
						GameObject newMagicBeam = Instantiate (magicBeamClones, transform.position, transform.rotation); // Creates new GameObject named "newMagicBeam" and spawns it into the game;//
						newMagicBeam.GetComponent <Rigidbody2D> ().AddRelativeForce (new Vector2 (magicBeamForce, 0f)); // Grabs the RigidBody2D Componants of the newMagicBeam and adds a vector2;/
					} 
			}

		}



