using UnityEngine;
using System;
using System.Collections;

public class Explosiion : MonoBehaviour {
	ItemManager item_manager;
	AudioClip damageSE;
	AudioClip bombSE;
	void Start(){
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
		damageSE = Resources.Load("Sound/bike_damage") as AudioClip;
		bombSE = Resources.Load("Sound/bomb") as AudioClip;
		AudioSource.PlayClipAtPoint(bombSE,this.transform.position,0.5f);
	}

	void OnTriggerEnter(Collider _collider){
		if(_collider.transform.tag == "Player"){
			AudioSource.PlayClipAtPoint(damageSE,this.transform.position,0.5f);
			item_manager.ExplosionOnTriggerCall();
		}
	}
}
