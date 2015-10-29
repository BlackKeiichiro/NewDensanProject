﻿using UnityEngine;
using System.Collections;


/*ウエポンの耐久値を管理して０になったらそれぞれの対応をする*/
public class Wapon_HP : MonoBehaviour {

	public float max_hp = 8;//耐久値
	public float hp;//耐久値

	//現在のウエポンの種類unity側で設定する
	public bool missile;
	public bool laser;
	public bool panch;
	
	// Use this for initialization
	void Start () {
		hp = max_hp;
	}

	//耐久値が０になった時の各々の処理
	void Destroy_Juge(){

		//ミサイルの処理
		if(missile == true){
			Destroy(this.gameObject);
		
		}
		//レーザーの処理
		else if(laser == true ){
			GameObject efect = GameObject.Find ("charge");
			efect.GetComponent<ParticleSystem>().Stop();
			GameObject.Find ("baby").GetComponent<Boss_Atack>().act2 = false;
			hp = max_hp;
		}

		//ぱんちの処理
		else{


		}
	}

	// Update is called once per frame
	void Update () {

        //必要であればレーザが起動前にダメージを受けないように

		//耐久値がなくなれば破壊する
		if(hp <= 0){
			Destroy_Juge ();
		}	
	}
    //おんコルダーがありました
}
