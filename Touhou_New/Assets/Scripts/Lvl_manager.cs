using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl_manager : MonoBehaviour {
    public GameObject Wave_Panel;
    public GameObject Boss_Panel;
    public GameObject N_Spawner;
    private bool is_spawn_coro;
    private bool to_spawn_boss;
    private bool spawn_finished;
    private int current_enemy_amount;
    public GameObject Boss_Holder;
    private int Wave_count;
    public static string Current_Boss_Phrase;
    private bool is_boss_spawned;
    private bool is_wave_spawned;
    private bool is_boss_defeated;
    private bool is_wave_defeated;
    public static int amount_wave_defeated;
    public static int amount_boss_defeated;
    private int level_index;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    public GameObject BG4;
    public GameObject Audio_controller;
    ThemeSongController sound_ctrler;

    public void Load_End_Scene()
    {
        StartCoroutine(Change_to_end_scene());
    }
    IEnumerator Change_to_end_scene()
    {
        float fadeTime = GameObject.Find("SceneManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime - 0.1f);
        if (level_index == 1)
        {
            SceneManager.LoadScene("Meiling-outro");
        }
        if (level_index == 2)
        {
            SceneManager.LoadScene("Flandre-outro");
        }
        if (level_index == 3)
        {
            SceneManager.LoadScene("Remilia-outro");
        }
        if (level_index == 4)
        {
            SceneManager.LoadScene("End_scene");
        }
    }

    void Load_BG() {
        BG1.SetActive(false);
        BG2.SetActive(false);
        BG3.SetActive(false);
        BG4.SetActive(false);
        if (level_index == 1)
        {
            BG1.SetActive(true);
        }
        if (level_index == 2)
        {
            BG2.SetActive(true);
        }
        if (level_index == 3)
        {
            BG3.SetActive(true);
        }
        if (level_index == 4)
        {
            BG4.SetActive(true);
        }
    }



    // Use this for initialization
    void Start() {
        // Get Audio ctrl
        sound_ctrler = Audio_controller.transform.GetComponent<ThemeSongController>();

        // Wave count to 0
        Wave_count = 0;

        // Starto!@!
        sound_ctrler.PlaySound("enemyWave");

        // Deactivate UI
        Wave_Panel.SetActive(false);
        Boss_Panel.SetActive(false);
        is_spawn_coro = false;
        spawn_finished = false;
        to_spawn_boss = false;
        Current_Boss_Phrase = "Phrase 1";
        //
        is_boss_defeated = false;
        is_wave_defeated = false;
        is_boss_spawned = false;
        is_wave_spawned = false;
        amount_wave_defeated = 0;
        amount_boss_defeated = 0;

        //
        level_index = PlayerPrefs.GetInt("Level_index");
        PlayLvlTheme(level_index-1);
        Load_BG();
    }

    void Spawn_Normal(int current_type, int current_amount) {
        Normal_Enemy_spawner spawn_handler = N_Spawner.GetComponent<Normal_Enemy_spawner>();
        spawn_handler.Spawn_normal_enemy_wave(type: current_type, amount: current_amount);
    }

    void Spawn_Boss(int current_type) {
        Boss_Spawner boss_spawner = Boss_Holder.GetComponent<Boss_Spawner>();
        boss_spawner.Spawn_boss(type: current_type);
    }

    void Reset_spawning_stats() {
        current_enemy_amount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (current_enemy_amount == 0 && is_wave_spawned == true) {
            print("Wave Defeated");
            amount_wave_defeated += 1;
            is_wave_spawned = false;
        }

        if (current_enemy_amount == 0 && is_boss_spawned == true)
        {
            print("Boss Defeated");
            amount_boss_defeated += 1;
            is_boss_spawned = false;
        }

        if (current_enemy_amount == 0 && spawn_finished == true) {
            Wave_count += 1;
            //print(Wave_count);
            is_spawn_coro = false;
            if (Wave_count == 2) {
                print("Spawn_boss_alr");
                to_spawn_boss = true;
            }
        }
    }

    void Check_for_end_game() {
        if ((level_index == 1) || (level_index == 2) || (level_index == 3)) {
            if (amount_boss_defeated == 1) {
                PlayerPrefs.SetInt("Wave_Defeated_amount", amount_wave_defeated);
                PlayerPrefs.SetInt("Boss_Defeated_amount", amount_boss_defeated);
                PlayerPrefs.SetInt("Pass_status", 1);
                Load_End_Scene();
            }
        }

    }



    IEnumerator Spawn_Wave()
    {
        //Set wave panel active for 1s
        spawn_finished = false;
        is_spawn_coro = true;
        Wave_Panel.SetActive(true);

        // Play sound
        

        yield return new WaitForSeconds(2);
        Wave_Panel.SetActive(false);
        // Random a normal enemy type and num
        int ran_enemy_index = Random.Range(0, 2);
        int spawn_amout = Random.Range(8, 16);
        Spawn_Normal(ran_enemy_index, spawn_amout);
        yield return new WaitForSeconds(1);
        spawn_finished = true;
        is_wave_spawned = true;
    }


    IEnumerator Spawn_Boss_Wave(int level_index)
    {
        //Set wave panel active for 1s
        spawn_finished = false;
        is_spawn_coro = true;
        Boss_Panel.SetActive(true);

        // Play boss warning 
        sound_ctrler.PlaySound("bossWarning");

        yield return new WaitForSeconds(3);
        Boss_Panel.SetActive(false);
        // Random a normal enemy type and num
        // 0 - Meilin
        // 1 - Flandre
        // 2 - Remilia
        if (level_index == 1) {
            Spawn_Boss(level_index-1);
        }
        else if (level_index == 2)
        {
            Spawn_Boss(level_index - 1);
        }
        else if (level_index == 3)
        {
            Spawn_Boss(level_index - 1);
        }
        else if (level_index == 4)
        {
            int bomba_tick = Random.Range(0, 100);
            if (bomba_tick < 8)
            {
                Spawn_Boss(3);
                print("Wild Yukari Appear!!!");
            }
            else if (bomba_tick >= 8)
            {
                int ran_boss_index = Random.Range(0, 3);
                Spawn_Boss(ran_boss_index);
            }

            // Reset Wave Count
            Wave_count = 0;
        }
        yield return new WaitForSeconds(1);
        spawn_finished = true;
        to_spawn_boss = false;
        is_boss_spawned = true;
    }

    void PlayLvlTheme(int lvl_ID)
    {
        switch (lvl_ID)
        {
            case 0:
                sound_ctrler.PlaySound("meiLinTheme");
                break;
            case 1:
                sound_ctrler.PlaySound("flandreTheme");
                break;
            case 2:
                sound_ctrler.PlaySound("remiliaTheme");
                break;
            case 3:
                sound_ctrler.PlaySound("Endless_dungeon");
                break;

        }
    }


    void Update () {
        if (is_spawn_coro == false && to_spawn_boss == false)
        {
            StartCoroutine(Spawn_Wave());
        }
        else if (is_spawn_coro == false && to_spawn_boss == true)
        {
            StartCoroutine(Spawn_Boss_Wave(level_index));
        }
        Reset_spawning_stats();
        Check_for_end_game();
    }
}
