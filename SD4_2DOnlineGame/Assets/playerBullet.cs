﻿using UnityEngine;
using System.Collections;

public class playerBullet : MonoBehaviour {
	
	
	float liveTime = 1.3f;
	//Vector3 target;
	//float angle;
	//Vector3 direction;
	public float damage;
	Vector3 dir;
	Vector3 sp;
	bool adjust = true;
	
	public GameObject player;
	public playercontroller playerScript;

	void Start () {
		
		//target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//direction = (target - transform.position);
		player = GameObject.FindGameObjectWithTag ("Player");	
		playerScript = player.GetComponent<playercontroller>();
		damage = playerScript.power;

		
		
		
		
	}
	
	
	void Update () {
		
		if (adjust == true) {
			sp = Camera.main.WorldToScreenPoint (transform.position);
			dir = (Input.mousePosition - sp).normalized;
			GetComponent<Rigidbody2D> ().AddForce (dir * 800);
			
			adjust = false;
		}
		
		
		
		liveTime -= Time.deltaTime;
		if (liveTime <= 0)
			Destroy (gameObject);
		
		
		
		
		
		//transform.position = Vector3.MoveTowards(transform.position, target, 18 * Time.deltaTime); // change13 to attack speed of player and time related to distance
		
		
		
		
		
	}
}
