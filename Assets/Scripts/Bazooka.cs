using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : weapon {

	public GameObject rocketPrefab;
	public float blastRadius = 1;

	public override void Attack ()
	{
		var rocket = Instantiate (rocketPrefab);
		rocket.transform.position = this.transform.position;
		rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
		base.Attack ();
	}

	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) {
			Shoot ();
		}
	}
		public void Shoot() {
			var enemies = FindObjectsOfType<Enemy>();
			foreach (var e in enemies) {
			if (Vector3.Distance (this.transform.position, e.transform.position) < blastRadius) {
				e.gameObject.SetActive (false);
			}
		}
			gameObject.SetActive (false);
	}

}
