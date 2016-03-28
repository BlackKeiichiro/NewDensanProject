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
	private GameObject manager;
	private ItemManager item_manager;
	public int count;
	public bool switch_flag = true;

	void Awake(){
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
		escape_ui = GameObject.Find("Canvas/EscapePanel/EscapeTime").GetComponent<Text>();
		esc_count = esc_counts[item_manager.StageLevel];
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(!switch_flag){
			dcount += Time.deltaTime;
			esc_count -= Time.deltaTime;
			count = Convert.ToInt32 (dcount);
			if(esc_count <= 0.00f){
				esc_count = 0.00f;
				switch_flag = true;
				PlayerPrefs.SetInt("Grade",item_manager.Grage);
				PlayerPrefs.SetInt("Stage",item_manager.StageLevel);
				PlayerPrefs.SetInt("Scene",3);
				Application.LoadLevel(1);
			}
			escape_ui.text = string.Format("{0:N}\r\n",esc_count).ToString();
		}
	}
}
