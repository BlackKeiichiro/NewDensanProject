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
			PlayerPrefs.SetInt("Scene",2);
			Application.LoadLevel(1);
			break;
		case "exit":
			Application.Quit();
			break;
		}
	}
}
