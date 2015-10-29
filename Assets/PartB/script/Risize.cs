using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ゲーム画面によって画像をリサイズさせるスクリプト
//画像が動的に変わる場合は初期サイズ、初期座標を動的に代入する
//文字はリサイズのついた画像の子にしてあげる
public class Risize : MonoBehaviour {

	//リサイズを行う画像
	public Image img;

	//画像の初期サイズとポジション
	public float scale;	
	public float position_x;
	public float position_y;
	
	//ゲームの画面サイズ
	public float screen_width = Screen.width;//画面サイズ取得
	public float screen_height = Screen.height;//画面サイズ取得




	// Use this for initialization
	void Start () {
		//int screen_width = Screen.width;//画面サイズ取得
		//int screen_height = Screen.height;//画面サイズ取得
	
		//img.rectTransform.localScale = new Vector3((screen_width / 800) * scale_w,(screen_height / 600) * scale_h,0);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		//現在シーン上で400*300の画面を見ながら位置を修正している
		screen_width = Screen.width / 400f;//画面サイズどれくらい基準からおおきくなったか
		screen_height = Screen.height / 300f;//画面サイズどれくらい基準からおおきくなったか

		//基準画面からの倍率によってサイズ、位置を修正
		img.rectTransform.localScale = new Vector3(screen_width * scale,screen_height * scale,0);

		img.rectTransform.localPosition =new Vector3(position_x * screen_width,position_y * screen_height,0);

        //回転(カーソル用）
        img.transform.Rotate(new Vector3(0, 0, 1f), 10f);
	}
}
