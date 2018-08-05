using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remilia_bullet : MonoBehaviour {


    public GameObject Shoot_Circle;
    private GameObject Shooter;
    private bool is_shooting;
    public static string remilia_shoot_signal;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;


    // Use this for initialization
    void Start()
    {
        Audio_controller = GameObject.FindGameObjectWithTag("Audio_manager");
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();

        is_shooting = false;
        Shooter = Shoot_Circle.transform.GetChild(0).gameObject;
    }

    IEnumerator shoot_coro(int hang_seconds, float bullet_speed, float acc_speed)
    {
        is_shooting = true;
        Shooter.GetComponent<UbhSpiralMultiShot>()._BulletSpeed = bullet_speed;
        Shooter.GetComponent<UbhSpiralMultiShot>()._AccelerationSpeed = acc_speed;
        Shooter.GetComponent<UbhSpiralMultiShot>().Shot();
        // play sound
        sound_ctrler.PlaySound("blueBullet");

        yield return new WaitForSeconds(hang_seconds);
        is_shooting = false;
    }

    void shoot(int hang_seconds, float bullet_speed, float acc_speed)
    {
        if (!is_shooting)
        {
            StartCoroutine(shoot_coro(hang_seconds, bullet_speed, acc_speed));
        }
    }


    void shoot_phrase()
    {
        remilia_shoot_signal = Lvl_manager.Current_Boss_Phrase;
        if (remilia_shoot_signal == "Phrase 1")
        {
            shoot(9, 4.0f, 1.0f);
        }
        if (remilia_shoot_signal == "Phrase 2")
        {
            shoot(11, 2.25f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        shoot_phrase();
    }
}
