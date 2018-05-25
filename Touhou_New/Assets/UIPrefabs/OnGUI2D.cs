using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUI2D : MonoBehaviour {

	public static int score;

	void Start () {
		score = 0;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (20, 20, 200, 40), "Score: " + score);
	}
}
