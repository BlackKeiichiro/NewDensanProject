using UnityEngine;
using System.Collections;
[SerializeField]
abstract public  class Item : MonoBehaviour {
	protected PartAManager _manager;
    protected ItemManager item_manager;
	protected GameObject _player;
	private RaycastHit hit;
	[SerializeField]
	private string itemtype;

	protected void Awake(){
		SetItemType(this.GetType().FullName);
		_player = GameObject.Find("Players") as GameObject;
		_manager = GameObject.Find("Manager").GetComponent<PartAManager>();
		item_manager = GameObject.Find("Manager").GetComponent<ItemManager>();
	}
	
	protected void SetItemType(string itemtype){
		this.itemtype = itemtype;
	}
	
	protected void PositionLock(float scale_y){
		if(Physics.Raycast(this.transform.position,Vector3.down,out hit,50)){
			Vector3 pos = hit.point;
			pos.y += scale_y;
			this.transform.position =  pos;
		}
	}
	
	protected abstract void Start();
	protected abstract void Update ();
	
	protected abstract void OnTriggerEnter(Collider _collider);
}
