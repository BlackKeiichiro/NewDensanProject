using UnityEngine;
using System.Collections;


/*Bパ－トUIに使う数値をここでまとめる*/
public class to_UI : MonoBehaviour {

	//銃のグレード
	public int gread;
	//ボスの最大ＨＰ
	public int boss_hp_max;
	//ボスの現在のＨＰ
	public float boss_hp;
	//排熱最大量
	public int heat_max;
	//現在の排熱量
	public float heat;

	Boss boss_cs;
	shot_part8 shot_part;

	// Use this for initialization
	void Start () {
		//取得
		shot_part = GameObject.Find ("shot_rota").GetComponent<shot_part8>();
		gread = shot_part.gread;
		boss_hp_max = GameObject.Find ("boss_manager").GetComponent<Boss_manager>().boss_hp;
		boss_cs = GameObject.Find ("baby").GetComponent<Boss>();
		boss_hp = boss_cs.HP;
		heat_max = shot_part.heat_max;
		heat = shot_part.heat;

	
	}
	
	// Update is called once per frame
	void Update () {
		boss_hp = boss_cs.HP;
		gread = shot_part.gread;
		heat = shot_part.heat;
	
	}
}
