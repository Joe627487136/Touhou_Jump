using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour {

    public Animator explosionAnimation;
    public CircleCollider2D explosionCollider;
    AudioSource explosionSound;
    AudioSource sizzle;

    // Use this for initialization
    void Start () {
        GameObject animChild = gameObject.transform.GetChild(0).gameObject;
        explosionAnimation = animChild.GetComponent<Animator>();
        explosionCollider = animChild.GetComponent<CircleCollider2D>();
        explosionSound = animChild.GetComponent<AudioSource>();
        explosionSound.pitch = 1.5f;
        sizzle = gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        sizzle.Play();


        StartCoroutine(Explosion());
    }
	
	// Update is called once per frame
	void Update () {
        Self_destroy_check();
    }
    IEnumerator Explosion()
    {
        
        yield return new WaitForSeconds(3.5f);
        explosionAnimation.SetBool("Kaboom", true);
        Explode();
        explosionSound.Play();
        sizzle.Stop();
        Combat_Handler.one_time_dmg_flag = true;
        Destroy(gameObject, 1.0f);
    }

    void Self_destroy_check()
    {
        float x_current_offset = transform.position.x;
        float y_current_offset = transform.position.y;
        if ((x_current_offset < -22 || x_current_offset > 22) || (y_current_offset < -22 || y_current_offset > 22))
        {
            Destroy(this.gameObject);
        }

    }

    void Explode()
    {
        explosionCollider.enabled = true;
    }

}
