using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class PartAManager : MonoBehaviour {
    public int weapon_level = 0;
	public float speed = 40;
	public float root = 1f;
	public float fall_speed = 0.85f;
	public bool moveflag = false;
    public bool gauge_switch = false;
	public float _magnitude;
	public int[,,] patternlist;
	private int screenW = 1280;
	private int screenH = 720;
	// Use this for initialization
	void Awake () {
		Screen.SetResolution(screenW,screenH,false);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
