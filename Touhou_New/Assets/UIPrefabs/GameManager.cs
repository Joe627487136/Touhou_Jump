using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Transform player;
	float playerHeightY;
	int current_boncing;
	int score;


	public Transform Jump;
	public Transform Leftright;
	public Transform Updown;
	public Transform OneTime;
	public Transform target;
	private int platNumber;
	private float platCheck;
	private float spawnPlatformsTo=10;

	void Start(){
	
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		//PlatformSwap (2);
	}

	float dampTime = 1f; //offset from the viewport center to fix damping
	Vector3 velocity = Vector3.zero;

	void Update(){
		
		playerHeightY = player.position.y;

		if (playerHeightY > platCheck) {
			PlatformManager ();
		}

		float currentCameraHeight = transform.position.y;
		float newHeightOfCamera = Mathf.Lerp (currentCameraHeight, playerHeightY, Time.deltaTime * 10);
		if (playerHeightY > currentCameraHeight) {
			camfollow ();
		}

		else {
		
			if (playerHeightY < (currentCameraHeight - 5.6)) {
				manage_data ();
				SceneManager.LoadScene ("S1");
			}
		}
	}

	void PlatformManager(){
		platCheck = player.position.y + 10;
		PlatformSwap (platCheck + 10);

	}

	void PlatformSwap(float floatValue){

		float y = spawnPlatformsTo;
		while (y <= floatValue) {
			float x = Random.Range (-3.32f, 3.32f);

			if (y <= 200f) {
				platNumber = Random.Range (1, 4);
			} else {
				platNumber = Random.Range (1, 5);
			}

			Vector2 posXY = new Vector2 (x, y);


			if (platNumber == 1) {	
				Instantiate (Jump, posXY, Quaternion.identity);
			}

			if (platNumber == 2) {	
				Instantiate (Leftright, posXY, Quaternion.identity);
			}

			if (platNumber == 3) {	
				Instantiate (Updown, posXY, Quaternion.identity);
			}

			if (platNumber == 4) {	
				Instantiate (OneTime, posXY, Quaternion.identity);
			}
			y += Random.Range (1f, 3f);
		}

		spawnPlatformsTo = floatValue;

	}

	public void camfollow(){
		if(target) {
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint( new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			destination.x = 0f;

			// Follow player up
			if(destination.y > this.transform.position.y)
			{
				transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dampTime);
			}

			// Follow player down
			/*
			if(destination.y < this.transform.position.y)
			{
				transform.position = Vector3.SmoothDamp(
					this.transform.position, destination, ref velocity, dampTime);
			}
			*/
		}
	}

	public void manage_data(){
		Score_Manager.request_write_data = true;
		SnL.request_for_save_m = true;
	}
}
