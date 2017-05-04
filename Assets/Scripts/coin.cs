using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	private void OnTriggerEnter2D (Collider2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();
		if (player != null) { // != not
			gameObject.SetActive(false);
			FindObjectOfType<GM>().SetPoints(FindObjectOfType<GM>().GetPoints () + 1);

		}
	}
}
