using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink_Animation : MonoBehaviour {
	public AnimationCurve ac;
	float playSpeed = 2f;
	float timeOffset = 0;



	void Shrink(){
		float r = ac.Evaluate ((Time.time+timeOffset) * playSpeed);
		Vector3 trsm_local_scale = transform.localScale;
		transform.localScale = new Vector3 (trsm_local_scale.x * r, trsm_local_scale.y * r, trsm_local_scale.z);
	}
		

	void Start () {
		timeOffset = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		Shrink ();
	}
}
