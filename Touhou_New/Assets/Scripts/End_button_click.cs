using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_button_click : MonoBehaviour {
    private int click_count;
    private bool writing_one_shot_flag;
    private bool scene_one_shot_flag;
    // Use this for initialization

    void Start() {
        click_count = 0;
        writing_one_shot_flag = true;
        scene_one_shot_flag = true;
    }

    public void Accumulate_click_count () {
        click_count += 1;
    }

    public void Load_to_menu()
    {
        StartCoroutine(Load_to_Menu_coro());
    }
    IEnumerator Load_to_Menu_coro()
    {
        float fadeTime = GameObject.Find("SceneManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime - 0.1f);
        SceneManager.LoadScene("S1");
    }

    void One_shot_over_write() {
        if (click_count == 1 && writing_one_shot_flag) {
            End_scene_loader esl = new End_scene_loader();
            esl.add_to_bank();
            writing_one_shot_flag = false;
        }
    }

    void One_shot_back_to_menu()
    {
        if (click_count >= 2 && scene_one_shot_flag)
        {
            print("Load menu");
            scene_one_shot_flag = false;
            Load_to_menu();
        }
    }

    // Update is called once per frame
    void Update()
    {
        One_shot_over_write();
        One_shot_back_to_menu();
    }
}
