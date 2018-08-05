using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingame_InfoPanel_Handler : MonoBehaviour {
    public Text Att_text;
    public Text Passive_text;
    public Text Active_text;
    public Text Life_text;
    private int att_value;
    private int life_value;
    private int passive_skill_value;
    private string passive_skill_type;
    private string[] laser_skill_pattern;
    private string att_value_text;
    private string life_value_text;
    private string active_text;
    private string passive_text;
    private string passive_target;


    // Use this for initialization
    void Start () {
        StartCoroutine(Wait_and_get_data());
    }

    IEnumerator Wait_and_get_data()
    {
        yield return new WaitForSeconds(0.3f);
        att_value = Cha_loader.char_att;
        life_value = Cha_loader.char_def;
        passive_skill_type = Cha_loader.passive_skill_type;
        passive_skill_value = Cha_loader.passive_skill_value;
        laser_skill_pattern = Cha_loader.char_active_skill;
        if (passive_skill_type == "Orb_up_")
        {
            passive_target = Cha_loader.passive_skill_up_orb;
        }
        Update_panel();

    }

    void Update_panel() {
        // Att
        att_value_text = "ATT: " + att_value.ToString();
        Att_text.text = att_value_text;
        // Life
        life_value_text = "Life: " + life_value.ToString();
        Life_text.text = life_value_text;
        // Laser
        active_text = "Laser: "+laser_skill_pattern[0] + laser_skill_pattern[1] + laser_skill_pattern[2];
        Active_text.text = active_text;

        if (passive_skill_type == "Orb_up_") {
            passive_text = "OrbUp:" + passive_skill_value.ToString() + "%";
            if (passive_target == "R") {
                Passive_text.color = Color.red;
            }
            else if (passive_target == "G")
            {
                Passive_text.color = Color.green;
            }
            else if (passive_target == "B")
            {
                Passive_text.color = Color.blue;
            }
        }
        else if (passive_skill_type == "Dodge")
        {
            passive_text = "Dodge:" + passive_skill_value.ToString() + "%";
        }
        Passive_text.text = passive_text;


    }
    // Update is called once per frame
    void Update () {
		
	}
}
