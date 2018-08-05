using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flandre_bullet : MonoBehaviour {
    public GameObject Shoot_Circle;
    private GameObject Shooter;
    private bool is_shooting;
    public static string flandre_shoot_signal;
    private bool is_sealing;
    public Transform seal;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;





    void Start () {
        is_shooting = false;
        Shooter = Shoot_Circle.transform.GetChild(0).gameObject;

        Audio_controller = GameObject.FindGameObjectWithTag("Audio_manager");
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();
    }

    IEnumerator shoot_coro(int hang_seconds)
    {
        is_shooting = true;
        Shooter.GetComponent<UbhNwayShot>().Shot();
        // play sound
        sound_ctrler.PlaySound("blueBullet");

        yield return new WaitForSeconds(hang_seconds);
        is_shooting = false;
    }

    IEnumerator seal_coro()
    {
        is_sealing = true;
        Transform player_holder = GameObject.Find("Player_Holder").transform;
        Vector3 seal_pos = new Vector3(player_holder.position.x, player_holder.position.y, -6.5f);
        Transform iseal = Instantiate(seal, seal_pos, Quaternion.Euler(0, 0, 0));
        iseal.transform.parent = player_holder;
        yield return new WaitForSeconds(15);
        is_sealing = false;
    }

    void spawn_seal() {
        if (!is_sealing)
        {
            StartCoroutine(seal_coro());
        }
    }

    void shoot(int hang_seconds) {
        if (!is_shooting) {
            StartCoroutine(shoot_coro(hang_seconds));
        }
    }


    void shoot_phrase()
    {
        flandre_shoot_signal = Lvl_manager.Current_Boss_Phrase;
        if (flandre_shoot_signal == "Phrase 1")
        {
            shoot(5);
        }
        if (flandre_shoot_signal == "Phrase 2")
        {
            shoot(3);
            spawn_seal();
        }
    }

    // Update is called once per frame
    void Update () {
        shoot_phrase();
	}
}
