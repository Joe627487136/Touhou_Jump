using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDOT : MonoBehaviour {
    public GameObject flameParticleSys;
    public ParticleSystem flameParticleSystem;
    public AudioSource burnSoundEffect;
    private int burn_ticks;

	// Use this for initialization
	void Start () {
        //TODO: Find the player and set the transform to the player's position 
        //TODO: Superimpose the animation on the characther sprite 
        burn_ticks = 10;
        flameParticleSystem = flameParticleSys.GetComponent<ParticleSystem>();
        InvokeRepeating("Burn", 0.0f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Burn()
    {
        flameParticleSystem.Play();
        print("Burning"); //TODO: Call player's damage function here 
        burnSoundEffect.Play();
        burn_ticks--;

        if(burn_ticks == 0)
        {
            CancelInvoke("Burn");
        }
    }
}
