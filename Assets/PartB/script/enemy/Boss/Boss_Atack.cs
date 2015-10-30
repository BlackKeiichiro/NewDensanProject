using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ボスのレーザー攻撃の仮スクリプト
public class Boss_Atack : MonoBehaviour {

	public bool act;//レーザーを起動させるためのフラグ
	public bool act2 = false;//レーザーの行動フラグ

	public GameObject plyer;//プレイヤー
	
	public GameObject laser_mouse;//レーザー発射口
	public GameObject laser_mouse_rot;//レーザーの発射口を回転させるためのobject
	public GameObject laser;//発射するレーザー

	public int MAX_count;//カウントがいくつでレーザーを発射させるのか
	public int count;//

	public GameObject efect;
	ParticleSystem efect_particle;

	Manager_partB maneger;

	// Use this for initialization
	void Start () {

		//objectを設定
		plyer = GameObject.FindWithTag("Player");
		laser_mouse = GameObject.Find("Laser_mouse");
		laser_mouse_rot = GameObject.Find("Laser_mouse_rot");
		maneger = GameObject.Find ("Manager").GetComponent<Manager_partB>();
		efect_particle = efect.GetComponent<ParticleSystem>();
		
	
	}
	
	// Update is called once per frame
	void Update () {

		if(maneger.act){

		//プレイヤーの方向を向かせるための変数
		Vector3 diff = laser_mouse_rot.transform.position - plyer.transform.position;

		//レーザー起動のタイミング
		if(Input.GetKeyDown(KeyCode.Z) || act == true){
			act2 = true;
			//パーティクルを起動
			efect_particle.Play();
				act = false;
				count = 0;
				
		}

		if(act2){
			
			//タグを更新
			//this.gameObject.tag = "point";
			//プレイヤーの方向へ向かせる
			laser_mouse_rot.transform.rotation = Quaternion.LookRotation(diff);
			count++;
		}

		//カウントが一定数へ行くと発射
		if(count >= MAX_count){
				//発射したらエフェクトの削除
				Destroy(efect);
			GameObject laser_clone = Instantiate(laser,laser_mouse.transform.position,Quaternion.LookRotation(diff)) as GameObject;
			laser_clone.transform.gameObject.GetComponent<Rigidbody>().AddForce(laser_mouse.transform.right * -10,ForceMode.Impulse);
			//ゲームオーバ処理を加える
		}


		}
	}
}
