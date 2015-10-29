using UnityEngine;
using System.Collections;

public class GetAngleSet : MonoBehaviour {
	RaycastHit rayhit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Physics.Raycast(this.transform.position,Vector3.down,out rayhit,0.5f)){
			Vector3 localvector = Vector3.forward;
			localvector.x += rayhit.normal.x;
			this.transform.localRotation = Quaternion.Euler(localvector);
		}
	}
}
