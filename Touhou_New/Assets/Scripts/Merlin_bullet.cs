using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merlin_bullet : MonoBehaviour {

    public GameObject Shoot_Circle0;
    public GameObject Shoot_Circle1;
    private GameObject Shooter_0;
    private GameObject Shooter_1;
    public float hang_seconds;
    public bool shoot_flip_flag;
    public bool shoot_LCR_running;
    public bool shoot_RCR_running;
    private bool is_phrase1_shoot;
    public static string merlin_shoot_signal;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;


    void Start () {
        Audio_controller = GameObject.FindGameObjectWithTag("Audio_manager");
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();

        is_phrase1_shoot = false;
        hang_seconds = 1;
        shoot_LCR_running = false;
        shoot_RCR_running = false;
        shoot_flip_flag = false;
        Shooter_0 = Shoot_Circle0.transform.GetChild(0).gameObject;
        Shooter_1 = Shoot_Circle1.transform.GetChild(0).gameObject;
    }

    IEnumerator shoot(string circle_pos)
    {
        if (circle_pos == "left")
        {
            Shooter_0.GetComponent<UbhNwayShot>().Shot();
            // play sound
            sound_ctrler.PlaySound("blueBullet");

            shoot_LCR_running = true;
        }
        else if (circle_pos == "right")
        {
            Shooter_1.GetComponent<UbhNwayShot>().Shot();
            // play sound
            sound_ctrler.PlaySound("blueBullet");

            shoot_RCR_running = true;
        }
        shoot_LCR_running = true;
        yield return new WaitForSeconds(hang_seconds);
        shoot_LCR_running = false;
        shoot_RCR_running = false;
    }


    IEnumerator shoot_both()
    {
        Shooter_0.GetComponent<UbhNwayShot>().Shot();
        // play sound
        sound_ctrler.PlaySound("blueBullet");

        shoot_LCR_running = true;
        yield return new WaitForSeconds(hang_seconds);
        Shooter_1.GetComponent<UbhNwayShot>().Shot();
        // play sound
        sound_ctrler.PlaySound("blueBullet");

        shoot_RCR_running = true;
        yield return new WaitForSeconds(hang_seconds);
        shoot_LCR_running = false;
        shoot_RCR_running = false;
    }

    void shoot_func(string turret_mode) {
        if ((turret_mode == "left") && !shoot_LCR_running)
        {
            StartCoroutine(shoot("left"));
        }

        if ((turret_mode == "right") && !shoot_RCR_running)
        {
            StartCoroutine(shoot("right"));
        }

        if ((turret_mode == "both"))
        {
            if ((!shoot_RCR_running)&&(!shoot_LCR_running)) {
                StartCoroutine(shoot_both());
            }
        }
    }


    IEnumerator Phrase_1_Coro()
    {
        is_phrase1_shoot = true;
        shoot_func("left");
        yield return new WaitForSeconds(1);
        shoot_func("left");
        yield return new WaitForSeconds(1);
        shoot_func("left");
        yield return new WaitForSeconds(5);
        shoot_func("right");
        yield return new WaitForSeconds(1);
        shoot_func("right");
        yield return new WaitForSeconds(1);
        shoot_func("right");
        yield return new WaitForSeconds(5);
        is_phrase1_shoot = false;
    }

    void shoot_phrase_1() {
        if (!is_phrase1_shoot) {
            StartCoroutine(Phrase_1_Coro());
        }
    }


    // Final shoot function struct

    void shoot_phrase() {
        merlin_shoot_signal = Lvl_manager.Current_Boss_Phrase;
        if (merlin_shoot_signal == "Phrase 1") {
            shoot_phrase_1();
        }
        if (merlin_shoot_signal == "Phrase 2") {
            if ((!shoot_RCR_running) && (!shoot_LCR_running))
            {
                StartCoroutine(shoot_both());
            }
        }
    }


	// Update is called once per frame
	void Update () {
        shoot_phrase();
    }
}
