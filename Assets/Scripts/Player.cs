﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int health = 100;
	public float speed = 5;
	public float jumpSpeed = 5;
	public float deadZone = -3;
	public bool canFly = false;

	private weapon currentWeapon;
	private List<weapon> weapons = new List<weapon> ();

	new Rigidbody2D rigidbody;
	GM _GM ;
	private Vector3 startingPosition;

	private Animator anim;
	private bool air;
	private SpriteRenderer sr;


	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<GM> ();

		anim = GetComponent<Animator> ();
		air = true;
		sr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//apply movement
		float x = Input.GetAxisRaw ("Horizontal");
		Vector2 v = rigidbody.velocity;
		v.x = x * speed;

		if (v.x != 0) {
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}

		if (v.x > 0) {
			sr.flipX = false;
		} else if (v.x < 0) {
			sr.flipX = true;
		}

		if (Input.GetButtonDown ("Jump") && (v.y == 0 || canFly) ) {
			v.y = jumpSpeed;
		}


		if (v.y != 0) {
			anim.SetBool ("inAir", true);
		} else {
			anim.SetBool ("inAir", false);
		}


		rigidbody.velocity = v;

		//Attack with a weapon if you have one
		if (Input.GetButtonDown ("Fire1") && currentWeapon != null) {
			currentWeapon.Attack ();
		}

		if (Input.GetButtonDown ("Fire2")) {
			int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
			SetCurrentWeapon (weapons[i]);
		}


		//check for out
		if (transform.position.y < deadZone) {
			Debug.Log ("Current Position" + transform.position.y + "is lower than" + deadZone);
			GetOut ();
		}

		//rigidbody.AddForce (new Vector2 (x * speed, 0));

	}
	public void GetOut() {
		_GM.SetLives (_GM.GetLives() - 1);
		transform.position = startingPosition; 
		Debug.Log ("You're Out");
	}

	public void Powerup(){
		anim.SetTrigger ("powered");
	}

	public void AddWeapon(weapon w){
		weapons.Add (w);
		SetCurrentWeapon (w);
	}

	public void SetCurrentWeapon(weapon w){
		if (currentWeapon != null) {
			currentWeapon.gameObject.SetActive (false);
		}
		currentWeapon = w;

		if (currentWeapon != null) {
			currentWeapon.gameObject.SetActive (true);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		air = false;
		Debug.Log ("anything");
	
		var weapon = coll.gameObject.GetComponent<weapon> ();
		if (weapon != null) {
			weapon.GetPickedUp(this);

		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		air = true;
		if (collision.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
	void OnCollisionStay2D (Collision2D collision) {
		if (collision.transform.tag == "MovingPlatform") {
			transform.parent = collision.transform;
		}
	}
		
}
