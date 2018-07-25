using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OTplate_jump : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "otPlant" ) {

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0,350f));
			Destroy (other.gameObject,2f);
		}
	}
}
