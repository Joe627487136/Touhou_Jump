using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongController : MonoBehaviour {
    // Audio sources defined here
    public AudioSource meiLinTheme;
    public AudioSource flandreTheme;
    public AudioSource remiliaTheme;
    public AudioSource deathSound;
    public AudioSource gameOver;
    public AudioSource victory;
    public AudioSource bossWarning;
    public AudioSource enemyWave;
    public AudioSource damage;
    public AudioSource laser;
    public AudioSource specialAttack;
    public AudioSource blueBullet;
    public AudioSource Endless_dungeon;

    
   
	// Use this for initialization
	void Start () {
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "meiLinTheme":
                meiLinTheme.Play();
                break;
            case "flandreTheme":
                flandreTheme.Play();
                break;
            case "remiliaTheme":
                remiliaTheme.Play();
                break;
            case "deathSound":
                deathSound.Play();
                break;
            case "gameOver":
                gameOver.Play();
                break;
            case "victory":
                victory.Play();
                break;
            case "bossWarning":
                bossWarning.Play();
                break;
            case "enemyWave":
                enemyWave.Play();
                break;
            case "damage":
                if (!damage.isPlaying) {
                    damage.Play();
                }
                break;
            case "laser":
                laser.Play();
                break;
            case "specialAttack":
                specialAttack.Play();
                break;
            case "blueBullet":
                blueBullet.Play();
                break;
            case "Endless_dungeon":
                Endless_dungeon.Play();
                break;


        }
    }

    void StopSound(string soundName)
    {
        switch (soundName)
        {
            case "meiLinTheme":
                meiLinTheme.Stop();
                break;
            case "flandreTheme":
                flandreTheme.Stop();
                break;
            case "remiliaTheme":
                remiliaTheme.Stop();
                break;
            case "deathSound":
                deathSound.Stop();
                break;
            case "gameOver":
                gameOver.Stop();
                break;
            case "victory":
                victory.Stop();
                break;
            case "bossWarning":
                bossWarning.Stop();
                bossWarning.Stop();
                break;
            case "enemyWave":
                enemyWave.Stop();
                break;
            case "damage":
                damage.Stop();
                break;
            case "laser":
                laser.Stop();
                break;
            case "specialAttack":
                specialAttack.Stop();
                break;
            case "blueBullet":
                blueBullet.Stop();
                break;
        
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

 
    void OnMouseDown()
    {
        PlaySound("damage");
        //StopCoroutine(fadeSound1);
    }

    /* To perform cross fade, you may use this function and add it into the stop Audio Function 
     IEnumerator fadeSound1 = FadeOut(deathSound, 1.8f);
     StartCoroutine(fadeSound1);
         */

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            print(audioSource.volume);

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
