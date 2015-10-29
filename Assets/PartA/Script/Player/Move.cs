using UnityEngine;
using System;
using System.Collections;

public class Move : MonoBehaviour {
	private float angle = -20;
	private Rigidbody bake_rigidbody;
	private float rds;
	private float fall_speed = 0.2f;
	private float h_speed = 5;
	//private float keep = 0;
	// Use this for initialization
	void Start () {
		rds = 410;
		bake_rigidbody = this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
		float w = angle*Mathf.PI/180/0.5f;
		float t = Time.time;
		float h = Input.GetAxis("Horizontal"); 
		Vector3 velocity = new Vector3(h,0,0);
		if(h > 0.1f){
			velocity *= Time.deltaTime;
		}else if(h < 0.1f){
			velocity *= -Time.deltaTime;
		}

		this.transform.localPosition += velocity * h_speed;

		Vector3 circle_vector = new Vector3(-Mathf.Sin(w*t),- fall_speed,Mathf.Cos(w*t));
		//this.transform.rotation = Quaternion.Euler(0,60-w*t*55,0);
		bake_rigidbody.velocity = -rds * w * circle_vector;
	}
}
