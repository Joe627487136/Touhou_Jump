using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cha_Box : MonoBehaviour {
	// Use this for initialization
	public static int chabox_children_count = 63;
	public List<Transform> chalist = new List<Transform> ();
	public static bool[] statelist;
	void Start(){
		Get_Chalist ();
	}
	void Update(){
		Modify_cha ();
	}

	void Count(){
		print (chalist.Count);
	}
	void Get_Chalist(){
		int children = transform.childCount;
		for (int i = 0; i < children; i++) {
			chalist.Add(transform.GetChild (i));
		}
	}

	void Modify_cha(){
		for (int i = 0; i < chabox_children_count; ++i) {
			if (statelist [i] == false) {
				//interactive.setfalse
				//blur image
				Image img = chalist[i].Find("Image").GetComponent<Image>();
				img.color = new Color32 (0, 0, 0, 255);
				Button btn = chalist [i].GetComponent<Button> ();
				btn.interactable = false;
			}
			if (statelist [i] == true) {
				//interactive.setrue
				//bright image
				Image img = chalist[i].Find("Image").GetComponent<Image>();
				img.color = new Color32 (255, 255, 255, 255);
				Button btn = chalist[i].GetComponent<Button> ();
				btn.interactable = true;
			}
		}
	}

}
