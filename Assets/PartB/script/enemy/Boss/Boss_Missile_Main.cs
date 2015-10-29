using UnityEngine;
using System.Collections;

public class Boss_Missile_Main : MonoBehaviour {

	//インスタントするミサイルのオブジケクト
	public GameObject missile_original;

	public GameObject[] misail;//発射するミサイルの配列
	public GameObject[] misail_position = new GameObject[6];//発射するミサイルの配列
	public int first_num = 1; //格納するミサイルの一番若い番号
	public int max_num;		  //格納するミサイルの一番アダルトな番号
	int count_num = 0; //格納するたびにカウントしていく

	public GameObject player;//プレイヤー（カメラ）のオブジェクト
	
	Manager_partB maneger;

	//ミサイル起動のフラグ
	public bool act;

	// Use this for initialization
	void Start () {

		//プレイヤーを取得
		player = GameObject.FindWithTag ("Player");		

		maneger = GameObject.Find ("Manager").GetComponent<Manager_partB>();
		

		//count_numが最大番号になるまでくりかえす
	/*	while(count_num != max_num){
			//ミサイルを上から順に格納していく
			misail[count_num] = GameObject.Find("Missile" + (first_num + count_num));
			count_num++;
		}*/

		for(int i=1;i<=6;i++){
			//ミサイルポジションを上から順に格納していく
			misail_position[i-1] = GameObject.Find("Missile_position" + (i));
		}
	}

	//ミサイルをインスタントして格納する
	void Missile_Put(){

		while(count_num != max_num){
			Vector3 posi = misail_position[count_num].transform.position;
			Quaternion root = misail_position[count_num].transform.rotation;
			//ミサイルを上から順にインスタントする
			GameObject ins_missile = Instantiate (missile_original) as GameObject;
			ins_missile.transform.position = posi;
			misail[count_num] = ins_missile;
			count_num++;
		}
	}

	// Update is called once per frame
	void Update () {
		if(maneger.act){

		//レーザー起動のタイミング
		if(Input.GetKeyDown(KeyCode.C) || act == true){

			//ミサイルを格納
			Missile_Put ();
			
			count_num=0;
			//count_numが最大番号になるまでくりかえす
			while(count_num != max_num){
			
				//ゲットコンポーネント
				Boss_Misail boss_misail_script = misail[count_num].GetComponent<Boss_Misail>();

				//ミサイルの初期角度の設定
				//int misail_dire = boss_misail_script.dire;
				//角度を－１と１で繰り返す（現在では場所と角度が逆になっているが、意外とよさげなのでプレイ後に考える）
				int misail_dire = count_num % 2;
				if(misail_dire == 0) misail_dire = -1;

				misail[count_num].transform.Rotate(0,45f * misail_dire,0);

				boss_misail_script.diff = misail[count_num].transform.position - player.transform.position;
				boss_misail_script.diff.z = Mathf.Abs(boss_misail_script.diff.z);

				//ミサイルを活動させる
				boss_misail_script.act = true;
				
				count_num++;
			}
				//本体からミサイルを切り離す
				//しばらくは切り離さないようにしておいてね♡
				this.gameObject.transform.DetachChildren();
				act = false;

		}
	}
	}
}
