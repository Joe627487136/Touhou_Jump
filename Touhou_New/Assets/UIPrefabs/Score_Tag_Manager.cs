using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Tag_Manager : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		UI_Modifier ();
	}

	public void UI_Modifier(){
		Cha_Box.statelist = DataManager.locklist;
		GameObject Scoretag = GameObject.FindGameObjectWithTag ("Registered_Score");
		Scoretag.GetComponent<Text> ().text = DataManager.money.ToString()+"G";
	}
}
