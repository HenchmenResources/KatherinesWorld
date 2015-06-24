using UnityEngine;
using System.Collections;

public class MapEnd : MonoBehaviour {

	public GameObject SuccessNotice;
	public Texture SuccessTexture;
	public float SuccessTime = 3f;
	public int nextMap;
	private bool bMapDone = false;
	private float endTimer;
	string nextMapName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bMapDone) {
			//SuccessNotice.SetActive (true);
			if (Input.GetKeyDown(KeyCode.Space) && (endTimer+2 < Time.time)) {
				//Application.LoadLevel(nextMap);
				Application.LoadLevel ("worldMap");
			}
			if (Input.GetKeyDown(KeyCode.N) && (endTimer+2 < Time.time)) {
				Application.LoadLevel (nextMapName);
			}
		}
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			WorldMapMaster levelActiveScript = GameObject.Find ("WorldMapMaster").GetComponent<WorldMapMaster> ();
			switch (Application.loadedLevelName) {
			case "Level1":
				Debug.Log (Application.loadedLevelName);
				levelActiveScript.bActiveLevel2 = true;
				nextMapName = "Level2";
				break;
			case "Level2":
				levelActiveScript.bActiveLevel3 = true;
				nextMapName = "Level3";
				break;
			case "Level3":
				levelActiveScript.bActiveLevel4 = true;
				nextMapName = "Level4";
				break;
			case "Level4":
				levelActiveScript.bActiveLevel5 = true;
				nextMapName = "worldMap";
				break;
			case "Level5":
				levelActiveScript.bActiveLevel6 = true;
				break;
			case "Level6":
				levelActiveScript.bActiveLevel7 = true;
				break;
			case "Level7":
				levelActiveScript.bActiveLevel8 = true;
				break;
			case "Level8":
				levelActiveScript.bActiveLevel9 = true;
				break;
			case "Level9":
				levelActiveScript.bActiveLevel10 = true;
				break;
			case "Level10":
				levelActiveScript.bActiveLevel11 = true;
				break;
			case "Level11":
				levelActiveScript.bActiveLevel12 = true;
				break;
			}
			
		 bMapDone = true;
		 endTimer = Time.time;
		}
	}	

	void OnGUI () {
		if (bMapDone) {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 256, Screen.height / 3, 512, 128), SuccessTexture, ScaleMode.ScaleToFit);
		}
	}
}
