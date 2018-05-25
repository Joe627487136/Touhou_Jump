using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Index_receiver : MonoBehaviour {
	int currentindex;
	string currentrarity;
	GameObject Sum_Can;
	public Text rarity_text;
	public GameObject SR_Particle;
	public GameObject R_Particle;

	void receive(){
		currentindex = Sum_manager.drawindex;
		currentrarity = Sum_manager.rarity;
		Sum_Can = GameObject.FindGameObjectWithTag ("SummonCanvas");
		Sum_Can.transform.Find ("Cha").GetComponent<Image> ().sprite = Sum_manager.imglist [currentindex].sprite;
		Sum_Can.transform.Find ("Rarity").GetComponent<Text> ().text = currentrarity;
		if (!MenuManager.is_summmon_pop) {
			R_Particle.SetActive (false);
			SR_Particle.SetActive (false);
		}
		if (currentrarity == "N") {
			rarity_text.color = new Color32 (204, 200, 173, 255);
		}

		if (currentrarity == "R") {
			rarity_text.color = new Color32 (19, 0, 255, 255);
			if (MenuManager.is_summmon_pop) {
				R_Particle.SetActive (true);
			}
		}

		if (currentrarity == "SR") {
			rarity_text.color = new Color32 (248, 242, 51, 255);
			if (MenuManager.is_summmon_pop) {
				SR_Particle.SetActive (true);
			}
		}
	}
	void Update () {
		receive ();
	}
}
