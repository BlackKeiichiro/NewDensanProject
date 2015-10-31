using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*右クリックでポーズさせる*/
public class Pouse_mane : MonoBehaviour {

	public bool act = true;
	public Image panel;
	Color pell = new Color(30,30,30,0);
	Color brack = new Color(0,0,0,0.5f);
	

	// Use this for initialization
	void Start () {
		//マウス制御(ビルド時に動作)
		//カーソルをけして飛び出さないように
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}


	//ポーズ処理
	void Pouse(){
		//ポーズにさせる
		if(act == true && Input.GetMouseButtonDown(1)){
		//	Debug.Break();
			//マウス制御(ビルド時に動作)
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			panel.color = brack;
			act = false;
		}
		//ポーズを解除させる
		else if(act == false && Input.GetMouseButtonDown(1)){
			//マウス制御(ビルド時に動作)
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = false;
			panel.color = pell;			
			act = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Pouse();
	}
}
