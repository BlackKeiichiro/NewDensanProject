using UnityEngine;
using System.Collections;


/*ボスの攻撃パターンを管理する現在の面によって攻撃パターンを変更する*/
public class Boss_Atack_main : MonoBehaviour {

	//マネージャーコンポーネント
	Manager_partB mane;
    //ボスマネージャーコンポ
    Boss_manager boss_mane;

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
	boss_position boss_p;
    //ボスの動きを止める時間ウェイト
    public int boss_wait_add;

	//それぞれの攻撃スクリプト
	Boss_Atack lerzer; //レーザー
	public Boss_Missile_Main missile; //ミサイル


	// Use this for initialization
	void Start () {
		//コンポーネント
		mane = GameObject.Find ("Manager").GetComponent<Manager_partB>();
		boss_mane = GameObject.Find ("boss_manager").GetComponent<Boss_manager>();
        boss_p = GameObject.Find ("boss_position").GetComponent<boss_position>();
		lerzer = this.GetComponent<Boss_Atack>();
		missile = GameObject.Find ("Missile_Main").GetComponent<Boss_Missile_Main>();

		atack_point = GameObject.Find ("atack_point");
        boss_wait_add = 30;
	}

	void Atack(){

		//ミサイルを起動させる
		if(patarn == 0){
            missile.max_num = boss_mane.stage * 2;
            boss_wait_add = 30;
            missile.act = true;

		}
		//レーザーを起動させる
		else if(patarn == 1){
            //レーザーチャージ時間をレベルで決定
            int max;
            max = (4 - boss_mane.stage) * 180;
            lerzer.MAX_count = max;
            //ボスの停止時間
            boss_wait_add = max + 180;
			lerzer.act = true;

        }

		//パンチを起動させる
		else{

            boss_wait_add = 30;

        }

    }

	// Update is called once per frame
	void Update () {
        //int count = mane.time;

        //攻撃後、一定数でボスを動かしてカウントを止める
        if (count == wait + boss_wait_add)
        {
            boss_p.p_act = true;
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
		//一度だけ呼ぶため？（必要ないかも）
		if(act == true){
            //一定範囲のときにこうげき
			if(Mathf.Abs(atack_point.transform.position.x - this.transform.position.x) < 2){
				act = false;
				boss_p.p_act = false;
				Atack ();
			
			//	patarn = (patarn+1) %3;
			}
		}


	
	}
}
