using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
	GameObject[] explo;

	void Handle_Explosion_Overflow(){
		explo = GameObject.FindGameObjectsWithTag ("Normal_enm_explosion");
		if (explo.Length >= 15) {
			foreach (GameObject s_explo in explo) {
				Destroy (s_explo);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Handle_Explosion_Overflow ();
	}
}
