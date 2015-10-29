using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*part3のスクリプトに活動制限を加える*/

public class Shot_part5 : MonoBehaviour {
	GameObject shot_mouse;//銃口
	public GameObject gbalet;//弾のオブジェクト
	public Manager_partB manager;//マネージャスクリプト
	public int narrow_balet;//弾を撃つ間隔
	
	public Quaternion gun_rotation;	//銃の角度
	
	public float mouse_sensitivity = 1f;//マウスの感度
	
	AudioSource audio;//オーディオ
	
	//再生する音
	public AudioClip shot;
	
	public Vector3 mouse_p;

	public GameObject mouse_p_px;//マウスの上限ｘ座標
	public GameObject mouse_p_nx;//マウスの上限-ｘ座標
	public GameObject mouse_p_py;//マウスの上限y座標(使ってない)
	public GameObject mouse_p_ny;//マウスの上限-y座標(使ってない)

	Gun_Control gun_con;

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
		gun_con = this.GetComponent<Gun_Control>();//銃コントロール（仮）
		audio = GetComponent<AudioSource>();

		mouse_p_px = GameObject.Find ("mouse_position_x");
		mouse_p_nx = GameObject.Find ("mouse_position_-x");
		mouse_p_py = GameObject.Find ("mouse_position_y");
		mouse_p_ny = GameObject.Find ("mouse_position_-y");
		
	}

	//マウスワールド座標が上限値を超えていたら修正させる
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

	Vector3 Mouse(){
		
		mouse_p = Input.mousePosition;
		
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;
		//奥行をここで設定
		v3_mouse.z = 30f;
		
		casol.transform.position = v3_mouse;

		//取得した座標をワールド座標へ変換
		v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);

		//座標修正
		v3_mouse = Mouse_Judg(v3_mouse);
		
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
	
	//銃口の角度をせってい
	void Mouse_rote(){
		
		//マウスの場所と現在地点を引く
		diff = Mouse () - this.transform.position;
		
		//マウスの方向に向かせる
		this.transform.rotation = Quaternion.LookRotation(diff);
		
		
		//マウスのスクリーン座標取得
		Vector3 v3_mouse = Input.mousePosition;

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
			
		if(manager.act){

		gun_rotation = this.transform.rotation;
		
		//マウスの移動量が一定以上の時に実行
		if(Mouse_abs() == 1){
			Mouse_rote();
		}
		
		Balet();
		}
	}
}
