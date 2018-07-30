using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_destruct_bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y > 20) {
			Destroy (this.gameObject);
		}
	}
}
