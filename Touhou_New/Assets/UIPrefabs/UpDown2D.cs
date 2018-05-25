using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown2D : MonoBehaviour {

	float platformSpeed = 2f;
	bool endPoint;

	float startPoint;
	float endPointY;

	public int unitsToMove = 4;
	void Start(){
		float delta = Random.Range (-0.5f, 0.5f);
		startPoint = transform.position.y+delta;
		endPointY = startPoint + unitsToMove+delta;
	}

	void Update (){

		if (endPoint) {
			transform.position += Vector3.up * platformSpeed * Time.deltaTime;
		}

		else {
			transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
		}

		if (transform.position.y >= endPointY) {

			endPoint = false;
		}

		if (transform.position.y <= startPoint) {

			endPoint = true;
		}
	}
}
