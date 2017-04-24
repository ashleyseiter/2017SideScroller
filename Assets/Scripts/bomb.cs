using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {

	public float blastRadius = 5;
	public bool isActive = false;

	private new Rigidbody2D rigidBody2D;
	private new Collider2D collider2D;

	void Start() {
		rigidBody2D = GetComponent <Rigidbody2D> ();
		collider2D = GetComponent<Collider2D> ();
	}

	void Update() {
		if (Input.GetButtonDown("Fire1") && isActive){
			Throw ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null && !isActive) { // != not
			GetPickedUp (player);
		}
		if (isActive && player == null) {
			Explode ();
		}
	}

	public void Throw () {
		
		collider2D.enabled = true;
		rigidBody2D.isKinematic = false;
		rigidBody2D.velocity = new Vector2(5,0);
		transform.parent = null;

	}


	public void GetPickedUp(Player player) {
		isActive = true;
		collider2D.enabled = false;
		rigidBody2D.isKinematic = true;
		rigidBody2D.velocity = new Vector2 ();
		transform.parent = player.transform;
		transform.localScale = new Vector3 (.05f, .05f);
		transform.localPosition = new Vector3 (.2f, .2f);


	}


	public void Explode() {
		
		var enemies = FindObjectsOfType<Enemy>();
		foreach (var e in enemies) {
				if (Vector3.Distance (this.transform.position, e.transform.position) < blastRadius) {
					e.gameObject.SetActive (false);
				}
			}
			gameObject.SetActive (false);
		}
	}


