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
		
	
}
