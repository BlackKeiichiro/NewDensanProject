using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//前回作ったスクリプトを参考用においてあります
public class Balet_Chary : MonoBehaviour {

	public int num;

	Balet_Shot balet_shot;

	public Image chary;//表示する絵

	public Sprite test;

	// Use this for initialization
	void Start () {

		//ゲットコンポ
		balet_shot = GameObject.Find ("plyer").GetComponent<Balet_Shot>();
	
	}

	void Balet_change(){

		if(balet_shot.balet_number >= num){
			chary.color = new Color(255,255,255,255);
			
		}
		else {

			chary.color = new Color(0,0,0,0);
			//chary.sprite = test;
		}
	}

	// Update is called once per frame
	void Update () {
	
		Balet_change();

	}
}
