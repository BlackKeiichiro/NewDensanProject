using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ボスのレーザー攻撃の仮スクリプト
public class Boss_Panch : MonoBehaviour {

	public bool act;//レーザーを起動させるためのフラグ
	public bool act2 = false;//レーザーの行動フラグ

	public GameObject plyer;//プレイヤー
	
	public float count;//

	public int max_hp = 30;
	public float hp;

	Manager_partB maneger;

	//アニメーション
	Animator anim;

	//進む方向
	Vector3 diff;
	//進む速度
	float go_speed;
	public float speed = -0.005f;

	//初期位置取得
	//Vector3 initial;
	//座標戻す
	Boss_Move boss_move;
	
	
	// Use this for initialization
	void Start () {

		//objectを設定
		plyer = GameObject.FindWithTag("Player");
		maneger = GameObject.Find ("Manager").GetComponent<Manager_partB>();
        boss_move = this.GetComponent<Boss_Move>();
		
		anim = this.GetComponent<Animator>();

		//hp = max_hp;

		//初期位置
		//initial = this.transform.position;
	
	}

	//攻撃を喰らったら呼ぶ
	public void reduct(){
		go_speed = speed * 0.3f;
		anim.speed = 0.3f;
	}

	//速度戻す
	void accel(){
		go_speed = speed;
		anim.speed = 1f;
		

	}
	
	// Update is called once per frame
	void Update () {

		if(maneger.act){




		if(act == true){

				
				anim.SetTrigger ("panch");
				act2 = true;
				act = false;
				count = 0;
				diff = this.transform.position - plyer.transform.position;
				
		}

			if(act2 == true){
				count += -1 * go_speed;
				//プレイヤー接近
				this.transform.position += diff * go_speed;
				if(count % 2 == 0){
					accel ();
				}

				if(count > 0.6){
				PlayerPrefs.DeleteKey ("Stage");
				PlayerPrefs.SetInt("Scene",0);	
				Application.LoadLevel(0);
			}

			}
			if(hp <= 0){
				act2 = false;
				anim.speed = 1f;
				count = 0;
				anim.SetTrigger("panch_damage");
					
			boss_move.Back ();
			hp = 10;
		
			/*
			if(boss_move.Back() == true){
				Debug.Log ("back");

				}
			else{
				hp = 10;
				}
				*/
			}
		
		}	
	}
}
