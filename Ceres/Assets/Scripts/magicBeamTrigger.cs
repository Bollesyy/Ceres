﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBeamTrigger : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.isTrigger != true && col.CompareTag("enemy"))
		{
			Destroy(GameObject.FindGameObjectWithTag("enemy"));
		}
	}
}
