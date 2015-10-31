using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Targeting : MonoBehaviour {

	//リサイズを行う画像
	public Image p1;
	public Image p2;
	public Image p3;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//回転(カーソル用）

		p1.transform.Rotate(new Vector3(0, 0, 1f), 2f);
		p2.transform.Rotate(new Vector3(0, 0, 1f), -5f);
		p3.transform.Rotate(new Vector3(0, 0, 1f), -10f);
	
	}
}
