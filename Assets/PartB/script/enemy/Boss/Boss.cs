using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//仮ボスのスクリプト
public class Boss : MonoBehaviour {

	//現在のステージを入れる0~2
	public int stage;

	//基準ＨＰ
	public int boss_hp_start;

	public int MAX_HP = 200;//最大ＨＰ
	public float HP = 200;//計算ＨＰ
	public int add_score = 1000;//加算スコア

	public Manager_partB manager;//マネージャスクリプト

	public float reet;//割合をいれる

	public AudioSource audio;//オーディオ
	
	//再生する音
	public AudioClip deth;

	// Use this for initialization
	void Start () {
		
		//ステージ取得
		stage = PlayerPrefs.GetInt("Stage");
		stage += 1;
		MAX_HP = stage * boss_hp_start;
		HP = MAX_HP;

		//コンポーネントをゲットする
		manager = GameObject.Find ("Manager").GetComponent<Manager_partB>();//ゲームマネージャー
		audio = GameObject.Find("shot_rota").GetComponent<AudioSource>();//オーディオ


	}
	
	// Update is called once per frame
	void Update () {

		//HPが０になった時の処理
		if(HP <= 0){
			//効果音の再生
			audio.volume = 1;
			audio.PlayOneShot(deth);
			//audio.volume = 0.1f;
			//壊してスコア加算
			Destroy(this.gameObject);

			//シーン切り替え
			if(stage < 3){
				manager.score += add_score;
				//	GameObject.Find ("boss_manager").SendMessage("stage_add");
				PlayerPrefs.SetInt("Stage",stage);
				//Application.LoadLevel("GameMain");
				Application.LoadLevel("GameMain1");

			}
			//ゲームクリアで移動とステージ番号を初期化
			else{
				PlayerPrefs.DeleteKey ("Stage");
				Application.LoadLevel("Start");
			}



		}

		//HPが減ったらバーを減らす
		//if(HP_retain != HP){
			//ＨＰ保持を更新
		//	HP_retain = HP;

			//現在のＨＰ割合
		//	reet =  HP * 100 / MAX_HP;	
		//	reet = reet / 100f;


			//サイズを変更したい倍率で変更
			//HP_ber.rectTransform.sizeDelta = new Vector2(WandH.x * reet, WandH.y * 1f);


			//変更したサイズと変更前のサイズの差の分だけ移動させる（/2する）
			//Vector2 diff = WandH - HP_ber.rectTransform.sizeDelta;
			//HP_ber.rectTransform.localPosition = new Vector3(posi.x - diff.x / 2f,posi.y,posi.z);
			//risize.position_x = posi.x - diff.x / 2;
		//}


	}
}
