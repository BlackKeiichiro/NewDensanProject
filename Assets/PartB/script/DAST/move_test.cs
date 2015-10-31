using UnityEngine;
using System.Collections;

public class move_test : MonoBehaviour {

	float count;
	public float r = 1;
	int max = 61;
	public float hankei = 1;

	//初期座標
	Vector3 initial;

	// Use this for initialization
	void Start () {
	 		initial = this.transform.position;			
	
	}
	
	// Update is called once per frame
	void Update () {
		count += r;
		count = count % max;
		//カウントが０になったらマイナスにして八の字移動させる
		if(count == 0){
			r *= -1f;
			//少しずれてしまうので初期位置へ
			this.transform.position = initial;			
		}
		//this.transform.position += new Vector3(hankei  * Mathf.Sin((float)count/10),0,hankei * Mathf.Cos((float)count/10));
		this.transform.position += new Vector3(hankei  * Mathf.Sin((float)count/10),hankei * Mathf.Cos((float)count/10),hankei * Mathf.Cos((float)count/10));
			
		
	}
}
