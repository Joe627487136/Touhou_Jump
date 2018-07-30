using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrbController : MonoBehaviour {
    private string colour;
    //public OrbParameters orbParameters;
    public OrbParameters orbParameters;
    private SpriteRenderer spriteRenderer;
    public ManaPool manaPoolScript;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ActivateSprite(1.0f,1.0f));
        if(manaPoolScript == null)
        {
            GameObject manaCircle = GameObject.FindWithTag("ManaCircle");
            manaPoolScript = manaCircle.GetComponent<ManaPool>();
        }

        colour = orbParameters.colour;
    }

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked on the UI");
            
        }
    }

    IEnumerator ActivateSprite(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
    }
}
