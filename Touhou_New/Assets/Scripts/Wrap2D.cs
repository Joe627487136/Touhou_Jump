using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap2D : MonoBehaviour {

	void FixedUpdate(){

		if (transform.position.x <= -3.32f) {
		
			transform.position = new Vector3 (3.32f, transform.position.y, transform.position.z);
		}

		else if (transform.position.x >= 3.32f) {

			transform.position = new Vector3 (-3.32f, transform.position.y, transform.position.z);
		}
	}
}
