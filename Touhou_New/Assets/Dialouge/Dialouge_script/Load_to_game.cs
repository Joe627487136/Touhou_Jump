using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_to_game : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
    public void Load_S2()
    {
        StartCoroutine(ChangeLeveltoS2());
    }
    IEnumerator ChangeLeveltoS2()
    {
        float fadeTime = GameObject.Find("SceneManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime - 0.1f);
        SceneManager.LoadScene("S2_jump");
    }
}
