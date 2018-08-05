using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_scene_loader : MonoBehaviour {
    public GameObject Win_text;
    public GameObject Dead_text;
    public Text wave_df_text;
    public Text boss_df_text;
    public Text Total_earn_text;
    public static int total_earn;
    private int wave_df_amount;
    private int boss_df_amount;
    private int pass_status;
    public AudioClip win_clip;
    public AudioClip lose_clip;

    // Use this for initialization
    void Start () {
        wave_df_amount = PlayerPrefs.GetInt("Wave_Defeated_amount");
        boss_df_amount = PlayerPrefs.GetInt("Boss_Defeated_amount");
        total_earn = wave_df_amount * 200 + boss_df_amount * 1000;

        wave_df_text.text = "Wave(200G): " + wave_df_amount.ToString();
        boss_df_text.text = "Wave(1000G): " + boss_df_amount.ToString();
        Total_earn_text.text = "Total Gold: " + total_earn.ToString();

        pass_status = PlayerPrefs.GetInt("Pass_status");

        // Define Win/ Lose
        if (pass_status == 0)
        {
            Win_text.SetActive(false);
            Dead_text.SetActive(true);
            set_bgm(lose_clip);
        }
        if (pass_status == 1)
        {
            Win_text.SetActive(true);
            Dead_text.SetActive(false);
            set_bgm(win_clip);
        }
    }

    void set_bgm(AudioClip my_clip) {
        Transform main_cam_tf = GameObject.Find("Main Camera").transform;
        AudioSource cam_as = main_cam_tf.GetComponent<AudioSource>();
        cam_as.clip = my_clip;
        cam_as.Play();
    }

    public void add_to_bank() {
        int my_current_money = DataManager.money;
        print(my_current_money);
        int new_to_save_money = my_current_money + total_earn;
        DataManager.money = new_to_save_money;
        SnL.request_for_save_m = true;
        print(DataManager.money);
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
