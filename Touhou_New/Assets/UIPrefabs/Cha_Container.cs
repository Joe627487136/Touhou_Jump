using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cha_Container : MonoBehaviour {
	public Sprite current_img;
	public string myname;

	public string get_tag_name(){
		return transform.tag;
	}

	void Update(){
	}
}
