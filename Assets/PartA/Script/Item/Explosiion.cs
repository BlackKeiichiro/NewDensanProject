using UnityEngine;
using System;
using System.Collections;

public class Explosiion : MonoBehaviour {
	ItemManager item_manager;

	void Start(){
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
	}

	void OnTriggerEnter(Collider _collider){
		if(_collider.transform.tag == "Player"){
			Debug.Log("Damage");
			item_manager.ExplosionOnTriggerCall();
		}
	}
}
