using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear_effect : MonoBehaviour {
	public float grow_factor = 4.5f;
	float edge;


	void Grow (){
		float x_param = this.transform.localScale.x;
		if (x_param < edge) {
			transform.localScale += new Vector3 (1, 1, 0) * Time.deltaTime * grow_factor;
		}
	}

	void Start (){
		// Make it 0
		edge = transform.localScale.x;
		this.transform.localScale = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Grow ();
	}
}
