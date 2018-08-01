using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Normal_Enemy_spawner : MonoBehaviour {
	public Transform Kunpaku;
	public Transform Kisume;
	Char_Spreadsheet_Reader my_reader;
	JSONNode Loader_cha_sheet;
	// Use this for initialization
	void Start () {
		my_reader = new Char_Spreadsheet_Reader ();
		Loader_cha_sheet = my_reader.Load_Enemy_Sheet (Load_target:"Normal");

		// Spawn_test:
		Spawn_normal_enemy_wave(type:0, amount:15);
	}
		
	void Spawn_normal_enemy_wave(int type, int amount){
		// Spawn kunpaku
		if (type == 0) {
			for (int count = 0; count < amount; count++) {
				float x_offset = Random.Range (-15.0f, 15.0f);
				float y_offset = Random.Range (-2.0f, 2.0f);
				Vector3 new_pos = transform.position + new Vector3 (x_offset, y_offset, 0);
				Transform iKunpaku = Instantiate (Kunpaku, new_pos, Quaternion.Euler(0,0,180));
				iKunpaku.transform.parent = this.transform;
			}
		}

		if (type == 1) {
			for (int count = 0; count < amount; count++) {
				float x_offset = Random.Range (-15.0f, 15.0f);
				float y_offset = Random.Range (-2.0f, 2.0f);
				Vector3 new_pos = transform.position + new Vector3 (x_offset, y_offset, 0);
				Transform iKisume = Instantiate (Kisume, new_pos, Quaternion.Euler(0,0,0));
				iKisume.transform.parent = this.transform;
			}
		}
			
	}

	// Update is called once per frame
	void Update () {
		
	}
}
