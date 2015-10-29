using UnityEngine;
using System.Collections;


public class TowerManager : MonoBehaviour {
  
	[SerializeField]
	private const float between_margin = 79;
	[SerializeField]
	private float keep;
    private const int fst_stage_num = 3;
    [SerializeField]
    private GameObject[] tower;
	private GameObject _player;

	void Start () {
        tower = new GameObject[fst_stage_num];
        for (int i = 0; i < fst_stage_num; i++ )
        {
            tower[i] = Instantiate(Resources.Load("Prefabs/maintou")) as GameObject;
            tower[i].transform.position = Vector3.down * (79 * i);
            tower[i].transform.rotation = Quaternion.Euler(Vector3.zero);
        }
		_player = GameObject.Find("Players").transform.FindChild("Main Camera").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		keep = _player.transform.position.y;
		if(tower[0].transform.position.y - between_margin > _player.transform.position.y ){
			GameObject localStage = Instantiate(Resources.Load("Prefabs/maintou")) as GameObject;
			localStage.transform.position = tower[2].transform.position - Vector3.up * between_margin;
			localStage.transform.rotation = Quaternion.Euler(Vector3.zero);
			Destroy(tower[0]);
			tower = new GameObject[3]{tower[1],tower[2],localStage};
		}
	}
}
