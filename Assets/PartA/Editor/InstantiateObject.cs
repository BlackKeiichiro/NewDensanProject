using UnityEngine;
using UnityEditor;
using System.Collections;

public class InstantiateObject :EditorWindow{
	[MenuItem("Window/InstantiateObject")]
	static void Init() {
		EditorWindow.GetWindow<InstantiateObject>(true, "InstantiateObject");
	}
	void Open(){

	}

	void OnGUI(){
		GUILayout.Label("Instatiate");
		if(GUILayout.Button("Start")){
			foreach(GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject))){
				foreach(MonoBehaviour mono in obj.GetComponents<MonoBehaviour>()){
					mono.Invoke("InstantiateObj",0);
				}
			}
		}
	}


}
