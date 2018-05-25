using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sum_manager : MonoBehaviour {
	int total_num = Cha_Box.chabox_children_count;
	public bool[] summonlist = new bool[Cha_Box.chabox_children_count];
	public List<Transform> clist = new List<Transform> ();
	public static List<Image>imglist = new List<Image>();
	public List<int> n_index = new List<int> ();
	public List<int> r_index = new List<int> ();
	public List<int> sr_index = new List<int> ();
	public static int drawindex;
	public static string rarity;
	// Use this for initialization
	void Start () {
		register_index_list ();
		Get_imgspritelist ();
	}

	public void Random_draw(){
		//Set default Remu to true
		if (MenuManager.deduce_letgo == true) {
			summonlist [0] = true;
			int pointer = Random.Range (0, 99);
			if (pointer >= 0 && pointer < 45) {
				//Spawn N
				int outindex = random_selector (n_index);
				drawindex = outindex;
				rarity = "N";
				summonlist [drawindex] = true;
				SnL.request_boollist = summonlist;
				SnL.request_for_save = true;
				SnL.request_for_load = true;
			}
			if (pointer >= 45 && pointer < 80) {
				//Spawn R
				int outindex = random_selector (r_index);
				drawindex = outindex;
				rarity = "R";
				summonlist [drawindex] = true;
				SnL.request_boollist = summonlist;
				SnL.request_for_save = true;
				SnL.request_for_load = true;
			}
			if (pointer >= 80 && pointer <= 99) {
				//Spawn SR
				int outindex = random_selector (sr_index);
				drawindex = outindex;
				rarity = "SR";
				summonlist [drawindex] = true;
				SnL.request_boollist = summonlist;
				SnL.request_for_save = true;
				SnL.request_for_load = true;
			}
		}
	}



	void Get_imgspritelist(){
		GameObject chabox = GameObject.FindGameObjectWithTag ("ChaB2");
		int children_count = chabox.transform.childCount;
		for (int i = 0; i < children_count; i++) {
			clist.Add (chabox.transform.GetChild (i));
		}
		for (int i = 0; i < children_count; ++i) {
			Image img = clist[i].Find("Image").GetComponent<Image>();
			imglist.Add (img);
		}
	}
	void register_index_list(){
		n_index.Add (0);//Remu
		n_index.Add (1);//Malisa
		n_index.Add (2);//Lumia
		n_index.Add (3);//Yousei
		n_index.Add (4);//9
		n_index.Add (5);//komo
		n_index.Add (8);//meilin
		n_index.Add (11);//Alice
		n_index.Add (12);//S1
		n_index.Add (13);//S2
		n_index.Add (14);//S3
		n_index.Add (17);//chen
		n_index.Add (21);//jiachong
		n_index.Add (22);//mys
		n_index.Add (24);//Tei
		n_index.Add (34);//tuanzimei
		n_index.Add (35);//tuanzijie
		n_index.Add (37);//Nitori
		n_index.Add (38);//hua
		n_index.Add (44);//zhizhu
		n_index.Add (45);//tong
		n_index.Add (52);//shu
		n_index.Add (53);//san
		//
		r_index.Add (9);//pad
		r_index.Add (15);//yomeng
		r_index.Add (18);//Ran
		r_index.Add (23);//huiying
		r_index.Add (28);//aya
		r_index.Add (29);//rabbit
		r_index.Add (30);//shouban
		r_index.Add (32);//ding
		r_index.Add (36);//ribbon
		r_index.Add (39);//sanae
		r_index.Add (42);//cibao
		r_index.Add (46);//wohaoheng
		r_index.Add (48);//jue
		r_index.Add (49);//neko
		r_index.Add (54);//yun
		r_index.Add (55);//cap
		r_index.Add (56);//shixiong
		r_index.Add (41);//Gua
		r_index.Add (27);//meko
		r_index.Add (58);//shou
		//
		sr_index.Add(7);//rem
		sr_index.Add(10);//fulan
		sr_index.Add(16);//yoyo
		sr_index.Add(19);//zi
		sr_index.Add(20);//suika
		sr_index.Add(25);//yonglin
		sr_index.Add(26);//Neet
		sr_index.Add(31);//huama
		sr_index.Add(33);//siji
		sr_index.Add(40);//Nanako
		sr_index.Add(43);//teiso
		sr_index.Add(47);//red3
		sr_index.Add(50);//bakabird
		sr_index.Add(51);//juesis
		sr_index.Add(57);//Moto
		sr_index.Add(59);//SDRenu
		sr_index.Add(60);//SDMalisa
		sr_index.Add(61);//SDPAD
		sr_index.Add(62);//SDSanae
	}
	public int random_selector(List<int> mylist){
		int count = mylist.Count;
		int index = Random.Range (0, count);
		return mylist [index];
	}
}
