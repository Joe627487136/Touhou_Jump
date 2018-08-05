using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform boss = GameObject.FindGameObjectWithTag("Enemy").transform;
        Physics2D.IgnoreCollision(boss.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void Self_destroy_check() {
        float x_current_offset = transform.position.x;
        float y_current_offset = transform.position.y;
        if ((x_current_offset < -22 || x_current_offset > 22) || (y_current_offset < -22 || y_current_offset > 22)){
            Destroy(this.gameObject);
        }

    }
	// Update is called once per frame
	void Update () {
        ignore_barrier();
        Self_destroy_check();

    }

    void ignore_barrier()
    {
        try
        {
            Transform barrier = GameObject.FindGameObjectWithTag("Barrier").transform;
            Physics2D.IgnoreCollision(barrier.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        catch (NullReferenceException e) {
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject col_obj = col.gameObject;
        if (col_obj.tag == "Player_hitbox")
        {
            string passive_skill_type = Cha_loader.passive_skill_type;
            if (passive_skill_type == "Dodge") {
                int passive_skill_value = Cha_loader.passive_skill_value;
                int total_ticks = 100;
                int wave_point = passive_skill_value;
                //// Invinsible
                //wave_point = 99;
                int ran_tick = UnityEngine.Random.Range(0, 100);
                if (ran_tick <= wave_point) {
                    print("Dodge");
                    return;
                }
                
            }
            Combat_Handler.one_time_dmg_flag = true;
            //print("Got Hit!");
            Destroy(this.gameObject);
        }
    }
}
