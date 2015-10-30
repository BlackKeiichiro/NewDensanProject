using UnityEngine;
using System.Collections;

/*銃の角度コントロールを行うスクリプト*/

public class Gun_Control : MonoBehaviour {

	public Vector3 mouse_p;

	public float screen_width = Screen.width;//画面サイズ取得
	public float screen_height = Screen.height;//画面サイズ取得

	public float anact_width;//活動制限横
	public float anact_height;//活動制限縦

	public bool act = false;
	
	// Use this for initialization
	void Start () {
		anact_width = screen_width /10;
		anact_height = screen_height / 10;
	}

	void Screen_Size(){
		screen_width = Screen.width;//画面サイズ取得
		screen_height = Screen.height;//画面サイズ取得
		anact_width = screen_width /5;
		anact_height = screen_height / 5;
	}

	// Update is called once per frame
	void Update () {
		Screen_Size();
		mouse_p = Input.mousePosition;
		if(mouse_p.y > screen_height - anact_height || mouse_p.y < anact_height){
			act = false;
		}
		else if(mouse_p.x > screen_width - anact_width || mouse_p.x < anact_width){
			act = false;
		}
		else{ 
			act = true;
		}
	}
}
