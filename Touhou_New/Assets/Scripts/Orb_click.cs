using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_click : MonoBehaviour {
	public ParticleSystem one_shot_gloom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void play_particle(){
		one_shot_gloom.transform.position = this.transform.position;
		one_shot_gloom.Play ();
	}

	void OnMouseDown(){
		GameObject child_orb = this.transform.GetChild (0).gameObject;
		string child_name = child_orb.name;
		if (child_name.Contains ("Red")) {
			//print ("R clicked");
			play_particle ();
			Combat_Handler.command_list.Add ("R");
			Destroy (child_orb);

			// Send clicking msg to manager
		}
		if (child_name.Contains ("Green")) {
			//print ("G clicked");
			play_particle ();
			Combat_Handler.command_list.Add ("G");
			Destroy (child_orb);

		}
		if (child_name.Contains ("Blue")) {
			//print ("B clicked");
			play_particle ();
			Combat_Handler.command_list.Add ("B");
			Destroy (child_orb);

		}
	}
}
