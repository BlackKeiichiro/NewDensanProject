using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Count : MonoBehaviour {
	private Text time_ui;
	private Text escape_ui;
	private float dcount = 0.0f;
	private float esc_count;
	private float[] esc_counts = new float[3]{60,80,100};
	private bool finish_flag = false;
	private GameObject manager;
	private ItemManager item_manager;
	public int count;

	void Awake(){
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
		escape_ui = GameObject.Find("Canvas/EscapePanel/EscapeTime").GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		esc_count = esc_counts[item_manager.StageLevel];
	}

	// Update is called once per frame
	void Update () {
		if(!finish_flag){
			dcount += Time.deltaTime;
			esc_count -= Time.deltaTime;
			count = Convert.ToInt32 (dcount);
			if(esc_count <= 0.00f){
				esc_count = 0.00f;
				finish_flag = true;
				PlayerPrefs.SetInt("Grade",item_manager.Grage);
				PlayerPrefs.SetInt("Stage",item_manager.StageLevel);
				PlayerPrefs.SetInt("Scene",3);
				Application.LoadLevel(1);
			}
			escape_ui.text = string.Format("{0:N}\r\n",esc_count).ToString();
		}
	}
}
