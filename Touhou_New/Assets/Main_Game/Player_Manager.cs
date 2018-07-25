using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour {
	public int current_selected_player;


	// currently no scv so return Reimu stats
	string read_from_csv(){
		Player my_player = new Player ();
		my_player.player_attack = 3;
		my_player.player_defence = 0;
		my_player.player_health = 100;

		string json_str = JsonUtility.ToJson (my_player);
		return json_str;
	}

	void Check_player_id(){
		if (current_selected_player == 0) {

		}
	}
	void Update () {
	}
}
