using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCreeper : MonoBehaviour {

	public float speed;
	public Transform player;
	public Transform startingPoint;

	bool playerInRange;

	void FixedUpdate () {
		if(playerInRange){
			Attack();
		}
		else{
			StopAttackingAndReturn();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Debug.Log("Player Detected");
			playerInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			playerInRange = false;
		}
	}
	
	void Attack(){
		Debug.Log("Attacking");
		gameObject.transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}

	void StopAttackingAndReturn(){
		Debug.Log("Returning");
		gameObject.transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);	
	}
}
