using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlUI : MonoBehaviour {
	private int wpnlevel;
	private to_UI UIinfo;
	private Image boss_hp;
	private Image overheat;
	private Text level_txt;
	// Use this for initialization
	void Start () {
		wpnlevel = PlayerPrefs.GetInt("Grade");
		UIinfo = GameObject.Find("UI").GetComponent<to_UI>();
		level_txt = GameObject.Find("Canvas/Weapon/Level").GetComponent<Text>();
		boss_hp = GameObject.Find("Canvas/BossHp/HpBer").GetComponent<Image>();
		overheat = GameObject.Find("Canvas/OverHeat/Gauge").GetComponent<Image>();
		level_txt.text = LevelFactory(wpnlevel);
	}
	
	// Update is called once per frame
	void Update () {
		boss_hp.fillAmount = UIinfo.boss_hp/UIinfo.boss_hp_max;
		overheat.fillAmount = UIinfo.heat/UIinfo.heat_max;
	}
	private string LevelFactory(int level)
	{
		string kanji_level = level_txt.text;
		switch (level)
		{
		case 0:
			kanji_level = "零";
			break;
		case 1:
			kanji_level = "壱";
			break;
		case 2:
			kanji_level = "弐";
			break;
		case 3:
			kanji_level = "参";
			break; 
		}
		return kanji_level;
	}
}
