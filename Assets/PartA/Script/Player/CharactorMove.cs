using UnityEngine;
using System.Collections;

public class CharactorMove : MonoBehaviour {
	private float angle;
	private float rds = 135;
	private Vector3 center;
	private Vector3 keep_position;
	private Vector3 _radian;
	private float now_fallen_y = 113f;
	private PartAManager _manager;


	void Awake(){
		_manager = GameObject.Find("Manager").GetComponent<PartAManager>();
	}
	
	// Use this for initialization
	void Start () {
		//inity += tower.transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		now_fallen_y -= _manager.fall_speed;
		center = new Vector3(0,now_fallen_y,0);
		angle += _manager.speed * Time.deltaTime % 360;
		_radian = Vector3.right * rds;
		keep_position  = Quaternion.AngleAxis(angle,Vector3.up) * _radian;
		this.transform.rotation = Quaternion.Euler(0,30+angle,0);
		this.transform.position = keep_position + center;
	}
}
