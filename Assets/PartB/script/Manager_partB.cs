using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ゲームマネージャースクリプト
public class Manager_partB : MonoBehaviour {

	public float time;//ゲーム開始時からカウントする時間（コンマ秒）
	public int time_second;//ゲーム開始時からカウントする(秒）
	public int frame_count;//ゲーム開始時からカウントするフレームカウント

	public Text score_text;//スコアポイントのテキスト
	public int score;//加算するスコアポイント
	private int score_retain;//スコア保持

	public int balet_count;//弾を打つ間隔

	public float screen_width = Screen.width;//画面サイズ取得
	public float screen_height = Screen.height;//画面サイズ取得

	public bool act;//主人公、その他の行動を可能にさせる

	public bool baby_vois_act;//ボスの声のフラグ
	public int baby_vois_count;//ボスの声のカウント
	public int baby_vois_time;//ボスの声の発生間隔の設定

	Pouse_mane pouse;//ポーズのスクリプト

	GameObject tower;

	// Use this for initialization
	void Start () {

		//初期スコアの表示
		//score_text.text = "SCORE:"+score_retain;
		pouse = this.GetComponent<Pouse_mane>();
		tower = GameObject.Find ("Tower");
	}

	// Update is called once per frame
	void Update () {

		act = pouse.act;

		//screen_width = Screen.width; //画面横サイズ
		//screen_height = Screen.height ;//画面縦サイズ

		//時間のカウント
		time += Time.deltaTime;
		time_second = (int)time;
		//バレット間隔のカウント
		balet_count ++;

		//フレームの加算
		frame_count++;

		//ボスがダメージを受けるとカウントはじめる
		if(baby_vois_act == true){
			baby_vois_count = (baby_vois_count + 1) % baby_vois_time;
			//カウントがマックスになったらfalseに
			if(baby_vois_count == (baby_vois_time - 1)){
				baby_vois_act = false;
			}
		}
		//スコアが変わったら変更
		if(score_retain != score){
			score_retain += 5;
			//score_text.text = "SCORE:"+score_retain;
		}

		tower.transform.Rotate(new Vector3(0,1f,0),-1f);
		

	}
}
