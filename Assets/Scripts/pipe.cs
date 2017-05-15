using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour {

	public Animator animator;
	protected new Collider2D collider2D;

	void Start()
	{
		collider2D = GetComponent<BoxCollider2D>();
		animator.enabled = false;
	}



	void OnCollisionEnter2D(Collision2D coll) {
		
		var p = gameObject.GetComponent<pipe> ();
		var player = coll.gameObject.GetComponent<Player> ();
		if (Input.GetButtonDown ("Fire3") && player!=null ) {
			p.collider2D.enabled = false;
			GoInto(player) ;
		}

	}

	void GoInto(Player player){
		
		player.enabled = false;
		animator.enabled = true;
		animator.Play ("GoDown");
		player.enabled = true;
			

			
			}




}
