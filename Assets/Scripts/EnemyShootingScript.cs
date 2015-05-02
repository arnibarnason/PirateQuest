﻿using UnityEngine;
using System.Collections;


public class EnemyShootingScript : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

	public GameObject bulletPrefab;

	public AudioClip gunShot;

	Transform Player;

	public float fireDelay = 0.5f;

	float coolDownTimer = 0;
	
	// Update is called once per frame
	void Update () {




		if (Player == null) {
			GameObject go = GameObject.Find ("Player");
			
			if(go != null) {
				Player = go.transform;
			}
		}	
		
		if (Player == null) {
			return;
		}
		 
		float distance = Vector3.Distance (Player.position, transform.position);

		coolDownTimer -= Time.deltaTime;

		//Only shoot within a certain distance
		if (distance < 10) {
			if (coolDownTimer <= 0) {

				coolDownTimer = fireDelay;

				Vector3 offset = transform.rotation * bulletOffset;

				GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
				AudioSource.PlayClipAtPoint(gunShot, transform.position);
				bulletGO.layer = gameObject.layer;

			}
		}

	}
}
