using UnityEngine;
using System.Collections;

//武器破壊のスクリプト
public class Weapon : MonoBehaviour {
	
	
	public float MAX_HP = 10;//ポイントの最大ＨＰ
	public float HP;//ポイントの現在ＨＰ
	public float red;//赤以外を減らしていく
		
	public Renderer r;//マテリアル用変数
	public Manager_partB manager;//ゲームマネージャー
	
	private AudioSource audio;//オーディオ
	
	//再生する音
	public AudioClip deth;
	
	// Use this for initialization
	void Start () {
		HP = MAX_HP;
		
		//ゲットコンポーネント
		r = GetComponent<Renderer>();//マテリアル用
		manager = GameObject.Find ("Manager").GetComponent<Manager_partB>();//ゲームマネージャー
		audio = GameObject.Find("shot_rota").GetComponent<AudioSource>();//オーディオ
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//ＨＰが０になった時の処理
		if(HP <= 0){			
			//破壊後ボスのＨＰを減らしてスコアを加算
			Destroy(this.gameObject);			
		}
		
		//ＨＰによって赤くする
		red =  HP * 100 / MAX_HP;	//現在のＨＰ割合
		red = red / 100f;
		r.material.color = new Color(1,red,red);
		
	}
}
