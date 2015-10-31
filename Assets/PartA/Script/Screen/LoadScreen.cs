using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		AsyncOperation async = Application.LoadLevelAdditiveAsync("GameMain1");
		do{
			Debug.Log(async.progress);
			yield return new WaitForEndOfFrame();
		}
		while(async.isDone == false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
