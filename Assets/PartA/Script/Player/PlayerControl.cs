using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private Vector3 _velocity;
	private Count count;
	private RaycastHit hit;
	private LayerMask layermask;
	private CameraOutObject cameraout;
	private int camout_count = 5;
	private int camout_keepcount = 0;
	private Text uicount;
	// Use this for initialization
	void Awake(){
		count = GameObject.Find("Manager").GetComponent<Count>();
		uicount = GameObject.Find("CameraOutCount").GetComponent<Text>();
		layermask  = ~(1 << 8);
	}
	void Start () {
		cameraout = this.GetComponent<CameraOutObject>();
	}
	void DownRayhitToStage(){
		if(!Physics.Raycast(this.transform.position,Vector3.down,out hit,0.2f,layermask)){
			if(hit.point.y - 0.1f < this.transform.position.y){
				this.transform.localPosition += 0.01f*Vector3.down;
			}
		}
	}

	void ScreenOutCounter(){
		if(cameraout.OutScreenObject(this.transform)){
			if(camout_keepcount != 0){
				camout_count = count.count - camout_keepcount;
			}else{
				camout_keepcount = count.count;
			}
			uicount.text = camout_count.ToString();
			if(camout_count > 5){
				camout_count = 0;
				Debug.Log("GameOver");
			}
		}
		else{
			camout_count = 5;
			camout_keepcount = 0;
			uicount.text = "";
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		ScreenOutCounter();
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		_velocity = new Vector3(h , 0 , v);
		if(v > 0.1)
			_velocity *= Time.deltaTime * 8;
		else if(v < -0.1)
			v = h = 0;
		else
			_velocity *= Time.deltaTime * 5;
		
		if((h != 0 || v != 0)){
			this.transform.localPosition += _velocity;
		}
	}
}