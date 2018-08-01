using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Enemy_Health_Handler : MonoBehaviour {
	public string enemy_id;
	public string enemy_type;
	private JSONNode Loaded_Normal_Enemy_Data;
	private int HP;
	private int player_attack_value;
	private int player_skill_dmg_value;
	public Transform explosion;
	private bool one_time_skill_flag;
	// Use this for initialization
	void Start () {
		
		// Load based on type
		Char_Spreadsheet_Reader myreader = new Char_Spreadsheet_Reader ();
		if (enemy_type == "Normal") {
			Loaded_Normal_Enemy_Data = myreader.Load_Enemy_Sheet ("Normal");
			HP = Loaded_Normal_Enemy_Data [enemy_id] ["HP"].AsInt;
		}

		if (enemy_type == "Boss") {
			Loaded_Normal_Enemy_Data = myreader.Load_Enemy_Sheet ("Boss");
			HP = Loaded_Normal_Enemy_Data [enemy_id] ["HP"].AsInt;
		}
		player_attack_value = Cha_loader.char_att;
		player_skill_dmg_value = Cha_loader.char_skill_dmg;
	}

	void Check_skill_cast(){
		one_time_skill_flag = Combat_Handler.skill_toggle;
		if (one_time_skill_flag) {
			HP = HP - player_skill_dmg_value;
		}
	}

	void Check_HP(){
		if (HP <= 0) {
			Destroy (this.gameObject);
			StartCoroutine (play_ani_then_destroy());
		}
	}

	IEnumerator play_ani_then_destroy()
	{
		Transform spark = Instantiate(explosion, transform.position, Quaternion.identity);
		print (spark.gameObject.name);
		yield return new WaitForSeconds(1);
	}
	
	// Update is called once per frame
	void Update () {
		Check_skill_cast ();
		Check_HP ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject col_obj = col.gameObject;
		print (col_obj.tag);
		if (col_obj.tag == "Red_bullet") {
			int dmg_reduced = player_attack_value * 2;
			HP = HP - dmg_reduced;
			print (dmg_reduced);
		}

		if (col_obj.tag == "Blue_bullet") {
			int dmg_reduced = player_attack_value;
			HP = HP - dmg_reduced;
			print (dmg_reduced);
		}

		if (col_obj.tag == "Green_bullet") {
			int dmg_reduced = player_attack_value;
			HP = HP - dmg_reduced;
			print (dmg_reduced);
		}

		if (col_obj.tag == "Player_hitbox") {
			HP = 0;
			Combat_Handler.one_time_dmg_flag = true;
			print ("Got Hit!");
		}
	}
}
