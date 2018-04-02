using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCreeper : MonoBehaviour {
	public bool inRange;
	PlayerStats health; 
	void Start ()
	{	
		health = FindObjectOfType<PlayerStats> ();
		inRange = false; 

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			StartCoroutine(Attack ());
			inRange = true;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player")
			inRange = false;
		}
	IEnumerator Attack () 
	{
		yield return new WaitForSeconds (.5f);
		if (inRange){
			health.health -= 10;
			health.SetStatText ();
			Debug.Log("Ouch");
		}

	}
}
