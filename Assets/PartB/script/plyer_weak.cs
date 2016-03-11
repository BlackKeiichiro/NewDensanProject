using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*プレイヤーゲームオーバー起動処理*/
/*敵の攻撃が当たったら起動*/
public class plyer_weak : MonoBehaviour {

	public Image panel;
	//Color pell = new Color(30,30,30,0);
	Color brack = new Color(0,0,0,0.5f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "enemy" || coll.gameObject.tag =="boss"){
			//暗転させる
			//panel.color = brack;
			PlayerPrefs.DeleteKey ("Stage");
			PlayerPrefs.SetInt("Scene",0);
			Application.LoadLevel(0);
			//Debug.Break ();
			//ゲームオーバー処理
		}
	}
}
