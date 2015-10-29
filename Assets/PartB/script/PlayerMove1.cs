using UnityEngine;
using System;
using System.Collections;

public class PlayerMove1 : MonoBehaviour {
	private float angle = -30;//210;
	private float speed = 20;//スピード
	private float moveDistace;
	private float playerX = 400;
	private Vector3 center;
	private Vector3 radian;
	private Vector3 rotate_position;
	private Animator bike_anim;
	private GameObject player;
	private GameObject bike;
	// Use this for initialization
	void Start () {
        center = new Vector3(0,-3.5f,0);//
	}
	
	// Update is called once per frame
	void Update () {
		playerX -= moveDistace;
		angle += speed * Time.deltaTime % 360;
		radian = Vector3.right * playerX;
		rotate_position = Quaternion.AngleAxis(angle,Vector3.up) * radian;
		this.transform.rotation = Quaternion.Euler(0,Define.PLAYER_FIX_ROTATE + angle,0);
		this.transform.position = - rotate_position + center;
	}


}
