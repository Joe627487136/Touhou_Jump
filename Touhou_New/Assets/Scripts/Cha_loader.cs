using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Cha_loader : MonoBehaviour {
	Char_Spreadsheet_Reader my_reader;
	JSONNode Loader_cha_sheet;
	public static string passive_skill_type;
	public static string passive_skill_up_orb;
	public static int passive_skill_value;
	public static string char_element;
	public static string[] char_active_skill;
	public static int char_att;
	public static int char_def;
	public static int char_skill_dmg;


	// Use this for initialization
	void Start () {
		load_cha_to_combat ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void load_cha_to_combat(){
		int selected_char_index = DataManager.slct_cha_index;
		my_reader = new Char_Spreadsheet_Reader ();
		Loader_cha_sheet = my_reader.Load_Char_Sheet ();


		// Load Sprite
		GameObject player_holder = GameObject.Find ("Player_Holder");
		SpriteRenderer player_sprite_holder = player_holder.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer>();
		Sprite[] sprites = Resources.LoadAll<Sprite>("tohosd");
		int sprite_index = Loader_cha_sheet [selected_char_index.ToString ()]["Sprite_index"].AsInt;
		player_sprite_holder.sprite = sprites [sprite_index];
		passive_skill_type = Loader_cha_sheet [selected_char_index.ToString ()] ["Passive_skill_type"].ToString ().Replace("\"", "");

		// Load passive
		if (passive_skill_type == "Orb_up_") {
			passive_skill_up_orb = Loader_cha_sheet [selected_char_index.ToString ()] ["Passive_skill_up_orb"].ToString ().Replace("\"", "");
			passive_skill_value = Loader_cha_sheet [selected_char_index.ToString ()] ["Passive_skill_value"].AsInt;
		}

		// Load Cha_element
		char_element = Loader_cha_sheet [selected_char_index.ToString ()] ["Char_Element"].ToString ().Replace("\"", "");

		// Lood Cha_skill
		char_active_skill = new string[3];
		JSONArray loaded_char_active_skill_array = Loader_cha_sheet [selected_char_index.ToString ()] ["Char_skill_combo"].AsArray;
		int array_length = loaded_char_active_skill_array.Count;
		for (int i = 0; i < array_length; i++) {
			string load_out = loaded_char_active_skill_array [i].ToString().Replace("\"", "");
			char_active_skill [i] = load_out;
		}
		char_skill_dmg = Loader_cha_sheet [selected_char_index.ToString ()] ["Char_skill_damage"].AsInt;

		// Load Cha_att and def
		int loaded_char_att = Loader_cha_sheet [selected_char_index.ToString ()] ["Attack_value"].AsInt;
		int loaded_char_def = Loader_cha_sheet [selected_char_index.ToString ()] ["Defence_value"].AsInt;
		char_att = loaded_char_att;
		char_def = loaded_char_def;

	}
}
