using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other){
		if(other.tag != "Player"){
			Debug.Log("hit2");
		}
	}

	void OnTriggerEnter(Collider c){
		if(c.transform.tag == "explosion")
			Debug.Log("hit1");
	}
}
