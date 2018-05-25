using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_s : MonoBehaviour {
	public static string count;

	void Update() {
		dotat ();
	}

	public void dotat(){
		GameObject.FindGameObjectWithTag ("Debug_text").GetComponent<Text> ().text = count;
	}
}
