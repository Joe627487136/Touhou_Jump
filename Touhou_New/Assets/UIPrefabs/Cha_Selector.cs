using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cha_Selector : MonoBehaviour {
	// Use this for initialization
	int slcted_index;
	void Start () {
		SnL.request_for_load_index = true;
		slcted_index = DataManager.slct_cha_index;
		modify ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void modify(){
		if (slcted_index <= 58) {
			GameObject bigspr = GameObject.FindGameObjectWithTag ("BigSpr");
			GameObject smallspr = GameObject.FindGameObjectWithTag ("SmallSpr");
			GameObject chabox = GameObject.FindGameObjectWithTag ("ChaB2");
			bigspr.SetActive (true);
			smallspr.SetActive (false);
			Sprite slcted_spr = chabox.transform.GetChild (slcted_index).Find("Image").GetComponent<Image>().sprite;
			bigspr.GetComponent<SpriteRenderer> ().sprite = slcted_spr;
		}
		if (slcted_index > 58) {
			GameObject bigspr = GameObject.FindGameObjectWithTag ("BigSpr");
			GameObject smallspr = GameObject.FindGameObjectWithTag ("SmallSpr");
			GameObject chabox = GameObject.FindGameObjectWithTag ("ChaB2");
			bigspr.SetActive (false);
			smallspr.SetActive (true);
			Sprite slcted_spr = chabox.transform.GetChild (slcted_index).Find("Image").GetComponent<Image>().sprite;
			bigspr.GetComponent<SpriteRenderer> ().sprite = slcted_spr;
		}
	}
}
