using UnityEngine;
using System.Collections;

public class CameraSet : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("bike");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.transform.position + Vector3.up * 3 - Vector3.back * 8;
		this.transform.rotation = player.transform.rotation;
	}
}
