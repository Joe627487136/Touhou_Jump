using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour {

    private int hp;
    public AudioSource ping;
    public AudioSource breakGlass;
    public ParticleSystem particleSystem;

    // Use this for initialization
    void Start () {
        hp = 7;
        GameObject particleChild = gameObject.transform.GetChild(0).gameObject;
        breakGlass = particleChild.GetComponent<AudioSource>();
        particleSystem = particleChild.GetComponent<ParticleSystem>();
        GameObject pingChild = gameObject.transform.GetChild(1).gameObject;
        ping = pingChild.GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        string msg = (this.name) + " is clicked";
        print(msg);
        hp--;
        ping.Play(0);
        if (hp == 0)
        {
            print("Bariier Destroyed");
            breakGlass.Play(0);
            particleSystem.Play();

            Destroy(gameObject,0.6f);
            
        }
    }

    void OnDestroy()
    {
        breakGlass.Play(0);
        particleSystem.Play();
    }
}
