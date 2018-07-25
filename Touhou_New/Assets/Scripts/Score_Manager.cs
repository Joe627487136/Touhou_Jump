using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {

	public Transform player;
	float playerHeightY;
	int current_boncing;
	int score;
	int fonts = 30;
	public int growrate = 1;
	int display_score;
	public static bool request_write_data = false;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
		
	void Update () {
		modify_tag ();
		if (request_write_data == true) {
			request_write_data = false;
			DataManager.money = DataManager.money + score;
		}
	}

	public void modify_tag(){
		current_boncing = ((int)player.position.y) * 5;
		if (current_boncing > 0 && current_boncing > score) {
			score = current_boncing;
			//tag_animation ();
			string output = "Score: " + score;
			GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().text = output;
		}
	}
	public void tag_animation(){
		display_score = int.Parse(GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().text.Substring (7));

		if (display_score != score) {
			if (GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().fontSize != fonts + 5) {
				GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().fontSize++;
			}
			if (display_score < score) {
				display_score += growrate;
			}
			if (display_score > score) {
				display_score -= growrate;
			}
		}
		if (GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().fontSize != fonts) {
			GameObject.FindGameObjectWithTag ("ScoreTag").GetComponent<Text> ().fontSize--;
		}
	}
}
