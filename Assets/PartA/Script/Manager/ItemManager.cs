using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Excel;

public class ItemManager : MonoBehaviour {
	private Count count;
	//Item UI
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

	//Item GameObject
	private	bool gamestartflag = false;
	private ExcelData exceldata;
	private float angle = 0;
	private float createitemsY = -3.0f;
	private float player_mv_center = 400;
	private float player_mv_space = 168;
	private float rds = 400;
	private float[] item_between = new float[5]{50,20,-10,-40,-65};
	private GameObject[] itemzones;
	private GameObject[] kindobject;
	private GameObject[] shiftzones;
	private GameObject[,] cleanitems;
	private GameObject tower;
	private int pass_zone = 1;
	private int[][][] item_pattern;
	private PlayerMove playermv;
	private Vector3 radian;
	private Vector3 center;
	private Vector3 rotate_position;
	public bool shiftzone_flag = false;
	//Getter
	public int StageLevel{get {return stage_level;}}
	public int Grage{get{return grade;}}

	void Awake () {
		cleanitems = new GameObject[2,6];
		count = this.GetComponent<Count>();
		//UI Initialize
		stage_level = PlayerPrefs.GetInt("Stage");
        item_gauge = GameObject.Find("Canvas/Weapon/Gauge").GetComponent<Image>();
		life_gauge = GameObject.Find("Canvas/Life/LifeGauge").GetComponent<Image>();
        level_ui = GameObject.Find("Canvas/Weapon/Level").GetComponent<Text>();
		//Item Initialize
		playermv = GameObject.Find("Player").GetComponent<PlayerMove>();
		kindobject = new GameObject[]{
			Resources.Load<GameObject>("Prefabs/Item"),
			Resources.Load<GameObject>("Prefabs/ExplosionAOE")
		};
		exceldata = Resources.Load("Pattern/patternlist") as ExcelData;
		tower = GameObject.Find("Tower");
		center = Vector3.zero;
	}

	void Update () {
		ItemGaugeEffect();
		EventCheckInit();
		CleanZoneChild();
	}

	//One zone's child is destroyed.
	void CleanZoneChild(){
		if(shiftzone_flag){
			for(int itemindex = 0;itemindex < cleanitems.GetLength(1);itemindex++){
				Destroy(cleanitems[pass_zone,itemindex]);
			}
			ObjectUpdate();
			shiftzone_flag = false;
		}
	}

	//when player is damaged,player's life  is down.
	public void ExplosionOnTriggerCall(){
		life_switch = true;
		life_keep = life_gauge.fillAmount;
	}

	//UI Effect(when player get item or get a damage from a missile)
	void ItemGaugeEffect(){
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
				PlayerPrefs.SetInt("Scene",0);
				Application.LoadLevel(1);
			}
		}
	}

    public void ItemOnTriggerCall() {
        gauge_switch = true;
        item_keep = item_gauge.fillAmount;
    }

	//First Object Instatiate, Timing Free.(Now Key Down Space)
	void EventCheckInit(){
		if(/*Input.GetKeyDown(KeyCode.Space) && */!gamestartflag){
			angle = playermv.get_angle + 60;
			count.switch_flag = false;
			shiftzones = new GameObject[]{
				ZoneInstantiate(angle),
				ZoneInstantiate(180 + angle)

			};
			foreach(GameObject shiftzone in shiftzones){
				shiftzone.transform.tag = "zone";
				shiftzone.AddComponent<BoxCollider>();
				shiftzone.GetComponent<BoxCollider>().size = new Vector3(player_mv_space,10,0);
				shiftzone.GetComponent<BoxCollider>().isTrigger = true;
			}
			ObjectUpdate();
			gamestartflag = true;
		}
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
		
	void ObjectUpdate(){
		int random_sheet = Random.Range(0,20);
		for(int zoneindex = 0;zoneindex < 6;zoneindex++){
			GameObject localparent = new GameObject();
			radian = - rds * Vector3.right; 
			rotate_position = Quaternion.AngleAxis(angle,Vector3.up) * radian;
			localparent.transform.position = center + rotate_position;
			localparent.transform.rotation = Quaternion.Euler(Vector3.up * (Define.PLAYER_FIX_ROTATE + angle));
			angle += 30;
			cleanitems[pass_zone,zoneindex] = localparent;
			int itemindex = 0;
			foreach(int cell in exceldata.sheet[random_sheet].row[zoneindex].cell){
				if(cell != -1){
					GameObject localobject = Instantiate((cell == 0)?kindobject[0]:kindobject[1]) as GameObject;
					localobject.transform.parent = localparent.transform;
					localobject.transform.localPosition = new Vector3(item_between[itemindex],createitemsY,0);
				}
				itemindex++;
			}
		}
		pass_zone = (pass_zone == 0)?1:0;
	}


	private GameObject ZoneInstantiate(float _angle){
		GameObject zone = new GameObject();
		zone.transform.parent = tower.transform;
		radian = Vector3.right * player_mv_center;
		rotate_position = Quaternion.AngleAxis(_angle,Vector3.up) * radian;
		zone.transform.rotation = Quaternion.Euler(Vector3.up * (Define.PLAYER_FIX_ROTATE +_angle));
		zone.transform.position = rotate_position + center;
		return zone;
	}
}