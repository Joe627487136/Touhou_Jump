using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Char_Spreadsheet_Reader : MonoBehaviour {

	private string Char_sheet_file = "/Scripts/Char_spread_sheet.json";
	private string Enemy_sheet_file = "/Scripts/Enemy_spread_sheet.json";

	void Start(){
	}


	public JSONNode Load_Char_Sheet(){
		string filePath = Application.dataPath + Char_sheet_file;
		string dataAsJson = File.ReadAllText (filePath);
		JSONObject Char_Sheet_Json = (JSONObject)JSON.Parse (dataAsJson);

		return Char_Sheet_Json ["Chabox"];

	}

	public JSONNode Load_Enemy_Sheet(string Load_target){
		if (Load_target == "Normal") {
			string filePath = Application.dataPath + Enemy_sheet_file;
			string dataAsJson = File.ReadAllText (filePath);
			JSONObject Char_Sheet_Json = (JSONObject)JSON.Parse (dataAsJson);

			return Char_Sheet_Json ["Normal_enemy"];
		} else if (Load_target == "Boss") {
			string filePath = Application.dataPath + Enemy_sheet_file;
			string dataAsJson = File.ReadAllText (filePath);
			JSONObject Char_Sheet_Json = (JSONObject)JSON.Parse (dataAsJson);

			return Char_Sheet_Json ["Boss_enemy"];
		} else {
			return null;
		}
		
	}
		


}
