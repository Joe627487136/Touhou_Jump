using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour 
{
	[SerializeField]
	private string m_animationPropertyName;

	[SerializeField]
	private GameObject m_initialScreen;

	[SerializeField]
	private List<GameObject> m_navigationHistory;

	private bool cooldown = false;
	private Sprite cha_spr;
	private string load_out;
	private string rarity;
	private int cha_index;
	private int score;
	public static bool deduce_letgo = false;
	public GameObject sec_p;
	public static bool is_summmon_pop = false;


	void Update(){
		check_perdraw ();
		parse_index ();
	}

	public void GoBack()
	{
		if (IsPointerOverUIObject()) {
			if (m_navigationHistory.Count > 1) {
				int index = m_navigationHistory.Count - 1;
				Animate (m_navigationHistory [index - 1], true);

				GameObject target = m_navigationHistory [index];
				m_navigationHistory.RemoveAt (index);
				Animate (target, false);
			}
		}
	}

	public void GoToMenu(GameObject target)
	{
		if (IsPointerOverUIObject()) {
			if (target == null) {
				return;
			}

			if (m_navigationHistory.Count > 0) {
				Animate (m_navigationHistory [m_navigationHistory.Count - 1], false);
			}

			m_navigationHistory.Add (target);
			Animate (target, true);
		}
	}

	private void Animate(GameObject target, bool direction)
	{
		if (target == null)
		{
			return;
		}

		target.SetActive(true);

		Canvas canvasComponent = target.GetComponent<Canvas>();
		if (canvasComponent != null)
		{
			canvasComponent.overrideSorting = true;
			canvasComponent.sortingOrder = m_navigationHistory.Count;
		}

		Animator animatorComponent = target.GetComponent<Animator>();
		if (animatorComponent != null)
		{
			animatorComponent.SetBool(m_animationPropertyName, direction);
		}
	}

	private void Awake()
	{
		m_navigationHistory = new List<GameObject>{m_initialScreen};
	}

	public void disable (GameObject target){
		if (target == null) {
			return;
		}
		if (m_navigationHistory.Count > 0) {
			target.transform.GetComponent<CanvasGroup> ().alpha = 0.6f;
			target.transform.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	public void enable (GameObject target){
		if (IsPointerOverUIObject()) {
			if (target == null) {
				return;
			}
			if (target.name == "Summon_Pop"&&!deduce_letgo) {
				print (sec_p.name);
				enable_NM (sec_p);
			}
			if (target.name == "Summon_Pop"&&deduce_letgo) {
				reduce_perdraw ();
				m_navigationHistory.Add (target);
				Animate (target, true);
			}
			if (target.name != "Summon_Pop") {
				m_navigationHistory.Add (target);
				Animate (target, true);
			}
		}
	}

	public void enable_NM(GameObject target){
		m_navigationHistory.Add (target);
		Animate (target, true);
	}

	public void return_dis (GameObject target){
		if (target == null) {
			return;
		}
		if (m_navigationHistory.Count > 0) {
			target.transform.GetComponent<CanvasGroup> ().alpha = 1f;
			target.transform.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}

	public void fadeout_enb (GameObject target){
		if (target == null) {
			return;
		}
		if (m_navigationHistory.Count > 1&&cooldown==false) {
			int newindex = m_navigationHistory.Count - 1;
			GameObject mytar = m_navigationHistory [newindex];
			m_navigationHistory.RemoveAt (newindex);
			Animate (mytar, false);
			OnMouseDown ();
		}
	}

	void ResetCooldown(){
		cooldown = false;
	}

	void OnMouseDown() {
		if ( cooldown == false ) {
			Invoke("ResetCooldown", 0.5f);
			cooldown = true;
		}
	}

	public void getobj(Image currentimg)
	{
		cha_spr = currentimg.sprite;
	}
	public void sendinfo(Chamanager cs){
		cs.my_cha_Image = cha_spr;
		cs.my_rarity = rarity;
		cs.current_index = cha_index;
		cs.load_index_flag = true;
	}
	public void overide_index(int index){
		cha_index = index;
	}
	public void overide_rarity(string str){
		rarity = str;
	}
	public void request_load(){
		SnL.request_for_load = true;
	}

	public void reduce_perdraw(){
		if (deduce_letgo == false) {
			return;
		}
		if (deduce_letgo == true) {
			DataManager.money -= 1000;
			SnL.mon = DataManager.money;
		}
	}

	public void parse_index(){
		string current_page = m_navigationHistory[m_navigationHistory.Count-1].name;
		if (current_page == "Summon_Pop") {
			is_summmon_pop = true;
		} else {
			is_summmon_pop = false;
		}
	}

	public void check_perdraw(){
		score = DataManager.money;
		if (score < 1000) {
			deduce_letgo = false;
			return;
		} else {
			deduce_letgo = true;
		}
	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}
		
}
