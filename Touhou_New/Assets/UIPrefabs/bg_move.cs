using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_move : MonoBehaviour {
	public Transform player;
	float playerHeightY;
	// Use this for initialization
	void Start(){

		player = GameObject.FindGameObjectWithTag ("MainCamera").transform;

		//PlatformSwap (2);
	}
	void Update(){

		playerHeightY = player.position.y;



		float currentCameraHeight = transform.position.y;
		float newHeightOfCamera = Mathf.Lerp (currentCameraHeight, playerHeightY, Time.deltaTime * 10);
		if (playerHeightY > currentCameraHeight) {

			transform.position = new Vector3 (transform.position.x, newHeightOfCamera, transform.position.z);
		}


		if (playerHeightY > OnGUI2D.score) {

			OnGUI2D.score = (int)playerHeightY;
		}
	}
}
