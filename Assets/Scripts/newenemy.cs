﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newenemy : MonoBehaviour {

	Player player;
	public bool killPlayer = false;

	void OnCollisionEnter2D(Collision2D coll) {

		if (!enabled) {
			return;
		}

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) { // != not
			player.GetOut ();
			player.GetOut ();
		}
	}

}
