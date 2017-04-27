using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb: weapon{

	public float blastRadius = 5;
	public bool isActive = false;


	void Update() {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();

		if (isActive && player == null) {
			Explode ();
		}
	}

	public override void Attack() {
		
		collider2D.enabled = true;
		rigidBody2D.isKinematic = false;
		rigidBody2D.velocity = new Vector2(5,0);
		transform.parent = null;

	}


	public override void GetPickedUp(Player Player) {

		if (isActive) {
			return;
		}

		isActive = true;
		base.GetPickedUp (Player);
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


