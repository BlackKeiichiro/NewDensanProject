using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	AudioClip slip_audio;

	void Start(){
		slip_audio = Resources.Load("Sound/slip_short") as AudioClip;
	}

	public void SlipSoundEffect(){
		AudioSource.PlayClipAtPoint(slip_audio,this.transform.position,1);
	}
}