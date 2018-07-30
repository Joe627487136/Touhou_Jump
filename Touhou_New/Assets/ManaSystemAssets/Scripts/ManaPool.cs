using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.


public class ManaPool : MonoBehaviour {
    const string RED = "R";
    const string BLUE = "B";
    const string GREEN = "G";
    const string NULL = "Null";

    List<string> manaDist;
    private int ptr;
    readonly string combi = "RRRGB";

    // Variables pertaining to spawn points
    private GameObject spawnPoints;

    // Orb prefabs
    public GameObject redOrb;
    public GameObject blueOrb;
    public GameObject greenOrb;

    public Image mana_gauge;
    Dictionary<Vector3, GameObject> orbPlacements;
    public float manaFillRate;

    // Use this for initialization
    void Start() {
        mana_gauge.fillAmount = 0;
        manaDist = new List<string>();
        orbPlacements = new Dictionary<Vector3, GameObject>();
        spawnPoints = GameObject.Find("SpawnPoints");
        manaFillRate = 1.40f;


        for (int i = 0; i < combi.Length; i++)
        {
            manaDist.Add("" + combi[i]);
            string orbType = manaDist[i];
            Transform spawnPoint = spawnPoints.transform.GetChild(i);
            init_mana_pool(orbType, spawnPoint);
        }

        //CheckEmptySlot(orbPlacements);



    }

    void init_mana_pool(string orbType, Transform spawnPoint)
    {
        GameObject orb= redOrb;
        switch (orbType)
        {
            case "R":
                orb = Instantiate(redOrb, spawnPoint.position, Quaternion.identity);
                break;
            case "G":
                orb = Instantiate(greenOrb, spawnPoint.position, Quaternion.identity);
                break;
            case "B":
                orb = Instantiate(blueOrb, spawnPoint.position, Quaternion.identity);
                break;

        }
        orbPlacements.Add(spawnPoint.position, orb);
        Debug.Log(orbPlacements);
    }
	
	// Update is called once per frame
	void Update () {
        if(mana_gauge.fillAmount < 1)
        {
            mana_gauge.fillAmount += 1.0f/manaFillRate*Time.deltaTime;
        }
        else
        {
            mana_gauge.fillAmount = 0;
        }
	
	}
    void FixedUpdate()
    {
        /*
        Reshuffle(manaDist);
        Debug.Log("Mana Distribution: " + manaDist[1]);
        string sequence = "";
        foreach (string i in manaDist)
            sequence += i;
        Debug.Log(sequence);
        */

    }

    void CheckEmptySlot(Dictionary<Vector3, string> orbPlacements)
    {
        foreach (KeyValuePair<Vector3, string> orbState in orbPlacements)
        {
            //Now you can access the key and value both separately from this attachStat as:
            Vector3 k = orbState.Key;
            string v = orbState.Value;
            if(v == NULL)
            {
                Debug.Log("Missing Orb location detected");
                // TODO: Spawn an orb here 
                break;
            }
        }
    }


    void Reshuffle(List<string> texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Count; t++)
        {
            string tmp = texts[t];
            int r = Random.Range(t, texts.Count);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
