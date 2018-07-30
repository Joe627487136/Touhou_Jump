using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;

public class Combat_Handler : MonoBehaviour {


	public GameObject bullet;
	public static List<string> command_list;
	private string[] char_active_skill;
	public static bool skill_toggle;


	// Use this for initialization

	void attack_cast(){
		int current_commands_count = command_list.Count;
		if (current_commands_count == 3) {
			string[] player_input_command = command_list.ToArray ();
			if (Enumerable.SequenceEqual (player_input_command, char_active_skill)) {
				print ("Skill casted");
				skill_toggle = true;
			} 
			else {
				GameObject current_bullet = Instantiate(bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d = current_bullet.GetComponent<Rigidbody2D> ();
				bullet_rb2d.AddForce (new Vector2(0,0.5f));
			}
			command_list.ForEach(Debug.Log);
			command_list.Clear ();
		}

	}


	void Start (){
		// Ini such combat command list
		command_list = new List<string> ();
		// Get active skill set
		char_active_skill = Cha_loader.char_active_skill;


	}
	
	// Update is called once per frame
	void Update () {
		attack_cast ();
	}
}
