using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//前回作ったスクリプトを参考用に置いてあります
public class Balet_Shot : MonoBehaviour {

	bool act = false;//行動可能フラグ	

	public Transform trans;//銃のトランスフォームを格納

	public GameObject gun;//銃のオブジェクト
	public GameObject balet;//弾のオブジェクト
	GameObject shot_mouse;//発射口

	public GameObject casol;

	int se_count;//seを被らせない
	public int balet_number;//残断数
	public int balet_max;//最大弾数
	AudioSource se;//オーディオ

	//再生する音
	public AudioClip shot;
	public AudioClip riload;
	public AudioClip ere;


	// Use this for initialization
	void Start () {
		//オブジェクトの検索
		shot_mouse = GameObject.Find ("shot_mouse");
		//gun = GameObject.Find ("gun");

		//ゲットコンポ
		trans = gun.GetComponent<Transform>();
		se = GameObject.Find("plyer_oudio").GetComponent<AudioSource>();

		//弾の補充
		balet_number = balet_max;

	}

	//弾発射
	void Balet(){

		//左クリックで通常発射（玉のインスタント化）
		if(Input.GetMouseButtonDown(0)){
			
			Instantiate(balet,shot_mouse.transform.position,gun.transform.rotation);
			balet_number--;
			Shot_Sound(shot);
			
		}

	}

	void Gun_Rotation(){
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		//奥行をここで設定
		v3_mouse.z = 20f;
		
		//取得した座標をワールド座標へ変換
		v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);

		//カーソルの表示
		casol.transform.position = v3_mouse;

		//向きたい方向を計算
		Vector3 diff = casol.transform.position - gun.transform.position;
		
		//銃の方向を計算した値に向ける
		trans.rotation = Quaternion.LookRotation(diff);
		

		//ここからたいへんでした
		//ｘ軸を90でこていしたい。
		//まず、変更したｘのオイラー角度を取得
		float gun_euler_x = trans.eulerAngles.x;
		
		//角度が90より大きければもとの角度から90を引いた数を引く
		if(gun_euler_x > 0){
			trans.Rotate (-(gun_euler_x),180,0);
		}
		//角度が90より小さければ元の角度から90を引いた数を足す
		else {
			trans.Rotate (gun_euler_x,180,0);
		}
	}

	void Shot_Sound(AudioClip play){

		//seの再生
		if(se_count == 0){
			//se_count = 15;
			se.PlayOneShot(play);
		}

	}

	void Shot_Act(bool sub){
		act = sub;
	}

	//リロード処理
	void Riload(){

		if(Input.GetKeyDown(KeyCode.R)){
			Shot_Sound(riload);
			balet_number = balet_max;
		}

	}

	// Update is called once per frame
	void Update () {
	
		if(act){

			Gun_Rotation();

			if(balet_number > 0){
	
				Balet();
			}
			//弾がない時は空発をうつ
			else {
				if(Input.GetMouseButtonDown(0)){
				
					Shot_Sound(ere);
			
				}
			}

			//seがなったらカウントを減らしていく
			if(se_count > 0){
				se_count--;
			}

			Riload();
		}
		else casol.transform.position = new Vector3(0,0,0);
	}
}
