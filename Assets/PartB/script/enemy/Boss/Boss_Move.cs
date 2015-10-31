using UnityEngine;
using System.Collections;

public class Boss_Move : MonoBehaviour {

	//行動管理
	public bool act;

	float count;
	public float r = 0.5f;
	int max = 61;
	public float hankei = 0.5f;

	//初期座標
	public Vector3 initial;

	//ポーズ用
	Manager_partB manager;
	//プレイヤー
	GameObject plyer;
	// Use this for initialization
	void Start () {

		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
		plyer = GameObject.FindWithTag("Player");

	 	initial = this.transform.position;		
		act =true;
	
	}

	public bool Initial_Juge(){
		Vector3 diff = initial - this.transform.position;
		diff.x = Mathf.Abs(diff.x);
		diff.y = Mathf.Abs(diff.y);
		diff.z = Mathf.Abs(diff.z);
		if(diff.x < 1f && diff.y < 1f && diff.z < 1f  ){
			return true;
		}
		else 
			return false;
	}

	public bool Back(){

		this.transform.position = initial;
		return true;
		
		/*
		Vector3 diff = initial - this.transform.position;
		
		if(Initial_Juge() == true){
				Debug.Log ("backback");
			
			this.transform.position = initial;
			return true;
						
		}
		else{
			this.transform.position -= diff * 1f;
			return false;
		}		
		*/

	}

	// Update is called once per frame
	void Update () {

		if(act == true && manager.act == true){

			//プレイヤーへ向く
			Vector3 diff = plyer.transform.position - this.transform.position;
			this.transform.rotation = Quaternion.LookRotation (diff);

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
}
