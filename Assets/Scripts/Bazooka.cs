using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : weapon {

	public GameObject rocketPrefab;
	public bool isActive = false;

	public override void Attack ()
	{
		var rocket = Instantiate (rocketPrefab);
		rocket.transform.position = this.transform.position;
		rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
		base.Attack ();
	}

	void OnCollisionEnter2D(Collision2D coll) { 
		var player = coll.gameObject.GetComponent<Player> ();

		if (isActive && player == null) {
			Shoot ();
		}
	}	
	public void Shoot() {
		var rocket = coll.gameObject.GetComponent<rocketPrefab> ();
		var enemies = FindObjectsOfType<Enemy> ();
		foreach (var e in enemies) {
			e.gameObject.SetActive (false);

		}
		
	}
	
}
