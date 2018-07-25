using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
	public float moveSpeed = 4f;


	void Update(){
		float h = 2 * Input.acceleration.x;
		//float h = Input.GetAxis ("Horizontal");

		GetComponent<Rigidbody2D>().velocity =  new Vector2(h * moveSpeed,GetComponent<Rigidbody2D>().velocity.y) ;
	
	}

}
