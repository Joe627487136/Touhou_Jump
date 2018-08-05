using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : MonoBehaviour {
    private Animator animator;
    // Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        print("Collided with" + col.gameObject.tag);
        print(col.gameObject.tag.Equals("bottom"));
        // Handle the collision event to damage the player here

    }

}
