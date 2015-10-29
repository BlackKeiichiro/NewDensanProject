using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x - 5, player.transform.position.y+3, player.transform.position.z);
        this.transform.rotation = Quaternion.Euler(20,90,0);
    }
	
	void OnTriggerEnter(Collider _collider){
		if(_collider.gameObject.tag == "Unitychan"){
			Debug.Log("GameOver");
		}
	}
}
