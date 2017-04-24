using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) { // != not
			var enemies = FindObjectsOfType<Enemy>();
			foreach (var e in enemies) {
				if (Vector3.Distance (this.transform.position, e.transform.position) < 10) {
					e.gameObject.SetActive (false);
				}
			}
		}
	}
}
