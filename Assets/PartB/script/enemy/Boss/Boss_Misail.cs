using UnityEngine;
using System.Collections;

public class Boss_Misail : MonoBehaviour {

	int misail_hp_count;//ミサイルの減らしていくｈｐ

	public bool act = false;//ミサイル発射の合図フラグ

	public int dire = 1;//ミサイルが最初に飛んでいく方向初期値は画面右へ飛ぶ左に飛ばすときは-1を代入(変わらないかも)
	
	public GameObject camera;//向かっていくカメラのオブジェクト
	public bool look_flag = false;//ロックオンした時にあげる

	public Vector3 diff;//カメラとの差
	public float dis = 1.8f;//プレイヤーとの距離のどのあたりでロックさせるかの数値（小さいほど早くロックする）

	public Collider child_missil_collider;//コルダー

	Rigidbody rigi;//リジッドボディ

	Manager_partB manager;

	// Use this for initialization
	void Start () {
		rigi = this.GetComponent<Rigidbody>();
		camera = GameObject.FindWithTag ("Player");
		child_missil_collider = transform.FindChild("missile").gameObject.GetComponent<Collider>();
	
		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//misail起動のタイミング
		if(Input.GetKeyDown(KeyCode.X)){
			act = true;
			
		}
		
		//起動したらカメラに向かって飛んでいく
		if(act){
			//カメラからの差
			Vector3 act_diff = camera.transform.position - this.transform.position;
			//所定の位置まで移動した後に一度だけ呼び出す
			if(Mathf.Abs(act_diff.z) < diff.z/dis && look_flag == false){
				//徐々にカメラの方向へ移動していく
				//this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(act_diff),0.1f);


				//プレイヤーの方向を向く
				this.transform.rotation = Quaternion.LookRotation(act_diff);


				//一度動きを止める
				rigi.velocity = Vector3.zero;
				look_flag = true;
				//child_missil_collider.isTrigger = false;
				

			}

			if(manager.act){

			//力を加えて飛ばす
			rigi.AddForce(this.transform.forward * 0.05f,ForceMode.Impulse);
			
			}
			else
				//一度動きを止める
				rigi.velocity = Vector3.zero;

		}

	}

}
