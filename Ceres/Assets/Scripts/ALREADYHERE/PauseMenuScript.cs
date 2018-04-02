using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {
	
	public Transform pausecanvas;
	public void OnClicck ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	} 
	public void OnButton ()
	{
		pausecanvas.gameObject.SetActive (false);
		Time.timeScale = 1;

	}

}
