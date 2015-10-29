using UnityEngine;
using System.Collections;

/*パート７以降は銃から直線で飛ばしている*/

//バレット自身のスクリプト
//マウスの方向へ飛んでいき、一定時間で消滅する
public class balet : MonoBehaviour {

	public float balet_power;//ボスに与える攻撃力
	public int point_power;//部位へ与えるダメージは何倍か？

	public float power = 100f;//飛ばす力
	public float des_time = 1f;//消す時間

	int gread;
	public Color gread1;
	public Color gread2;
	public Color gread3;

	//ベイビー声
	public AudioClip baby_vois;

	//ダメージのパーティクル
	public GameObject dameg_particl;

	// Use this for initialization
	void Start () {

		//現在のグレードを調べる
		gread = GameObject.FindWithTag("Player").GetComponent<shot_part8>().gread_count;

		if(gread < 100){
			//グレードに合わせて色を変える
			this.GetComponent<Renderer>().material.color = gread1;
		}
		else if(gread < 150){
			this.GetComponent<Renderer>().material.color = gread2;	
		}
		else{
			this.GetComponent<Renderer>().material.color = gread3;
		}
	
		/*Vector3 v3mouse = Input.mousePosition;//マウス座標
		
		//マウスの光線
		Ray rmouse;
		//マウス座標から光線の発射
		rmouse = Camera.main.ScreenPointToRay(v3mouse);
		
		//光線の向きをvector3に変換
		Vector3 diff  = rmouse.direction.normalized;
		*/
		//光線の向きに飛ばす
		this.GetComponent<Rigidbody>().AddForce(this.transform.forward * power,ForceMode.Impulse);
		//数秒後に破壊
		Destroy(gameObject,des_time);
	}	

	/*ここから
	void part7_before{
		
		Vector3 v3mouse = Input.mousePosition;//マウス座標
		
		//マウスの光線
		Ray rmouse;
		//マウス座標から光線の発射
		rmouse = Camera.main.ScreenPointToRay(v3mouse);
		
		//光線の向きをvector3に変換
		Vector3 diff  = rmouse.direction.normalized;
		
		//光線の向きに飛ばす
		this.GetComponent<Rigidbody>().AddForce(diff * power,ForceMode.Impulse);
		//数秒後に破壊
		Destroy(gameObject,des_time);
	}
	*/


	/*
	void part7_after {
		
		Vector3 v3mouse = Input.mousePosition;//マウス座標
		
		//マウスの光線
		Ray rmouse;
		//マウス座標から光線の発射
		rmouse = Camera.main.ScreenPointToRay(v3mouse);
		
		//光線の向きをvector3に変換
		Vector3 diff  = rmouse.direction.normalized;
		
		//光線の向きに飛ばす
		this.GetComponent<Rigidbody>().AddForce(diff * power,ForceMode.Impulse);
		//数秒後に破壊
		Destroy(gameObject,des_time);
	}
	ここまで予備*/




	// Update is called once per frame
	void Update () {
		//レイを飛ばしてあった当たったオブジェクとを参照
		RaycastHit hit;
		if(Physics.Raycast(this.transform.position,this.transform.forward,out hit,1)){
			if(hit.transform.gameObject.tag == ("point")){

                //パーティクルの出現
                GameObject pate = Instantiate(dameg_particl, this.transform.position, this.transform.rotation) as GameObject;

                Destroy(pate, 3f);

                Destroy(this.gameObject, 0.1f);
       
                Point point = hit.transform.gameObject.GetComponent<Point>();
				point.HP -= balet_power * point_power;

			}
			if(hit.transform.gameObject.tag == ("enemy")){

                //パーティクルの出現
                GameObject pate = Instantiate(dameg_particl, this.transform.position, this.transform.rotation) as GameObject;

                Destroy(pate, 3f);

                Destroy(this.gameObject, 0.1f);
    
                Wapon_HP weapon = hit.transform.gameObject.GetComponent<Wapon_HP>();
				weapon.hp -= balet_power * point_power;
			}

			//ボスへのダメージやその辺の処理
			if(hit.transform.gameObject.tag == ("boss")){

				//パーティクルの出現
				GameObject pate = Instantiate (dameg_particl,this.transform.position,this.transform.rotation) as GameObject;

				Destroy (pate,3f);

				Destroy(this.gameObject,0.1f);

				//ダメージ処理
				Boss boss = hit.transform.gameObject.GetComponent<Boss>();
				boss.HP -= balet_power;

				//音のウェイトを参照
				Manager_partB mane = GameObject.Find("Manager").GetComponent<Manager_partB>();
				int  vois_delay  = mane.baby_vois_count;
				//音がなってるよーのフラグ
				mane.baby_vois_act = true;
				//ウェイトがクリアなら音を鳴らす
				if(vois_delay == 0){
					AudioSource audio = GameObject.Find("Sound_boss").GetComponent<AudioSource>();
					audio.PlayOneShot(baby_vois);
				}
			}
		}
	}

}
