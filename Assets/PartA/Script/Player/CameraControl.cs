using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	private GameObject player;
	private float camera_y = 5;
	private float camera_z = 3;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 player_position = player.transform.position;
		player_position += new Vector3(0,camera_y,camera_z);
		this.transform.position = player_position;
	}
}
