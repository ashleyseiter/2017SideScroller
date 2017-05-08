using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkHammer : Throwable {


	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();

		if (isActive && player == null) {
			Shrink ();
		}
	}
	public void Shrink () {

		var enemies = FindObjectsOfType<Enemy> ();
		foreach (var e in enemies) {
			e.transform.localScale = new Vector3 (1.5f, 1.5f);
		}
		gameObject.SetActive (false);
	}



}

