using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Count : MonoBehaviour {
	private Text time_ui;
	private Text escape_ui;
	private float dcount = 0.0f;
	private float esc_count = 10.0f;
	private bool finish_flag = false;
	private GameObject manager;
	private ItemManager item_manager;
	public int count;

	void Awake(){
		dcount = PlayerPrefs.GetFloat("Time");
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
		time_ui = GameObject.Find("Canvas/TimePanel/Time").GetComponent<Text>();
		escape_ui = GameObject.Find("Canvas/EscapePanel/EscapeTime").GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(!finish_flag){
			dcount += Time.deltaTime;
			esc_count -= Time.deltaTime;
			count = Convert.ToInt32 (dcount);
			time_ui.text = string.Format("{0:N}\r\n",dcount).ToString();
			if(esc_count <= 0.00f){
				esc_count = 0.00f;
				finish_flag = true;
				PlayerPrefs.SetFloat("Time",dcount);
				PlayerPrefs.SetInt("Grade",item_manager.Grage);
				PlayerPrefs.SetInt("Stage",item_manager.StageLevel);
				Instantiate(Resources.Load("Prefabs/EyeCatch/EyeCatchObj"));
			}
			escape_ui.text = string.Format("{0:N}\r\n",esc_count).ToString();
		}
	}
}
