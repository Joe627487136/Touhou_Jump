using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExJump2D : MonoBehaviour {

	public float jumpHeight = 500f;
	float VelY;

	void Update(){
	
		VelY = transform.position.y;
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "JumpPlant" ) {
		
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0,jumpHeight));
		}
	}
}
