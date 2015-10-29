using UnityEngine;
using System.Collections;

public class Wall : Item {
// Use this for initialization
	protected override void Start () {
		PositionLock(this.transform.localScale.y/2);
	}
	
	// Update is called once per frame
	protected override void Update () {
	
	}
	
	protected override void OnTriggerEnter(Collider _collider){
		if(_collider.transform.tag == "Player"){
			Debug.Log("HIT");
		}
	}
}
