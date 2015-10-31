using UnityEngine;
using System.Collections;


/*ボスの攻撃パターンを管理する現在の面によって攻撃パターンを変更する*/
public class Boss_Atack_main : MonoBehaviour {

	//マネージャーコンポーネント
	Manager_partB mane;

	//現在のステージを入れる0~2
	public int stage;
	
	//次に行う攻撃のパターン
	public int patarn;

	//攻撃の間隔
	public int wait;
	//攻撃の間隔カウント
	public int count;
	//攻撃を開始させる場所のオブジェクト
	GameObject atack_point;
	bool act;//攻撃開始のフラグ

	public float test;

	//ボスの動きを止めるために
	Boss_Move boss_p;
    //ボスの動きを止める時間ウェイト
    public int boss_wait_add;

	//それぞれの攻撃スクリプト
	Boss_Atack lerzer; //レーザー
	public Boss_Missile_Main missile; //ミサイル
	Boss_Panch panch; //パンチ
	

	//ボスのアニメーション切り替え
	Animator anim ;


	// Use this for initialization
	void Start () {
		stage = PlayerPrefs.GetInt ("Stage");
		stage++;

		//コンポーネント
		mane = GameObject.Find ("Manager").GetComponent<Manager_partB>();
        boss_p = this.GetComponent<Boss_Move>();
		lerzer = this.GetComponent<Boss_Atack>();
		panch = this.GetComponent<Boss_Panch>();
		missile = GameObject.Find ("Missile_Main").GetComponent<Boss_Missile_Main>();

		atack_point = GameObject.Find ("atack_point");
        boss_wait_add = 30;

		anim = this.GetComponent<Animator>();
	}

	void Atack(){

		//ミサイルを起動させる
		if(patarn == 0){
            missile.max_num = stage * 2;
			Debug.Log (stage * 2);
            boss_wait_add = 30;
            missile.act = true;
			

		}
		//レーザーを起動させる
		else if(patarn == 1){
            //レーザーチャージ時間をレベルで決定
            int max;
            max = (4 - stage) * 180;
            lerzer.MAX_count = max;
			Debug.Log (max);
            //ボスの停止時間
            boss_wait_add = max + 200;
			lerzer.act = true;
			anim.SetTrigger ("chanon");
			

        }

		//パンチを起動させる
		else{

			panch.act = true;
			panch.hp = (stage-1) * 10 + 20;
			//panch.hp = 30;
			Debug.Log ((stage-1) * 10 + 20);
            boss_wait_add = 500;

        }

    }

	// Update is called once per frame
	void Update () {

		if(mane.act){

			

        //攻撃後、一定数でボスを動かしてカウントを止める
        if (count == wait + boss_wait_add)
        {
            boss_p.act = true;
            count = 0;
        }

        test = mane.frame_count % wait;
		
        //カウント加算
        if(act == false)
        {
            count++;
        }

        //一定間隔で攻撃を行う
        if (count == wait ){
			act = true;

		}

		//次の攻撃がミサイルの時に前もってアニメーションを起動する
		if(patarn == 0 && count == wait - 190){
			anim.SetTrigger ("missile");
			
		}

		//一度だけ呼ぶため？（必要ないかも）
		if(act == true){
            //一定範囲のときにこうげき
			//if(Mathf.Abs(atack_point.transform.position.x - this.transform.position.x) < 2){
				if(boss_p.Initial_Juge() == true){
				act = false;
				boss_p.act = false;
				Atack ();
				patarn = (patarn+1) %3;
			}
		}

		}


	
	}
}
