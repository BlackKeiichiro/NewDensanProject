using UnityEngine;
using System.Collections;


//デバック用のスクリプト
public class Test : MonoBehaviour {

	public GameObject shot;//銃のスクリプトが入っているオブジェクト
	public shot_part8 shot_part;//ショットを制御しているスクリプト（現在は8でテストごとに変える)

	public GameObject baby;

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		shot = GameObject.FindWithTag("Player");
		baby = GameObject.Find("bay");
		shot_part = shot.GetComponent<shot_part8>();

		audio = GameObject.Find("Sound_boss").GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	//グレード１
	if(Input.GetKeyDown(KeyCode.Alpha1)){
			shot_part.gread_count = 50;
		}
	//グレード２
	if(Input.GetKeyDown(KeyCode.Alpha2)){
			shot_part.gread_count = 100;
		}
	//グレード３
	if(Input.GetKeyDown(KeyCode.Alpha3)){
			shot_part.gread_count = 150;
		}
	if(Input.GetKeyDown(KeyCode.Alpha4)){
			shot_part.gread_count += 10;
		}
	//せっかくなので回転さあせてみた
	//baby.transform.Rotate(new Vector3(0,1f,0),5f);


	}
}
