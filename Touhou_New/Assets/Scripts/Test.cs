using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		print (col.gameObject.name);
	}
}
