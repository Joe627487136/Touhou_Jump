using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {

	public bool grounded;
	public float jumpHeight = 500f;
	public Transform groundcheck; 
	float groundRadius = .2f;
	public LayerMask ground;

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle (groundcheck.position, groundRadius, ground);

		float VelY = GetComponent<Rigidbody2D> ().velocity.y;

		if(grounded && VelY<= 0 ){
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpHeight));
		}
	}


}
