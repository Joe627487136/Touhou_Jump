using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Text Life_text;
    public Transform explosion;
    public GameObject sprite_holder;
    private bool is_explosion_playing;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;



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


    public void Load_End_Scene()
    {
        StartCoroutine(Change_to_end_scene());
    }
    IEnumerator Change_to_end_scene()
    {
        float fadeTime = GameObject.Find("SceneManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime - 0.1f);
        SceneManager.LoadScene("End_scene");
    }


    void attack_cast(){
		int current_commands_count = command_list.Count;
		if (current_commands_count == 3) {
			string[] player_input_command = command_list.ToArray ();
			string is_match3 = color_sequential_match (player_input_command);
			bool is_skilling = Enumerable.SequenceEqual (player_input_command, char_active_skill);
			if (is_skilling) {
				Play_movement_animation.jump_signal = true;
                //print ("Skill casted");
                sound_ctrler.PlaySound("specialAttack");
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
			//command_list.ForEach(Debug.Log);
			command_list.Clear ();
		}

	}

    IEnumerator Hit_Flash(int play_count)
    {
        Color red_color = new Color32(255, 30, 60, 255);
        SpriteRenderer spr = sprite_holder.GetComponent<SpriteRenderer>();
        for (int i = 0; i < play_count; i++)
        {
            spr.color = red_color;
            yield return new WaitForSeconds(0.05f);
            spr.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator play_ani_then_destroy()
    {
        is_explosion_playing = true;
        Transform spark = Instantiate(explosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        int wave_df_amount = Lvl_manager.amount_wave_defeated;
        int boss_df_amount = Lvl_manager.amount_boss_defeated;
        // Wave 200G
        // Boss 500G
        PlayerPrefs.SetInt("Wave_Defeated_amount", wave_df_amount);
        PlayerPrefs.SetInt("Boss_Defeated_amount", boss_df_amount);
        PlayerPrefs.SetInt("Pass_status", 0);
        Load_End_Scene();


    }

    void Play_hit_flash(int play_count)
    {
        // Hit flash sound
        sound_ctrler.PlaySound("damage");
        StartCoroutine(Hit_Flash(play_count));
    }



    void Check_for_get_dmg(){
		if (one_time_dmg_flag){

            one_time_dmg_flag = false;
			char_hp = char_hp - 1;
            Play_hit_flash(1);


        }
        string life_value_text = "Life: " + char_hp.ToString();
        Life_text.text = life_value_text;
    }

	void Check_for_dead(){
		if (char_hp <= 0) {
            // Play sound
            sound_ctrler.PlaySound("deathSound");
            if (!is_explosion_playing)
            {
                StartCoroutine(play_ani_then_destroy());
            }
        }
	}



	void Start (){
        // Audio
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();

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
