using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_destruct_bullet : MonoBehaviour {
	// Use this for initialization
	void Start () {
		who_am_I ();
	}

	string who_am_I(){
		string my_name = this.gameObject.name;
		if (my_name == "Player_blue_bullet") {
			return "BB";
		}
		if (my_name == "Player_red_bullet") {
			return "RB";
		}
		if (my_name == "Player_green_bullet") {
			return "GB";
		}
		return null;
	}

	void OnTriggerEnter(Collider other)
	{
		string colliding_type = other.tag;
		if (colliding_type == "Enemy") {
			print ("Hit");
		}
	}


	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 40) {
			Destroy (this.gameObject);
		}
	}
}
