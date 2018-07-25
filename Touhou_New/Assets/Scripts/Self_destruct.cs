using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_destruct : MonoBehaviour {
	public Transform player;
	float playerHeightY;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		playerHeightY = player.position.y;
		if (transform.position.y + 10 < playerHeightY) {
			Destroy (this);
		}
	}
}
