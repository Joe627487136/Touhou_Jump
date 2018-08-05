using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SnL : MonoBehaviour {
	//Setup Register
	public static bool request_for_load = false;
	public static bool request_for_load_index = false;
	public static bool request_for_save = false;
	public static bool request_for_save_m = false;
	public static bool request_for_save_index = false;
	public static bool[] request_boollist = new bool[Cha_Box.chabox_children_count];
	public static int mon;
	public static int select_cha_index;

	void Awake() {
			DontDestroyOnLoad(this);
			if (FindObjectsOfType(GetType()).Length > 1)
			{
				Destroy(gameObject);
			}
	}

	void Start(){
		// Default_Overide (); // Give me money!!!!!

		//Load previous selected index

		if (check_opencount()) {
			Default_Overide ();
		}
		Load();
		SnL.request_for_load_index = true;
		//Debug.Log(Application.persistentDataPath);
	}
	void Update(){
		if (request_for_save) {
			Save (request_boollist);
			Save (mon);
			request_for_save = false;
			//Debug.Log ("Data logged");
		}
		if (request_for_save_m) {
			Save (DataManager.money);
			request_for_save_m = false;
			//Debug.Log ("Data logged");
		}
		if (request_for_save_index) {
			Save_cha_index ();
			request_for_save_index = false;
			//Debug.Log ("Index logged");
		}
		if (request_for_load) {
			Load ();
			request_for_load = false;
			//Debug.Log ("Data loaded");
		}
		if (request_for_load_index) {
			Load_ChaIndex ();
			request_for_load_index = false;
			//Debug.Log ("Index loaded");
		}
	}

	public bool[] register_bundle(){
		int total_num = Cha_Box.chabox_children_count;
		bool[] locklist = new bool[total_num];
		for (int i=0; i < total_num; i++) {
			locklist [i] = false;
		}
		locklist [0] = true;
		return locklist;
	}

	bool check_opencount(){
		return (!File.Exists (Application.persistentDataPath + "/game_D.octo"));
	}
	void Default_Overide(){
		print ("SHOW ME TAAAAAAAA MONEYYYYYYYYYYY BOIIIIIIII!!!!!!!!!!!!");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/cha_base.octo");
		Saver saver = new Saver ();
		saver.locklist= register_bundle ();
		bf.Serialize (fs, saver);
		fs.Close ();
		FileStream fs2 = File.Create (Application.persistentDataPath + "/game_M.octo");

		//Give a starting money
		saver.m = 800000;
		//

		bf.Serialize (fs2, saver);
		fs2.Close ();
		FileStream fs3 = File.Create (Application.persistentDataPath + "/game_D.octo");
		saver.open_alr = true;
		bf.Serialize (fs3, saver);
		fs3.Close ();
		FileStream fs4 = File.Create (Application.persistentDataPath + "/selectcha_index.octo");
		saver.SelectedChaindex = 0;
		bf.Serialize (fs4, saver);
		fs4.Close ();
		Debug.Log ("Overide suceeded!");
	}

	void Save(bool[] mylist){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/cha_base.octo");
		Saver saver = new Saver ();
		//		//Do saving here//
		saver.locklist = mylist;
		bf.Serialize (fs, saver);
		fs.Close ();
		Debug.Log ("Save suceeded!");
	}

	public void Save(int money){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath + "/game_M.octo");
		Saver saver = new Saver ();
		//		//Do saving here//
		saver.m = money;
		bf.Serialize (fs, saver);
		fs.Close ();
		Debug.Log ("Save suceeded!");
	}
	void Save_cha_index(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Create (Application.persistentDataPath +"/selectcha_index.octo");
		Saver saver = new Saver ();
		//		//Do saving here//
		saver.SelectedChaindex = select_cha_index;
		bf.Serialize (fs, saver);
		fs.Close ();
		Debug.Log ("Save suceeded!");
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/cha_base.octo")) {
			String datapath = Application.persistentDataPath + "/cha_base.octo";
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (datapath,FileMode.Open);
			Saver saver = (Saver)bf.Deserialize (fs);

			fs.Close ();
			DataManager.locklist = saver.locklist;
			Debug.Log ("Load cha suceeded!");
		}

		if (File.Exists (Application.persistentDataPath + "/game_M.octo")) {
			String datapath = Application.persistentDataPath + "/game_M.octo";
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (datapath,FileMode.Open);
			Saver saver = (Saver)bf.Deserialize (fs);
			fs.Close ();
			DataManager.money = saver.m;
			Debug.Log ("Load m suceeded!");
		}
	}
	public void Load_ChaIndex(){
		if (File.Exists (Application.persistentDataPath + "/selectcha_index.octo")) {
			String datapath = Application.persistentDataPath + "/selectcha_index.octo";
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (datapath,FileMode.Open);
			Saver saver = (Saver)bf.Deserialize (fs);
			fs.Close ();
			DataManager.slct_cha_index = saver.SelectedChaindex;
			//print (DataManager.slct_cha_index);
			Debug.Log ("Load cha_index suceeded!");
		}
	}

	[Serializable]
	class Saver{
		static int total_num = Cha_Box.chabox_children_count;
		public bool open_alr;
		public bool[] locklist = new bool[total_num];
		public int m;
		public int SelectedChaindex;
	}
}
