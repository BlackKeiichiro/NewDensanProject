using UnityEngine;
using System;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public float get_angle{get{return angle;}}

	private float angle = -30;//210;
	private float speed = 20;
	private float moveDistace;
	private float maxDistance = 475;
	private float minDistance = 350;
	private float playerX = 400;
	private Vector3 center;
	private Vector3 radian;
	private Vector3 rotate_position;
	private Animator bike_anim;
	private GameObject player;
	private GameObject bike;
	private ItemManager manager;

	// Use this for initialization
	void Start () {
		bike = this.transform.FindChild("Bike").gameObject;
		manager = GameObject.Find("Manager").GetComponent<ItemManager>();
		bike_anim = bike.GetComponent<Animator>();
        center = new Vector3(0,-3.8f,0);

	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float keep = playerX;

		//Bike's Animation
		bike_anim.SetFloat("horizontal",h);

		//Input Horizontal
        if (h > 0.1 || h < -0.1){
			//Nomal Move
			moveDistace = h * Time.deltaTime * 25;

			//Quick Escape
			if(Input.GetKeyDown(KeyCode.Space)){
				moveDistace += 200 * h * Time.deltaTime;
			}
		}
		playerX -= moveDistace;
		if(playerX > maxDistance || playerX < minDistance){
			playerX = keep;
		}
		angle += speed * Time.deltaTime % 360;
		radian = Vector3.right * playerX;
		rotate_position = Quaternion.AngleAxis(angle,Vector3.up) * radian;
		this.transform.rotation = Quaternion.Euler(0,Define.PLAYER_FIX_ROTATE + angle,0);
		this.transform.position = - rotate_position + center;	
	}

	void OnTriggerEnter(Collider c){
		if(c.transform.CompareTag("zone")){
			manager.shiftzone_flag = true;
		}
	}

}
