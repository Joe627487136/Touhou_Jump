using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Boss_Spawner : MonoBehaviour {
    public Transform Meilin; // First Boss
    public Transform Flandre; // Second Boss
    public Transform Remilia; // Final Boss
    public Transform Yukari; // Hidden Boss

    Char_Spreadsheet_Reader my_reader;
    JSONNode Loader_cha_sheet;
    // Use this for initialization
    void Start () {
        // my_reader = new Char_Spreadsheet_Reader();
        // Loader_boss_sheet = my_reader.Load_Enemy_Sheet(Load_target: "Boss");
    }


    public void Spawn_boss(int type)
    {
        // Spawn kunpaku
        if (type == 0)
        {
            Transform iMeilin = Instantiate(Meilin, this.transform.position, Quaternion.Euler(0, 0, 0));
            iMeilin.transform.parent = this.transform;
        }

        if (type == 1)
        {
            Transform iFlandre = Instantiate(Flandre, this.transform.position, Quaternion.Euler(0, 0, 0));
            iFlandre.transform.parent = this.transform;
        }

        if (type == 2)
        {
            Transform iRemilia = Instantiate(Remilia, this.transform.position, Quaternion.Euler(0, 0, 0));
            iRemilia.transform.parent = this.transform;
        }

        if (type == 3)
        {
            Transform iYukari = Instantiate(Yukari, this.transform.position, Quaternion.Euler(0, 0, 0));
            iYukari.transform.parent = this.transform;
        }

    }



    // Update is called once per frame
    void Update () {
		
	}
}
