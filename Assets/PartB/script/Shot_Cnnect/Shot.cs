using UnityEngine;
using System.Collections;

//初代ショットスクリプト
public class Shot: MonoBehaviour {

	GameObject shot_mouse;//銃口
	public GameObject gbalet;//弾のオブジェクト
	public Manager_partB manager;//マネージャスクリプト
	public int narrow;//弾を撃つ間隔

	AudioSource audio;//オーディオ

	//再生する音
	public AudioClip shot;

	//マウスポジション
	public Vector3 mouse_p;

	//テスト用変数
	public float test;

	Vector3 diff ;


	// Use this for initialization
	void Start () {
	
		//オブジェクトの参照
		shot_mouse = GameObject.Find ("shot_mouse");//銃口のオブジェクト取得

		//必要なコンポーネントをゲットする
		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
		audio = GetComponent<AudioSource>();//オーディオ
		

	}
	
	//マウスのワールド座標を返す
	Vector3 Mouse(){

		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		//奥行をここで設定
		v3_mouse.z = 30f;
		
		//取得した座標をワールド座標へ変換
		v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);

		//マウスのワールド座標を返す
		return v3_mouse;

	}

	void Mouse_Point(){

		mouse_p = Input.mousePosition;

		//銃の縦方向を打ちやすい位置へ修正
		if(Input.mousePosition.y >= manager.screen_height * 0.3666f && this.transform.position.y < 2){
			this.transform.position += new Vector3(0,0.02f,0);
		}
		
		else if(Input.mousePosition.y <= manager.screen_height * 0.3666f && this.transform.position.y > 0.8f){
			this.transform.position -= new Vector3(0,0.02f,0);
		}
		
		//銃の横方向を打ちやすい位置へ修正
		if(Input.mousePosition.x <= manager.screen_width * 0.5f && this.transform.position.x < 0.5f){
			this.transform.position += new Vector3(0.02f,0,0);
		}
		
		else if(Input.mousePosition.x >= manager.screen_width * 0.5f && this.transform.position.x > -0.5f){
			this.transform.position -= new Vector3(0.02f,0,0);
		}

	}

	//銃口の角度をせってい
	void Mouse_rote(){

		//マウスの方向に向く
		diff = Mouse () - this.transform.position;
		this.transform.rotation = Quaternion.LookRotation(diff);
		

	}

	//弾発射
	void Balet(){
		
		//左クリックで通常発射（玉のインスタント化）
		if(Input.GetMouseButton(0) && manager.balet_count >= narrow){

			//効果音の再生
			audio.PlayOneShot(shot);
			

			//向きたい方向を計算
			Vector3 diff = Mouse() - shot_mouse.transform.position;
			GameObject Balet = Instantiate(gbalet,shot_mouse.transform.position,Quaternion.LookRotation(diff)) as GameObject;
			manager.balet_count = 0;//間隔リセット

			//レイを飛ばしてあった当たったオブジェクとを参照
			RaycastHit hit;
			if(Physics.Raycast(shot_mouse.transform.position,diff,out hit,100)){
				//ポイントにヒットしたらポイントのＨＰを減らして弾を壊す
				if(hit.transform.gameObject.tag == ("point")){
					Point point = hit.transform.gameObject.GetComponent<Point>();
					point.HP -= 1;
					Destroy(Balet,0.1f);
				}
			}


			
		}
		
	}

	// Update is called once per frame
	void Update () {
		//銃口の角度
		Mouse_rote ();
		//銃口の位置座標
		Mouse_Point();
		//バレットの発射
		Balet();

	}
}
