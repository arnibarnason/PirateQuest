﻿using UnityEngine;
using System.Collections;

public class FirstSceneScript : MonoBehaviour {

	public AudioSource firstAudio;

	// Use this for initialization
	void Start () {
		firstAudio = firstAudio.GetComponent<AudioSource>();
	}

	public void pressContinue() {
		Application.LoadLevel ("PirateTalk");
	}

	public void pressSkip () {
		Application.LoadLevel ("LevelSelection");
	}

	void Update () {

	}
}
