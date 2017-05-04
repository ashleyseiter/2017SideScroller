using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
public class StunGrenade : Throwable {

	public float blastRadius = 5;


	void OnCollisionEnter2D(Collision2D coll) {

		var player = coll.gameObject.GetComponent<Player> ();

		if (isActive && player == null) {
			Explode ();
		}
	}


	public void Explode() {

		var enemies = FindObjectsOfType<Enemy>();
		foreach (var e in enemies) {
			if (Vector3.Distance (this.transform.position, e.transform.position) < blastRadius) {
					StartCoroutine (Stun(e) );
			}
		}
		
			collider2D.enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;

	}
	

	IEnumerator Stun(Enemy e) {
			var renderer = e.GetComponent<SpriteRenderer> ();
			e.enabled = false;
			renderer.color = new Color (1, 1, 1, .4f);
			yield return new WaitForSeconds (5);

			e.enabled = true;
			renderer.color = new Color (1, 1, 1, 1);
	}
}
}

