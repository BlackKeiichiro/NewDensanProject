using UnityEngine;
using System.Collections;


//ボスのパーツの破壊情報の保持
//現在のＢＯＳＳＨＰも計算
public class Boss_manager : MonoBehaviour {

	public static bool creat;//複製禁止フラグ

	public int[] part = new int[10];//ボスのパーツが破壊されていれば１を入れる配列

	public  int stage;//現在のステージ（１～３）切り替わるときに次ステージの番号を入れてもらう
	public int boss_hp_start;//ボス一面のＨＰ
	public int boss_hp;//ボスのマックスＨＰ
	
	// Use this for initialization
	void Start () {



		//シーン読み込みで複製されないように
		if(!creat){
			//シーンを変えても残しておく
			DontDestroyOnLoad (this);		
			creat = true;

		}
		else{
			//破壊する
			Destroy(this.gameObject);		
		}


	}

	//このパートが終わる時に読んでもらう
	void stage_add(){
		//ステージの加算
		stage ++;
		//ボスの最高ＨＰを計算
		boss_hp = stage * boss_hp_start;
	
	}

	// Update is called once per frame
	void Update () {
	}
}
