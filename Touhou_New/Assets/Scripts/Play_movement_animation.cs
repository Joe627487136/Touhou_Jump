using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_movement_animation : MonoBehaviour {

	// Use this for initialization
	public static bool jump_signal;

	void Jump_check(){
		if (jump_signal) {
			Vector2 up_a_bit = new Vector2 (0.0f, 500f);
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (up_a_bit);
			//print ("jump!");
			jump_signal = false;
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Jump_check ();
	}
}
