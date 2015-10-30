using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*part3のスクリプトに活動制限を加える
 銃の発射などのスクリプト*/
public class shot_part8 : MonoBehaviour {
	GameObject shot_roat;//回転軸
	GameObject shot_mouse;//銃口
	
	public GameObject gbalet;//弾のオブジェクト
	public Manager_partB manager;//マネージャスクリプト
	public int narrow_balet;//弾を撃つ間隔
	
//	public Quaternion gun_rotation;	//銃の角度
	
	public float mouse_sensitivity = 1f;//マウスの感度

	public int gread_count;//銃のグレードアップの貯める数値
	public int gread;//現在のグレードを示す数値

	public float heat;//銃の排熱ゲージ
	public int heat_max = 100;//排熱ゲージマックス値
	float heat_add;//排熱ゲージの加算値
	public bool heatheat = true;
	
	AudioSource audio;//オーディオ
	
	//再生する音
	public AudioClip shot;
	
	public Vector3 mouse_p;
	
	public GameObject mouse_p_px;//マウスの上限ｘ座標
	public GameObject mouse_p_nx;//マウスの上限-ｘ座標
	//public GameObject mouse_p_py;//マウスの上限y座標(使ってない)
	//public GameObject mouse_p_ny;//マウスの上限-y座標(使ってない)
	
	Gun_Control gun_con;
	
	//テスト用変数
	public float ftest;
	public int itest;
	public GameObject gtest;
	public Vector3 v3test;
	public Quaternion qtest;
	
	//方向指定用
	Vector3 diff ;
	
	
	
	
	// Use this for initialization
	void Start () {
		
		shot_roat = GameObject.Find ("shot_roat");//銃口のオブジェクト取得
		shot_mouse = GameObject.Find ("shot_mouse");//銃口のオブジェクト取得
		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
		gun_con = this.GetComponent<Gun_Control>();//銃コントロール（仮）
		audio = GetComponent<AudioSource>();

		//銃のか可動域のオブジェクトをセッティング
		mouse_p_px = GameObject.Find ("mouse_position_x");
		mouse_p_nx = GameObject.Find ("mouse_position_-x");
		
	}
	
	//マウスワールド座標が上限値を超えていたら修正させる
	//最後に向かせる座標を返す
	Vector3 Mouse_Judg(Vector3 judg){
		if(judg.x > mouse_p_px.transform.position.x){
			judg.x = mouse_p_px.transform.position.x;
		}
		else if(judg.x < mouse_p_nx.transform.position.x){
			judg.x = mouse_p_nx.transform.position.x;
		}
		
		judg.z = 30f;
		
		return judg;
		
	}

	//マウス座標をワールド座標に変える
	Vector3 Mouse(){
		
		mouse_p = Input.mousePosition;
		
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		//奥行をここで設定
		v3_mouse.z = 30f;
				
		//取得した座標をワールド座標へ変換
		v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);
		
		//座標修正
		v3_mouse = Mouse_Judg(v3_mouse);
		
		return v3_mouse;
		
	}
	
	//マウスとカーソルの差の絶対値を調べて、一定数の距離の時に１を返す
	int Mouse_abs(){
		mouse_p = Input.mousePosition;
		//Vector3 diff = mouse_p - casol.transform.position;
		float abs_x = Mathf.Abs(diff.x);
		float abs_y = Mathf.Abs(diff.y);
		
		if(abs_x > mouse_sensitivity ||  abs_y> mouse_sensitivity){
			return 1;
		}
		else{
			return 1;
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
		
	}

	//銃のグレードを変化させる
	void gread_up(){
		if(gread_count < 100){
			narrow_balet = 10;
			heat_add = 3f;
			gread = 1;
		}
		else if(gread_count < 150){
			narrow_balet = 7;
			heat_add = 2f;
			gread = 2;			
		}
		else{
			narrow_balet = 4;
			heat_add = 1f;
			gread = 3;
		}

	}

	//排熱処理
	void Heat(){
		//ボタンを押していないときにヒートゲージをへらしていく
		if(!Input.GetMouseButton(0)){
			if(heat > 0){
				heat -= 0.8f;
				if(heat < 1f){	heat = 0;	heatheat = true;}	
			}
		}

		//グレードが溜まったら打てなくするフラグを立てる
		if(heat > heat_max){
			heatheat = false;
		}
	}

	//弾発射
	void Balet(){
		
		//左クリックで通常発射（玉のインスタント化）
		if(Input.GetMouseButton(0) && manager.balet_count >= narrow_balet){

			//排熱ゲージの加算
			heat += heat_add;

			//効果音の再生
			audio.PlayOneShot(shot);
						
			//弾の召喚
			GameObject Balet = Instantiate(gbalet,shot_mouse.transform.position,shot_mouse.transform.rotation) as GameObject;
			manager.balet_count = 0;//間隔リセット
			
		}

	}
	// Update is called once per frame
	void Update () {

		//活動可能の時に活動させる
		if(manager.act){
			
			//gun_rotation = this.transform.rotation;
			
			//マウスの移動量が一定以上の時に実行
			if(Mouse_abs() == 1){
				Mouse_rote();
			}
			//グレードに関して
			gread_up();

			//排熱をクリアしているときにバレットを呼ぶ
			if(heatheat){
				Balet();
			}

			//排熱ゲージについて
			Heat ();
		}
	}
}
