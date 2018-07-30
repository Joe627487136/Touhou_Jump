using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Handler : MonoBehaviour {
	public GameObject Red_Orb;
	public GameObject Blue_Orb;
	public GameObject Green_Orb;
	int Orbs_Count;
	private int ran_gen;
	string passive_skill_type;
	// Use this for initialization

	public int orb_index_gen(string mod="gen", string skill="None", string up_target="None", int up_rate=0){
		int[] orb_index_ref = new int[]{ 0, 1, 2 };
		if (mod == "gen") {
			if (skill == "None") {
				int pointer = Random.Range (0, 100);
				if (pointer >= 0 && pointer < 33) {
					return orb_index_ref [0];
				}
				if (pointer >= 33 && pointer < 66) {
					return orb_index_ref [1];
				}
				if (pointer >= 66 && pointer <= 99) {
					return orb_index_ref [2];
				}
			}

			if (skill == "Up") {
				int pointer = Random.Range (0, 100);
				if (pointer >= 0 && pointer < (33 + up_rate) ){
					if (up_target == "R") {
						return orb_index_ref [0];
					}
					if (up_target == "G") {
						return orb_index_ref [1];
					}
					if (up_target == "B") {
						return orb_index_ref [2];
					}
					
				}
				if (pointer >= (33 + up_rate) && pointer < (66 + (up_rate/2))) {
					if (up_target == "R") {
						return orb_index_ref [1];
					}
					if (up_target == "G") {
						return orb_index_ref [0];
					}
					if (up_target == "B") {
						return orb_index_ref [0];
					}
				}
				if (pointer >= (66 + (up_rate/2)) && pointer <= 99) {
					if (up_target == "R") {
						return orb_index_ref [2];
					}
					if (up_target == "G") {
						return orb_index_ref [2];
					}
					if (up_target == "B") {
						return orb_index_ref [1];
					}

				}
			}
		}
		return -1;
	}




	void Orbs_gen(){
		GameObject[] Orb_Array = new GameObject[]{Red_Orb, Green_Orb, Blue_Orb}; // RGB Orbs
		Orbs_Count = this.gameObject.transform.childCount;
		for (int i = 0; i < Orbs_Count; i++) {
			Transform Current_orb_holder = this.gameObject.transform.GetChild (i);
			passive_skill_type = Cha_loader.passive_skill_type;
			if (Current_orb_holder.childCount == 0) { //Holder is empty
				if (passive_skill_type == "Orb_up_") {
					string current_up_target = Cha_loader.passive_skill_up_orb;
					int current_up_rate = Cha_loader.passive_skill_value;
					ran_gen = orb_index_gen (mod: "gen", skill:"Up", up_target: current_up_target, up_rate: current_up_rate);
					//print (current_up_target + ": " + current_up_rate.ToString ());
				}
				if (passive_skill_type != "Orb_up_"){
					ran_gen = orb_index_gen (mod: "gen");
					//print ("Normal_gen");
				}
				GameObject Jack_pot_orb = Orb_Array [ran_gen];
				GameObject to_create_orb = Instantiate (Jack_pot_orb) as GameObject;
				to_create_orb.transform.parent = Current_orb_holder;
				to_create_orb.transform.localPosition = new Vector3 (0, 0, 0);
			}

		}
	}


	void Start () {
		Orbs_gen ();
	}
	
	// Update is called once per frame
	void Update () {
		Orbs_gen ();	
	}
}
