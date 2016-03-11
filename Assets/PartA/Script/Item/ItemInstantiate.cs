using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Excel;

public class ItemInstantiate : MonoBehaviour {
	private int[][][] patternlist;
	private string filepath = "/data/app/com.densan_project/Resources/Pattern/patternlist.xlsx";
//	private string filepath = "/Pattern/patternlist.xlsx";
	private GameObject[] type_items;
	private List<Transform> itemzone_child = new List<Transform>();
	//public Item[] instant_items;
    
	void Awake(){
		patternlist = PatternLoad.ReadExcelPattern(filepath);
		foreach(Transform child in this.transform){
			itemzone_child.Add(child);
		}
		type_items = new GameObject[]{
			 Resources.Load("Prefabs/Wall") as GameObject,
			 Resources.Load("Prefabs/Weapon") as GameObject,
		};
	}
	void Start () {
		//int random = Random.Range(0,1);b
		for(int zoneindex = 0;zoneindex < patternlist[0].Length;zoneindex++){
			for(int itemindex = 0;itemindex < patternlist[0][zoneindex].Length;itemindex++){
				GameObject localobject = Instantiate(type_items[patternlist[0][zoneindex][itemindex]]) as GameObject;
				localobject.transform.parent = itemzone_child[zoneindex];
				localobject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                localobject.transform.localPosition = new Vector3(- Define.ITEM_FiRST_SIDE + Define.BETWEEN_ITEM * itemindex, -10, 0);
			}
		}
	}
}
