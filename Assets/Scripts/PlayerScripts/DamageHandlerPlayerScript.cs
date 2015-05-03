﻿using UnityEngine;
using System.Collections;

public class DamageHandlerPlayerScript : MonoBehaviour {
	
	public int health = 2;
	public float invulnerabilityTimer = 0;
	public AudioClip sinkShip;
	public Canvas defeatCanvas;
	public Canvas winningCanvas;
	public float xCoordinate;
	public float yCoordinate;
	public bool secondCannon = false;

	GameObject player;                          // Reference to the player GameObject.
	PlayerHealthScript playerHealth;

	int layer;
	
	void Start() {
		if (player == null) {
			GameObject go = GameObject.Find ("Player");
			
			if(go != null) {
				player = go;
				playerHealth = player.GetComponent <PlayerHealthScript> ();
			}
		}


		defeatCanvas = defeatCanvas.GetComponent<Canvas> ();
		winningCanvas = winningCanvas.GetComponent<Canvas> ();
		defeatCanvas.enabled = false;
		winningCanvas.enabled = false;
		GameObject cannon = GameObject.Find ("Cannon2");
		cannon.SetActive (secondCannon);
		layer = gameObject.layer;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "EnemyBullet(Clone)") {
			health--;
			invulnerabilityTimer = 2f;
			gameObject.layer = 11;
		}
	}
	
	void Update() {
		invulnerabilityTimer -= Time.deltaTime;
		
		if (invulnerabilityTimer <= 0) {
			gameObject.layer = layer;
		}
		
		if (health <= 0) {
			Die ();
		}

		if (GameObject.Find ("Enemy(Clone)") == null) {
			Destroy (gameObject);
			winningCanvas.enabled = true;
		}
	}
	
	void Die() {
		Destroy (gameObject);
		defeatCanvas.enabled = true;
	}
}