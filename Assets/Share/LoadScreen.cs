using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScreen : MonoBehaviour {
	private float per = 0;
	private Text load_per;
	private Image load_gauge;

	void Awake(){
		load_per = GameObject.Find("Loading_per").GetComponent<Text>();
		load_gauge = GameObject.Find("LoadGauge_in").GetComponent<Image>();
	}
	// Use this for initialization
	IEnumerator Start() {
		AsyncOperation async = Application.LoadLevelAsync(PlayerPrefs.GetInt("Scene"));
		do{
			load_per.text = (100 * async.progress).ToString("F1") + "%";
			load_gauge.fillAmount = async.progress;
			yield return new WaitForEndOfFrame();
		}
		while(!async.isDone);
		yield return new WaitForSeconds(1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
