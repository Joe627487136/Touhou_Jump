using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_to_end : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }
    public void Load_End()
    {
        StartCoroutine(ChangeLeveltoEnd());
    }
    IEnumerator ChangeLeveltoEnd()
    {
        float fadeTime = GameObject.Find("SceneManager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime - 0.1f);
        SceneManager.LoadScene("End_scene");
    }
}
