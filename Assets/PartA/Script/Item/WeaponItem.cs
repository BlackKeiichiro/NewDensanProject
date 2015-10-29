using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponItem : Item {
    private AudioClip getitemSE;
	private float fix_itemY = 2; 
	protected override void Start () {
		PositionLock(fix_itemY);
        getitemSE = Resources.Load("Sound/item_bike") as AudioClip;
	}
	
	protected override void Update () {
		
	}
	
	protected override void OnTriggerEnter(Collider _collider){
		if(_collider.gameObject.tag == "Player"){
            getitemSE.LoadAudioData();
            item_manager.ItemOnTriggerCall();
            AudioSource.PlayClipAtPoint(getitemSE,this.transform.position,0.3f);
			Destroy(this.gameObject);
		}
	}

	
}
