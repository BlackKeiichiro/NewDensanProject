using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemManager : MonoBehaviour {
    private Image item_gauge;
	private Image life_gauge;
    private Text level_ui;
    private bool gauge_switch = false;
	private bool life_switch = false;
    private float item_keep = 0;
	private float life_keep = 0;
    private float one_gauge = 0.251f;
	private float damage = 0.11f;
	private int grade = 0;
    private int limit_gauge = 3;
	private int stage_level;
	public int StageLevel{get {return stage_level;}}
	public int Grage{get{return grade;}}

	void Awake () {
		stage_level = PlayerPrefs.GetInt("Stage");
        item_gauge = GameObject.Find("Canvas/Weapon/Gauge").GetComponent<Image>();
		life_gauge = GameObject.Find("Canvas/Life/LifeGauge").GetComponent<Image>();
        level_ui = GameObject.Find("Canvas/Weapon/Level").GetComponent<Text>();
	}
	
	void Update () {
        if (gauge_switch && item_gauge.fillAmount - item_keep < one_gauge && grade < limit_gauge)
        {
            item_gauge.fillAmount += 0.01f;
            if (item_gauge.fillAmount == 1)
            {
                gauge_switch = false;
                grade++;
                item_gauge.fillAmount = 0;
                item_keep = 0;
                level_ui.text = LevelFactory(grade);
            }
        }
		if(life_switch && life_keep - life_gauge.fillAmount < damage){
			life_gauge.fillAmount -= 0.01f;
			if(life_gauge.fillAmount == 0){
				PlayerPrefs.SetInt("Stage",0);
				Application.LoadLevel("Start");
			}
		}
	}
	
    public void ItemOnTriggerCall() {
        gauge_switch = true;
        item_keep = item_gauge.fillAmount;
    }

	public void ExplosionOnTriggerCall(){
		life_switch = true;
		life_keep = life_gauge.fillAmount;
	}

	private string LevelFactory(int level)
    {
        string kanji_level = level_ui.text;
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
