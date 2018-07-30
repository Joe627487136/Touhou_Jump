using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam_changer : MonoBehaviour {

	private string current_char_element;
	public static bool trimmy_toggle;
	// Use this for initialization

	void Update_char_element(){
		// Make sure it update regardless of buffering time
		current_char_element = Cha_loader.char_element;
		if (current_char_element == null) {
			current_char_element = Cha_loader.char_element;
		}
		if (current_char_element == "Light"||current_char_element == "Elec") {
			int child_count = this.transform.childCount;
			for (int i = 0; i < child_count; i++) {
				GameObject current_particle_effect_obj = this.transform.GetChild (i).gameObject;
				ParticleSystem current_particle_sys = current_particle_effect_obj.GetComponent<ParticleSystem> ();
				current_particle_sys.startColor = new Color (253, 255, 225, 255);
			}
		}
		if (current_char_element == "Dark") {
			int child_count = this.transform.childCount;
			for (int i = 0; i < child_count; i++) {
				GameObject current_particle_effect_obj = this.transform.GetChild (i).gameObject;
				ParticleSystem current_particle_sys = current_particle_effect_obj.GetComponent<ParticleSystem> ();
				current_particle_sys.startColor = new Color (55, 0, 135, 255);
			}
		}
		if (current_char_element == "Earth") {
			int child_count = this.transform.childCount;
			for (int i = 0; i < child_count; i++) {
				GameObject current_particle_effect_obj = this.transform.GetChild (i).gameObject;
				ParticleSystem current_particle_sys = current_particle_effect_obj.GetComponent<ParticleSystem> ();
				current_particle_sys.startColor = new Color (11, 204, 84, 255);
			}
		}
		if (current_char_element == "Warter") {
			int child_count = this.transform.childCount;
			for (int i = 0; i < child_count; i++) {
				GameObject current_particle_effect_obj = this.transform.GetChild (i).gameObject;
				ParticleSystem current_particle_sys = current_particle_effect_obj.GetComponent<ParticleSystem> ();
				current_particle_sys.startColor = new Color (71, 164, 225, 255);
			}
		}
		if (current_char_element == "Fire") {
			int child_count = this.transform.childCount;
			for (int i = 0; i < child_count; i++) {
				GameObject current_particle_effect_obj = this.transform.GetChild (i).gameObject;
				ParticleSystem current_particle_sys = current_particle_effect_obj.GetComponent<ParticleSystem> ();
				current_particle_sys.startColor = new Color (249, 77, 109, 255);
			}
		}
	}
		
	public void trimy(){
		if (!trimmy_toggle) {
			ParticleSystem lightball = this.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ();
			lightball.startSize = 2;
			ParticleSystem lightbar = this.transform.GetChild (1).gameObject.GetComponent<ParticleSystem> ();
			lightbar.startSize = 1;
		}
		if (trimmy_toggle) {
			ParticleSystem lightball = this.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ();
			lightball.startSize = 1;
			ParticleSystem lightbar = this.transform.GetChild (1).gameObject.GetComponent<ParticleSystem> ();
			lightbar.startSize = 0.5f;
		}
	}

	void Start () {
		trimmy_toggle = false;
		Update_char_element ();
	}
	
	// Update is called once per frame
	void Update () {
		trimy ();
	}
}
