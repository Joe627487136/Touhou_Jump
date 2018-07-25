using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Char_Spreadsheet_Reader : MonoBehaviour {

	private string Char_sheet_file = "/Scripts/Char_spread_sheet.json";

	void Start(){
	}


	public JSONNode Load_Char_Sheet(){
		string filePath = Application.dataPath + Char_sheet_file;
		print ("Char_sheet Loaded");
		string dataAsJson = File.ReadAllText (filePath);
		JSONObject Char_Sheet_Json = (JSONObject)JSON.Parse (dataAsJson);

		return Char_Sheet_Json ["Chabox"];

	}


}
