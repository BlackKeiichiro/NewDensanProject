using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BottunClick(string Bname){
		switch(Bname){
		case "start":
			PlayerPrefs.SetInt("Stage",0);
			Application.LoadLevel("GameMain1");
			break;
		case "exit":
			Application.Quit();
			break;
		}
	}
}
