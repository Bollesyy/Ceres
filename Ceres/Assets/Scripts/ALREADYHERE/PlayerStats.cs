using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats: MonoBehaviour {

	[Range(0, 100)]
	public int health;
	[Range(0, 50)]
	public int mana;
	public Text healthText;
	public Text manaText;

	void Start () {
		SetStatText();
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "HealthPot"){
			Debug.Log("HealthPot");
			Destroy(other.gameObject);
			health += 50;
			SetStatText();
		}
		 if(other.gameObject.tag == "ManaPot"){
			Destroy(other.gameObject);
			mana += 25;
			SetStatText();
		}
	}

	public void SetStatText(){
		healthText.text = health.ToString();
		manaText.text = mana.ToString();
	}
}
