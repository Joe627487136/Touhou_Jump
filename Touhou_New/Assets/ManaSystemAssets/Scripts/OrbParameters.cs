using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Orb", menuName = "Orbs/OrbParameters")]
public class OrbParameters : ScriptableObject {
    public Sprite orbSprite;
    public string colour;
    public int damage;
    public string effect;
    public string text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
