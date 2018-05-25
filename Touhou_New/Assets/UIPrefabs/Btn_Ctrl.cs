using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Ctrl : MonoBehaviour {
	public Button startButton;
	public void btn_ini(){
		startButton.interactable = true;
	}
	public void btn_ds(){
		startButton.interactable = false;
	}
}
