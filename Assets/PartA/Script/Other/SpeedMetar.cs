using UnityEngine;
using System.Collections;

public class SpeedMetar : MonoBehaviour {
	// Use this for initialization
	void Start () {
		metar = GameObject.Find("Canvas/SpeedMetar/Memori/Metar");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){

			wait--;
			tick++;	
		}
		else if(tick > 10){
			tick--;
		}
		metar.transform.rotation = Quaternion.Euler(0,0,init_angle-tick);
	}
	
	private GameObject metar;
	private int wait = 0;
	private int tick = 0;
	private int init_angle = 20;
}
