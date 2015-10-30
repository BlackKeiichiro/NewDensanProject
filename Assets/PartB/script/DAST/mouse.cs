using UnityEngine;
using System.Collections;

//マウスの動作テスト用スクリプト
public class mouse : MonoBehaviour {

	public Vector3 mouse_xyz;
	public int screen_right;
	public int screen_left;
	
	public GameObject gun;
	public GameObject casol;

	public Transform trans;

	public Vector3 v3r_mouse;

	// Use this for initialization
	void Start () {
		trans = gun.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
	
		mouse_xyz = Input.mousePosition;
		screen_left = Screen.width / 4;
		screen_right = Screen.width - screen_left;

		/*
		if(Input.GetMouseButtonDown(0)){

			Ray rmouse;

			rmouse = Camera.main.ScreenPointToRay(Input.mousePosition);

			Vector3 v3r_mouse  = rmouse.direction.normalized;


			//向きたい方向を計算
		Vector3 diff = v3r_mouse - gun.transform.position;

			//銃の方向を計算した値に向ける
			trans.rotation = Quaternion.LookRotation(diff);

			//ここからたいへんでした
			//ｘ軸を90でこていしたい。
			//まず、変更したｘのオイラー角度を取得
			float gun_euler_x = trans.eulerAngles.x;

			//角度が90より大きければもとの角度から90を引いた数を引く
			if(gun_euler_x > 90){
				trans.Rotate (-(gun_euler_x - 90f),0,0);
			}
			//角度が90より小さければ元の角度から90を引いた数を足す
			else {
				trans.Rotate (gun_euler_x- 90f,0,0);
			}

		float gun_euler_y = trans.eulerAngles.y;
		trans.Rotate(0,-gun_euler_y,0);

		
		}*/

		//if(Input.GetMouseButtonDown(0)){

			//マウスのスクリーン座標取得
			Vector3 v3_mouse = Input.mousePosition;
			//奥行をここで設定
			v3_mouse.z = 50f;

			//取得した座標をワールド座標へ変換
			v3_mouse = Camera.main.ScreenToWorldPoint(v3_mouse);
		casol.transform.position = v3_mouse;

			//向きたい方向を計算
			Vector3 diff = v3_mouse - gun.transform.position;
			
			//銃の方向を計算した値に向ける
			trans.rotation = Quaternion.LookRotation(diff);

			//ここからたいへんでした
			//ｘ軸を90でこていしたい。
			//まず、変更したｘのオイラー角度を取得
			float gun_euler_x = trans.eulerAngles.x;
			
			//角度が90より大きければもとの角度から90を引いた数を引く
			if(gun_euler_x > 90){
				trans.Rotate (-(gun_euler_x - 90f),0,0);
			}
			//角度が90より小さければ元の角度から90を引いた数を足す
			else {
				trans.Rotate (gun_euler_x- 90f,0,0);
			}
		//}



		//casol.transform.position = new Vector3(casol.transform.position.z * 1.1f,casol.transform.position.y, casol.transform.position.z *1.1f);  
	}
}
