using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Enemy_Health_Handler : MonoBehaviour {
	public string enemy_id;
	public string enemy_type;
	private JSONNode Loaded_Normal_Enemy_Data;
	private int HP;
    private int start_HP;
	private int player_attack_value;
	private int player_skill_dmg_value;
	public Transform explosion;
	private bool one_time_skill_flag;
    private GameObject sprite_holder;
    private bool is_explosion_playing;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;

    // Use this for initialization
    void Start () {
        // Audio_controller
        Audio_controller = GameObject.FindGameObjectWithTag("Audio_manager");
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();

        // Load based on type
        Char_Spreadsheet_Reader myreader = new Char_Spreadsheet_Reader ();
		if (enemy_type == "Normal") {
			Loaded_Normal_Enemy_Data = myreader.Load_Enemy_Sheet ("Normal");
			HP = Loaded_Normal_Enemy_Data [enemy_id] ["HP"].AsInt;
            sprite_holder = this.gameObject;

        }

		if (enemy_type == "Boss") {
			Loaded_Normal_Enemy_Data = myreader.Load_Enemy_Sheet ("Boss");
			HP = Loaded_Normal_Enemy_Data [enemy_id] ["HP"].AsInt;
            start_HP = HP;
            GameObject angry_mark = transform.Find("angry_mark").gameObject;
            angry_mark.SetActive(false);
            sprite_holder = transform.Find("Sprite").gameObject;
        }
		player_attack_value = Cha_loader.char_att;
		player_skill_dmg_value = Cha_loader.char_skill_dmg;
        //print(player_attack_value);
	}

	void Check_skill_cast(){
		one_time_skill_flag = Combat_Handler.skill_toggle;
		if (one_time_skill_flag) {
			HP = HP - player_skill_dmg_value;
            Play_hit_flash(3);

        }
	}

	void Check_HP(){
		if (HP <= 0) {
			Destroy (this.gameObject);
            if (!is_explosion_playing) {
                StartCoroutine(play_ani_then_destroy());
            }
		}
        if (HP <= (start_HP / 2) && (enemy_type == "Boss")) {
            Lvl_manager.Current_Boss_Phrase = "Phrase 2";
            GameObject angry_mark = transform.Find("angry_mark").gameObject;
            angry_mark.SetActive(true);
        }
	}

	IEnumerator play_ani_then_destroy()
	{
        is_explosion_playing = true;
        Transform spark = Instantiate(explosion, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1);
        Destroy(spark.gameObject);
        is_explosion_playing = false;
    }

    // Update is called once per frame
    void Update () {
		Check_skill_cast ();
		Check_HP ();
	}

    IEnumerator Hit_Flash(int play_count)
    {
        Color red_color = new Color32(255, 30, 60, 255);
        SpriteRenderer spr = sprite_holder.GetComponent<SpriteRenderer>();
        for (int i = 0; i < play_count; i++) {
            spr.color = red_color;
            yield return new WaitForSeconds(0.05f);
            spr.color = Color.white;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void Play_hit_flash(int play_count){
        sound_ctrler.PlaySound("damage");
        StartCoroutine(Hit_Flash(play_count));
    }


	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject col_obj = col.gameObject;
		if (col_obj.tag == "Red_bullet") {
			int dmg_reduced = player_attack_value * 2;
			HP = HP - dmg_reduced;
            Play_hit_flash(1);

        }

		if (col_obj.tag == "Blue_bullet") {
			int dmg_reduced = player_attack_value;
			HP = HP - dmg_reduced;
            Play_hit_flash(1);

        }

		if (col_obj.tag == "Green_bullet") {
			int dmg_reduced = player_attack_value;
			HP = HP - dmg_reduced;
            Play_hit_flash(1);


        }

		if (col_obj.tag == "Player_hitbox") {
			HP = 0;
			Combat_Handler.one_time_dmg_flag = true;
			print ("Got Hit!");
		}
        //print(player_attack_value);
        //print(HP);
	}
}
