using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStatus : MonoBehaviour {
    public Animator lightningAnimation;
    public AudioSource earcing;
    public AudioSource electricShock;

	// Use this for initialization
	void Start () {
        earcing.Play();
        GameObject animChild = gameObject.transform.GetChild(0).gameObject;
        earcing = animChild.GetComponent<AudioSource>();
        electricShock = gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();

        lightningAnimation = animChild.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
        earcing.Stop();
        electricShock.PlayDelayed(0.1f);
        string msg = (this.name) + " is clicked";
        print(msg);
        lightningAnimation.SetBool("Clicked", true);
        // TODO: Damage the player here 
        lightningAnimation.SetBool("Exit", true);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, electricShock.clip.length);
    }
}
