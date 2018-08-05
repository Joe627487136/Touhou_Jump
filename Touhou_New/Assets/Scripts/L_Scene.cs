using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L_Scene : MonoBehaviour {
	public void Load_S2(int level_index)
    {
		StartCoroutine (ChangeLeveltoS2 (level_index));
	}
	IEnumerator ChangeLeveltoS2(int level_index){
        PlayerPrefs.SetInt("Level_index", level_index);
        float fadeTime = GameObject.Find ("SceneManager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime-0.1f);
        if (level_index == 1) {
            SceneManager.LoadScene("Meiling-intro");
        }
        if (level_index == 2)
        {
            SceneManager.LoadScene("Flandre-intro");
        }
        if (level_index == 3)
        {
            SceneManager.LoadScene("Remilia-intro");
        }
        if (level_index == 4)
        {
            SceneManager.LoadScene("S2_jump");
        }
    }
}
