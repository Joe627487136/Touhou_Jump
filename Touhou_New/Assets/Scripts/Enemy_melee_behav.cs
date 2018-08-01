using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_melee_behav : MonoBehaviour {
	private bool to_move;
	public Transform player;
	public float speed;

	// Use this for initialization



	void Start () {
		player = GameObject.Find ("Player_Holder").transform.Find ("player");
		speed = 1f;
		to_move = false;
		StartCoroutine (Wait_1_Move_to_Player());
	}
	
	// Update is called once per frame

	void move_to_pos(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, player.position, step);
	}

	void Update () {
		if (to_move) {
			move_to_pos ();
		}
	}


	IEnumerator Wait_1_Move_to_Player()
	{
		yield return new WaitForSeconds(1);
		to_move = true;

	}
}
