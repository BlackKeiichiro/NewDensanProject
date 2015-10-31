using UnityEngine;
using System.Collections;

/*ボスの移動を行う*/
public class boss_position : MonoBehaviour {

	public float p_x;//ボスポジションｘ
	public float p_y;//ポジションｙ
	float count_tate;//カウント変数
	float count_yoko;//カウント変数
    public float r;

    //横移動のオブジェクト
    GameObject position_yoko;
 
    public float p_x_yoko;
	public float yoko_speed;//多分よこのスピード

    public float tate_speed;//たてのスピード

    //奥移動のオブジェクト
    GameObject position_oku;
    public float p_x_oku;
    public float oku_speed;//奥スピード


    //ポジションアクト
    public bool p_act = true;

	//ポーズ用
	Manager_partB manager;
	// Use this for initialization
	void Start () {
	
		position_yoko = GameObject.Find ("boss_position_yoko");
        position_oku = GameObject.Find ("boss_position_oku");

		manager = GameObject.Find("Manager").GetComponent<Manager_partB>();//ゲーム管理するスクリプトを取得
		
	}
	
	// Update is called once per frame
	void Update () {
		//x,yを円で回す
		//ポーズしたら止まる
		if(p_act == true && manager.act == true){
			p_x = r * tate_speed * Mathf.Cos(count_tate);
			p_y = r * tate_speed * Mathf.Sin(count_tate);

			p_x_yoko = 1/yoko_speed* Mathf.Sin(count_yoko/yoko_speed);

            p_x_oku = 0.5f/ oku_speed * Mathf.Sin(count_tate/oku_speed);



            //p_x = 2f * Mathf.Sin (count + 2); 


            this.transform.position += new Vector3(p_x,p_y,0);
			position_yoko.transform.position += new Vector3(p_x_yoko,0,0);
			position_oku.transform.position += new Vector3(0,0,p_x_oku);

            count_tate += 0.1f * tate_speed;
            count_yoko += 0.1f;

			
		}
	}
}
