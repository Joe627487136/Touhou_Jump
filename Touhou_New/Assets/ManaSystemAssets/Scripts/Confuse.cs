using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confuse : MonoBehaviour {

    private Vector3 initialPosition;
    private int confuse_ticks;
    private float maxDisplacement;


    // Use this for initialization
    void Start () {
        confuse_ticks = 50;
        maxDisplacement = 10.0f;
        initialPosition = gameObject.transform.position;
        InvokeRepeating("RandomMoving", 0.0f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RandomMoving()
    {
        
        Vector3 rand = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f),0);
        Vector3 offset = gameObject.transform.position + rand;
        if(Vector3.Distance(initialPosition, offset)> maxDisplacement)
        {
            offset = gameObject.transform.position - rand * Time.deltaTime;
        }
        gameObject.transform.position = offset;
        confuse_ticks--;

        if(confuse_ticks == 0)
        {
            gameObject.transform.position = initialPosition;
            CancelInvoke("RandomMoving");
        }

    }
}
