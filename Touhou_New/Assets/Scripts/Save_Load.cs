using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Save_Load: MonoBehaviour {
	//Setup Register
	public static bool request_for_load = false;
	public static bool request_for_load_index = false;
	public static bool request_for_save = false;
	public static bool request_for_save_index = false;
	public static bool[] request_boollist = new bool[Cha_Box.chabox_children_count];
	public static int mon;
	public static int select_cha_index;

	void Start(){
	}
	void Update(){
		if (request_for_load_index) {
			Load_ChaIndex ();
			request_for_load_index = false;
			//Debug.Log ("Index loaded");
		}
	}
	void Save(int money){
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
