using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackcharge : MonoBehaviour {

	public GameObject player;
	Collider2D a_collider;
	Collider2D b_collider;
	GameObject enemy1;


	void Start () {
		a_collider = GetComponent<Collider2D>();
		enemy1 = GameObject.FindGameObjectWithTag ("Enemy");
		b_collider = enemy1.GetComponent<Collider2D> ();
		GetComponent<Collider2D>();
		a_collider.enabled = false;


	}

	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetKeyDown("f"))
		{
			StartCoroutine (ChargeAttack ());
		}
	}
	IEnumerator ChargeAttack()
			{
		
				a_collider.enabled = true;
				player.transform.position += new Vector3 (5,0,0);
				yield return new WaitForSeconds (1);
				a_collider.enabled = false;

				
			}
			

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.gameObject.tag == "Enemy") {
			//b_collider.enabled = false;	
			Debug.Log ("nani");
			Destroy(GameObject.Find("enemy"), 5);
		}
	}
}
