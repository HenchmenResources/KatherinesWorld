using UnityEngine;
using System.Collections;

public class MapEnd : MonoBehaviour {

	public GameObject SuccessNotice;
	public float SuccessTime = 3f;
	public int nextMap;
	private bool bMapDone = false;
	private float endTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bMapDone) {
			SuccessNotice.SetActive (true);
			if (Input.anyKey && (endTimer+5 < Time.time)) {
				//Application.LoadLevel(nextMap);
				Application.LoadLevel ("worldMap");
			}
		}
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			WorldMapMaster levelActiveScript = GameObject.Find ("Main Camera").GetComponent<WorldMapMaster> ();
			switch (Application.loadedLevelName) {
			case "Level1":
				levelActiveScript.bActiveLevel1 = true;
				break;
			case "Level2":
				levelActiveScript.bActiveLevel2 = true;
				break;
			case "Level3":
				levelActiveScript.bActiveLevel3 = true;
				break;
			case "Level4":
				levelActiveScript.bActiveLevel4 = true;
				break;
			case "Level5":
				levelActiveScript.bActiveLevel5 = true;
				break;
			case "Level6":
				levelActiveScript.bActiveLevel6 = true;
				break;
			case "Level7":
				levelActiveScript.bActiveLevel7 = true;
				break;
			case "Level8":
				levelActiveScript.bActiveLevel8 = true;
				break;
			case "Level9":
				levelActiveScript.bActiveLevel9 = true;
				break;
			case "Level10":
				levelActiveScript.bActiveLevel10 = true;
				break;
			case "Level11":
				levelActiveScript.bActiveLevel11 = true;
				break;
			case "Level12":
				levelActiveScript.bActiveLevel12 = true;
				break;
			
		 bMapDone = true;
		 endTimer = Time.time;
		}
	}	
}
