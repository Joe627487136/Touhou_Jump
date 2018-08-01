using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_caster : MonoBehaviour {

	private bool skill_toggle;
	public GameObject beam;
	private static bool is_beam_casting;


	void skill_cast(){
		// Get from combat_manager
		skill_toggle = Combat_Handler.skill_toggle;
		if (skill_toggle == true) {
			// Set it off and send to all enemy
			Combat_Handler.skill_toggle = false;
			if (!is_beam_casting) {
				StartCoroutine (Cast_beam_ani());
			}
			if (is_beam_casting) {
			}

		}
	}

	IEnumerator Cast_beam_ani(){
		beam.SetActive (true);
		is_beam_casting = true;
		yield return new WaitForSeconds(1);
		Beam_changer.trimmy_toggle = true;
		yield return new WaitForSeconds(1);
		Beam_changer.trimmy_toggle = false;
		beam.SetActive (false);
		is_beam_casting = false;
	}

	IEnumerator Cast_beam_ani_d(){
		beam.SetActive (true);
		is_beam_casting = true;
		yield return new WaitForSeconds(1);
		Beam_changer.trimmy_toggle = true;
		yield return new WaitForSeconds(1);
		Beam_changer.trimmy_toggle = false;
		beam.SetActive (false);
		is_beam_casting = false;
	}

	void Start(){
		// Set beam off when start
		is_beam_casting = false;
		beam.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		skill_cast ();
	}
}
