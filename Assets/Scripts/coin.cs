using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) { // != not
			gameObject.SetActive(false);
			FindObjectOfType<GM>().SetPoints(FindObjectOfType<GM>().GetPoints () + 1);

		}
	}
}
