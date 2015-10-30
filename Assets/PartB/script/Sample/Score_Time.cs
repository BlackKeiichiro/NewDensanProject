using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//前回作ったスクリプトを参考用においてある
public class Score_Time : MonoBehaviour {

	public int score;//スコアポイント
	public float time;//タイムスコア
	public int enemy;//エネミーポイント

	public int max_time;

	public GameObject text;

	public Text score_text;
	public Text time_text;

//	Game_Main game_main;

	// Use this for initialization
	void Start () {

		//最初のスコア表示
		score_text.text = "SCORE:"+score;

//		game_main = GameObject.Find("game_main").GetComponent<Game_Main>();

	}
	
	//他スクリプトからのスコア加算
	void Score_Add(int add){
		score += add;
		score_text.text = "SCORE:"+score;
		
	}

	void Time_Add(float add){
		time -= add;
	}

	void Enemy_Add(){
		enemy++;
	}

	//残り時間を計算して表示
	void Time_Count(){

		//時間を加算して表示
		time += Time.deltaTime;
		int time_rem = (int)(max_time - time);//残り時間
		int time_min = time_rem / 60;//残り分
		int time_sec = time_rem - (time_min * 60);//残り秒
		//秒が、１０以下だったら0をつけたす
		if(time_sec < 10){time_text.text = "TIME:"+ time_min + ",0" + time_sec;}
		else{time_text.text = "TIME:"+ time_min + "," + time_sec;}
	
	}


	// Update is called once per frame
	void Update () {

	//	if(game_main.game){
			Time_Count();
	//	}

		if(time >= max_time){
			this.SendMessage("Game_Cria");
		}
	}
}

