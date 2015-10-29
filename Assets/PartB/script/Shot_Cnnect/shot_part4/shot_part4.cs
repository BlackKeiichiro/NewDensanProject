using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shot_part4 : MonoBehaviour {
	GameObject shot_mouse;//銃口
	public GameObject gbalet;//弾のオブジェクト
	public Manager_partB manager;//マネージャスクリプト
	public int narrow_balet = 7;//弾を撃つ間隔
	
	public Quaternion gun_rotation;	//銃の角度
	
	public float mouse_sensitivity = 1f;//マウスの感度
	
	public float sensitivity = 0.1f;
	public float mouse_move_x_s;
	public float mouse_move_y_s;

	public float mouse_move_count_x;
	public float mouse_move_count_y;
	

	AudioSource audio;//オーディオ

	//再生する音
	public AudioClip shot;
	
	public Vector3 mouse_p;
	
	//テスト用変数
	public float ftest;
	public int itest;
	public GameObject gtest;
	public Vector3 v3test;
	public Quaternion qtest;
	
	//方向指定用
	Vector3 diff ;
	
	//カーソルを作成
	public Image casol;
	
	// Use this for initialization
	void Start () {
		
		shot_mouse = GameObject.Find ("shot_mouse");//銃口のオブジェクト取得
		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
		audio = GetComponent<AudioSource>();
	}
	
	Vector3 Mouse(){
		
		mouse_p = Input.mousePosition;
		
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		//奥行をここで設定
		v3_mouse.z = 30f;
		
		casol.transform.position = v3_mouse;
		
		//取得した座標をワールド座標へ変換
		v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);
		
		return v3_mouse;
		
	}

	//マウスとカーソルの差の絶対値を調べて、一定数の距離の時に１を返す
	int Mouse_abs(){
		mouse_p = Input.mousePosition;
		Vector3 diff = mouse_p - casol.transform.position;
		float abs_x = Mathf.Abs(diff.x);
		float abs_y = Mathf.Abs(diff.y);
		
		if(abs_x > mouse_sensitivity ||  abs_y> mouse_sensitivity){
			return 1;
		}
		else{
			return 0;
		}
		
		
	}

	int Mouse_move(){
		mouse_move_x_s = Input.GetAxis ("Mouse X") * sensitivity;
		mouse_move_y_s = Input.GetAxis ("Mouse Y") * sensitivity;

		if(mouse_move_x_s > 1f && mouse_move_count_x < 1){
			mouse_move_count_x += 1f;

		}
		else if(mouse_move_x_s < -1f && mouse_move_count_x > -1){
			mouse_move_count_x -= -1f;
		}

		if(mouse_move_y_s > 1f && mouse_move_count_y < 1){
			mouse_move_count_y += 1f;
			
		}
		else if(mouse_move_y_s < -1f && mouse_move_count_y > -1){
			mouse_move_count_y -= 1f;
		}

		if(mouse_move_count_x >= 1f || mouse_move_count_y >= 1f){
			return 1;
		}

		
		else if(mouse_move_count_x <= -1f || mouse_move_count_y <= -1f){
			return 1;
		}

		else {
			return 0;
		}
	}
	
	//銃口の角度をせってい
	void Mouse_rote(){
		
		//マウスの場所と現在地点を引く
		diff = Mouse () - this.transform.position;
		
		//マウスの方向に向かせる
		this.transform.rotation = Quaternion.LookRotation(diff);
		
		
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		
		//銃の角度調節
		gun_rotation = this.transform.rotation;
		qtest = this.transform.rotation;
		//上方向に行き過ぎていたら調整
		if(gun_rotation.x < -0.5 || gun_rotation.x > 0.6){
			float gun_diff = 300f - this.transform.eulerAngles.x;
			this.transform.Rotate(gun_diff,0,0);
		}
		//下方向に行き過ぎてきたら調整
		else if(gun_rotation.x > 0.5){
			float gun_diff = 50f - this.transform.eulerAngles.x;
			this.transform.Rotate(gun_diff,0,0);
		}
		//右方向に行き過ぎてきたら調整
		if(gun_rotation.y > 0.5){
			float gun_diff = 60f - this.transform.eulerAngles.y;
			this.transform.Rotate(0,gun_diff,0);
		}
		//左方向に行き過ぎてきたら調整
		if(gun_rotation.y < -0.5){
			float gun_diff = 300f - this.transform.eulerAngles.y;
			this.transform.Rotate(0,gun_diff,0);
		}
		
	}
	
	//弾発射
	void Balet(){
		
		//左クリックで通常発射（玉のインスタント化）
		if(Input.GetMouseButton(0) && manager.balet_count >= narrow_balet){
			
			//効果音の再生
			audio.PlayOneShot(shot);
			
			
			//向きたい方向を計算
			Vector3 diff = Mouse() - shot_mouse.transform.position;
			GameObject Balet = Instantiate(gbalet,shot_mouse.transform.position,Quaternion.LookRotation(diff)) as GameObject;
			manager.balet_count = 0;//間隔リセット
			
			//レイを飛ばしてあった当たったオブジェクとを参照
			RaycastHit hit;
			if(Physics.Raycast(shot_mouse.transform.position,diff,out hit,100)){
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
		
		
		gun_rotation = this.transform.rotation;

		if(Mouse_move() == 1){
			Mouse_rote();
		}
		
		Balet();
		
	}
}
