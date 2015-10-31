using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ボスのレーザー攻撃の仮スクリプト
public class Boss_Atack : MonoBehaviour {

	public bool act;//レーザーを起動させるためのフラグ
	public bool act2 = false;//レーザーの行動フラグ

	public GameObject plyer;//プレイヤー
	
	//public GameObject laser_mouse;//レーザー発射口
	//public GameObject laser_mouse_rot;//レーザーの発射口を回転させるためのobject
	//public GameObject laser;//発射するレーザー

	public int MAX_count;//カウントがいくつでレーザーを発射させるのか
	public int count;//

	public GameObject efect;
	ParticleSystem efect_particle;//チャージ
	public GameObject beam_efect;
	ParticleSystem beam_particle;//ビーム

	Manager_partB maneger;

	//アニメーション
	Animator anim;

	// Use this for initialization
	void Start () {

		//objectを設定
		plyer = GameObject.FindWithTag("Player");
	//	laser_mouse = GameObject.Find("Laser_mouse");
	//	laser_mouse_rot = GameObject.Find("Laser_mouse_rot");
		maneger = GameObject.Find ("Manager").GetComponent<Manager_partB>();
		efect_particle = efect.GetComponent<ParticleSystem>();
		beam_particle = beam_efect.GetComponent<ParticleSystem>();
		anim = this.GetComponent<Animator>();
		
	
	}
	
	// Update is called once per frame
	void Update () {

		if(maneger.act){

		//プレイヤーの方向を向かせるための変数
	//	Vector3 diff = laser_mouse_rot.transform.position - plyer.transform.position;

		//レーザー起動のタイミング
		if(act == true){
			act2 = true;
				act = false;
				count = 0;
				GameObject.Find ("Chanon").GetComponent<Wapon_HP>().act = true;
				
		}

		if(act2){
			
			//タグを更新
			//this.gameObject.tag = "point";
			//プレイヤーの方向へ向かせる
	//		laser_mouse_rot.transform.rotation = Quaternion.LookRotation(diff);
			count++;
		}

		if(count == 50){
				//パーティクルを起動
				efect_particle.Play();
		}

		//カウントが一定数へ行くと発射
		if(count == MAX_count){
				anim.SetTrigger ("chanon_shot");
				
				//パーティクルを起動
				beam_particle.Play();

				//発射したらエフェクトの削除
				Destroy(efect);
		}
		
		//一定数でフィニッシュ
		if(count == MAX_count + 120){
				Destroy(beam_efect);
				anim.SetTrigger ("chanon_finish");
				PlayerPrefs.DeleteKey ("Stage");
				Application.LoadLevel("Start");
				//ゲームオーバー処理
			}

		}
	}
}
