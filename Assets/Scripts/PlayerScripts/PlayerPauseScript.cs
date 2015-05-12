﻿using UnityEngine;
using System.Collections;

public class PlayerPauseScript : MonoBehaviour {

	public Canvas pauseCanvas;

	void Start () {
		pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<Canvas> ();
		pauseCanvas.gameObject.SetActive (false);
	}

	void Update () {

		//Pause the game when playing.
		if (Input.GetKeyDown (KeyCode.P)) {
			Pause ();
		}
	}

	void Pause(){

		if(Time.timeScale == 0){
			Time.timeScale = 1;
			AudioListener.volume = 1.0f;
			pauseCanvas.gameObject.SetActive(false);
		}
		else {
			Time.timeScale = 0;
			AudioListener.volume = 0.0f;
			pauseCanvas.gameObject.SetActive(true);
		}
	}

	public void RestartLevelFromPause(){
		Debug.Log("does this happen!!!!");
		//killAll ();
		//If the player wants to restart the level, the timeScale can not be 0
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			AudioListener.volume = 1.0f;
			Application.LoadLevel (Application.loadedLevel);
		} 
		else {
			Application.LoadLevel (Application.loadedLevel);
		}

	}

	void killAll(){
		Debug.Log("Kill everyone!!!!");
		Destroy (GameObject.FindWithTag ("Enemy1"));
		Destroy (GameObject.FindWithTag ("Enemy2"));
		Destroy (GameObject.FindWithTag ("Enemy3"));
		Destroy (gameObject);
	}

}