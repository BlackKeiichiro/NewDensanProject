using UnityEngine;
using System.Collections;
using Excel;

public class ObjectInstatiate : MonoBehaviour {
	private int pass_zone = 1;
	private float rds = 400;
	private float angle = 0;
	private float createitemsY = -3.0f;
	private Vector3 radian;
	private Vector3 center;
	private Vector3 rotate_position;
	private float[] item_between = new float[5]{50,20,-10,-40,-65};
	private GameObject[] itemzones;
	private GameObject[] kindobject;
	private int[][][] itempattern;
	private string path = "Pattern/patternlist.xlsx";
	public bool shiftzone = false;

	// Use this for initialization
	void Start () {
		itempattern = PatternLoad.ReadExcelPattern(path);
		center = Vector3.zero;
		itemzones = new GameObject[]{
			this.transform.FindChild("ItemzoneRight").gameObject,
			this.transform.FindChild("ItemzoneLeft").gameObject
		};
		kindobject = new GameObject[]{
			Resources.Load("Prefabs/Item") as GameObject,
			Resources.Load("Prefabs/ExplosionAOE") as GameObject
		};
		ObjectUpdate();
	}
	
	// Update is called once per frame
	void Update () {
		if(shiftzone){
			foreach(Transform child in itemzones[pass_zone].transform){
				Destroy(child.gameObject);
			}
			ObjectUpdate();
			shiftzone = false;
		}
	}

	void ObjectUpdate(){
		int random_sheet = Random.Range(0,20);
		for(int zoneindex = 0;zoneindex < 6;zoneindex++){
			GameObject localparent = new GameObject();
			radian = - rds * Vector3.right; 
			rotate_position = Quaternion.AngleAxis(angle,Vector3.up) * radian;
			localparent.transform.position = center + rotate_position;
			localparent.transform.rotation = Quaternion.Euler(Vector3.up * angle);
			angle += 30;
			localparent.transform.parent = itemzones[pass_zone].transform;
			for(int itemindex = 0;itemindex < 5;itemindex++){
				if(itempattern[random_sheet][zoneindex][itemindex] != -1){
					GameObject localobject = Instantiate((zoneindex == 0)?kindobject[0]:kindobject[1]) as GameObject;
					localobject.transform.parent = localparent.transform;
					localobject.transform.localPosition = new Vector3(item_between[itemindex],createitemsY,0);
				}
			}
		}
		pass_zone = (pass_zone == 0)?1:0;
	}	
}
