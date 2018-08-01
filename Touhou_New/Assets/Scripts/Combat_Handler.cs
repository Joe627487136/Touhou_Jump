using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;

public class Combat_Handler : MonoBehaviour {


	public GameObject r_bullet;
	public GameObject g_bullet;
	public GameObject b_bullet;
	public static List<string> command_list;
	private string[] char_active_skill;
	public static bool skill_toggle;
	private float bulle_offset;
	private int char_hp;
	public static bool one_time_dmg_flag;


	private string color_sequential_match(string[] array){
		string temp = "-1";
		int count = array.Length;
		for (int i = 0; i < count; i++) {
			// First shitty index
			if (i == 0) {
				temp = array [i];
			}
			if (i != 0) {
				if (array [i] != temp) {
					return "NSQ";
				}
			}
		}
		if (temp == "R") {
			return "RSQ";
		}
		if (temp == "B") {
			return "BSQ";
		}
		if (temp == "G") {
			return "GSQ";
		}

		return "NSQ";
	}

	void attack_cast(){
		int current_commands_count = command_list.Count;
		if (current_commands_count == 3) {
			string[] player_input_command = command_list.ToArray ();
			string is_match3 = color_sequential_match (player_input_command);
			bool is_skilling = Enumerable.SequenceEqual (player_input_command, char_active_skill);
			if (is_skilling) {
				Play_movement_animation.jump_signal = true;
				print ("Skill casted");
				skill_toggle = true;
			} 
			if ((!is_skilling) && (is_match3=="NSQ")){
				GameObject current_bullet = Instantiate(b_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d = current_bullet.GetComponent<Rigidbody2D> ();
				bullet_rb2d.AddForce (new Vector2(0,0.5f));
			}
			if ((!is_skilling) && (is_match3=="RSQ")){
				//Spread shot Red (More dmg but random)

				//Straight bullet
				GameObject current_bullet0 = Instantiate(r_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d0 = current_bullet0.GetComponent<Rigidbody2D> ();
				float angle_var0 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d0.AddForce (new Vector2(angle_var0,0.5f));

				//Side bullet0
				GameObject current_bullet1 = Instantiate(r_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d1 = current_bullet1.GetComponent<Rigidbody2D> ();
				float angle_var1 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d1.AddForce (new Vector2(angle_var1,0.5f));

				//Side bullet1
				GameObject current_bullet2 = Instantiate(r_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d2 = current_bullet2.GetComponent<Rigidbody2D> ();
				float angle_var2 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d2.AddForce (new Vector2(angle_var2,0.5f));

			}

			if ((!is_skilling) && (is_match3=="BSQ")){
				//Spread shot Red (Less dmg but static)

				//Straight bullet
				GameObject current_bullet0 = Instantiate(b_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d0 = current_bullet0.GetComponent<Rigidbody2D> ();
				bullet_rb2d0.AddForce (new Vector2(0,0.5f));

				GameObject current_bullet1 = Instantiate(b_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d1 = current_bullet1.GetComponent<Rigidbody2D> ();
				bullet_rb2d1.AddForce (new Vector2(-bulle_offset,0.5f));

				GameObject current_bullet2 = Instantiate(b_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d2 = current_bullet2.GetComponent<Rigidbody2D> ();
				bullet_rb2d2.AddForce (new Vector2(bulle_offset,0.5f));

			}

			if ((!is_skilling) && (is_match3=="GSQ")){
				//Spread shot Red (Less dmg but regen)

				//Straight bullet
				GameObject current_bullet0 = Instantiate(g_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d0 = current_bullet0.GetComponent<Rigidbody2D> ();
				float angle_var0 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d0.AddForce (new Vector2(angle_var0,0.5f));

				//Side bullet0
				GameObject current_bullet1 = Instantiate(g_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d1 = current_bullet1.GetComponent<Rigidbody2D> ();
				float angle_var1 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d1.AddForce (new Vector2(angle_var1,0.5f));

				//Side bullet1
				GameObject current_bullet2 = Instantiate(g_bullet, transform.position, transform.rotation); 
				Rigidbody2D bullet_rb2d2 = current_bullet2.GetComponent<Rigidbody2D> ();
				float angle_var2 = Random.Range (-bulle_offset, bulle_offset);
				bullet_rb2d2.AddForce (new Vector2(angle_var2,0.5f));

			}
			command_list.ForEach(Debug.Log);
			command_list.Clear ();
		}

	}

	void Check_for_get_dmg(){
		if (one_time_dmg_flag){
			one_time_dmg_flag = false;
			char_hp = char_hp - 1;
		}
	}

	void Check_for_dead(){
		if (char_hp <= 0) {
			print ("Dead");
		}
	}



	void Start (){
		// Set dmg flag to false
		one_time_dmg_flag = false;

		// Get hp value for player
		char_hp = Cha_loader.char_def;

		// Ini bullet offset
		bulle_offset = 0.2f;

		// Ini such combat command list
		command_list = new List<string> ();
		// Get active skill set
		char_active_skill = Cha_loader.char_active_skill;


	}
	
	// Update is called once per frame
	void Update () {
		Check_for_get_dmg ();
		Check_for_dead ();
		attack_cast ();
	}
}
