using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

	public Rigidbody2D RB;
	public Vector2 velocity;


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 10);
		RB = GetComponent<Rigidbody2D> ();
		velocity = RB.velocity;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (RB.velocity.y < velocity.y) {
			RB.velocity = velocity;
		}
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		RB.velocity = new Vector2 (velocity.x, -velocity.y);
		if (collision.collider.tag == "deadly") {
			Destroy (collision.gameObject);
			Explode ();
		}
		if (collision.contacts [0].normal.x != 0) {
			Explode ();
		}
	}
	void Explode() {
		Destroy (this.gameObject);
	}
}
