using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slicing_behav : MonoBehaviour {

	private float horizontal_offset;
	private bool flip_flag;
	Vector3 next_position;
	public float speed;
	private bool to_calculate;

	void Move_diag (){
		if (to_calculate) {
			Vector3 current_position = transform.position;
			if (flip_flag) {
				next_position = new Vector3 (horizontal_offset, current_position.y - 5, current_position.z);
			}
			if (!flip_flag){
				next_position = new Vector3 (-horizontal_offset, current_position.y - 5, current_position.z);
			}

			flip_flag = !flip_flag;
			//print (next_position);
		}

		if (transform.position != next_position) {
			to_calculate = false;
		}

		if (transform.position == next_position) {
			to_calculate = true;
		}

		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, next_position, step);
	}

	void Start () {
		to_calculate = true;
		flip_flag = true;
		horizontal_offset = 15f;
		speed = 4.5f;

	}
	
	// Update is called once per frame
	void Update () {
		Move_diag ();
	}
}
