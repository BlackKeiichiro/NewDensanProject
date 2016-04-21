using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {
	private int stage;
	private ItemManager item_mng;
	private Animator anim;
	// Use this for initialization
	void Awake() {
		stage = PlayerPrefs.GetInt("Stage");
		anim = this.GetComponent<Animator>();
		anim.SetInteger("Stage",stage);
		Debug.Log(stage);
		item_mng = GameObject.Find("Manager").GetComponent<ItemManager>();
	}

	// Update is called once per frame
	void Update () {
	
	}
	public void TutorialEnd(){
		item_mng.TutorialEnd();
	}
}
