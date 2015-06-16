using UnityEngine;
using System.Collections;

public class WorldMapLightup : MonoBehaviour {

	public Light[] ActiveLight;
	//isLightActive is used for testing if thelevel has been unlocked
	//This will need to be removed and replaced with code to check the
	//master level unlock variables
	public bool[] isLightActive;

	public string buttonName;
	private string lightName;
	private int lightIndex;

	void Awake () {
		WorldMapMaster levelActiveScript = GameObject.Find ("Main Camera").GetComponent<WorldMapMaster> ();
		//for (int i = 0; i < 12; i++) {
		//	lightIndex = i + 1;
		//	isLightActive[i] = 
		//}

		isLightActive [0] = levelActiveScript.bActiveLevel1;
		isLightActive [1] = levelActiveScript.bActiveLevel2;
		isLightActive [2] = levelActiveScript.bActiveLevel3;
		isLightActive [3] = levelActiveScript.bActiveLevel4;
		isLightActive [4] = levelActiveScript.bActiveLevel5;
		isLightActive [5] = levelActiveScript.bActiveLevel6;
		isLightActive [6] = levelActiveScript.bActiveLevel7;
		isLightActive [7] = levelActiveScript.bActiveLevel8;
		isLightActive [8] = levelActiveScript.bActiveLevel9;
		isLightActive [9] = levelActiveScript.bActiveLevel10;
		isLightActive [10] = levelActiveScript.bActiveLevel11;
		isLightActive [11] = levelActiveScript.bActiveLevel12;
	}
	// Use this for initialization
	void Start () {
		WorldMapMaster levelActiveScript = GameObject.Find ("Main Camera").GetComponent<WorldMapMaster> ();
		isLightActive [0] = levelActiveScript.bActiveLevel1;
		isLightActive [1] = levelActiveScript.bActiveLevel2;
		isLightActive [2] = levelActiveScript.bActiveLevel3;
		isLightActive [3] = levelActiveScript.bActiveLevel4;
		isLightActive [4] = levelActiveScript.bActiveLevel5;
		isLightActive [5] = levelActiveScript.bActiveLevel6;
		isLightActive [6] = levelActiveScript.bActiveLevel7;
		isLightActive [7] = levelActiveScript.bActiveLevel8;
		isLightActive [8] = levelActiveScript.bActiveLevel9;
		isLightActive [9] = levelActiveScript.bActiveLevel10;
		isLightActive [10] = levelActiveScript.bActiveLevel11;
		isLightActive [11] = levelActiveScript.bActiveLevel12;
	}
	
	// Update is called once per frame
	void Update () {
		lightName = "DH_Light_" + buttonName;
		for (int i = 0; i < ActiveLight.Length; i++) {
			if (ActiveLight[i].name == lightName && isLightActive[i]) {
				ActiveLight[i].intensity = 1.0f;
				ActiveLight[i].range = 5f;
			}else if (ActiveLight[i].name != lightName && isLightActive[i]){
				ActiveLight[i].intensity = 0.5f;
				ActiveLight[i].range = 2f;
			}else{
				ActiveLight[i].intensity = 0.0f;
				ActiveLight[i].range = 1f;
			}
		}
	}

	void OnMouseEnter() {
		Debug.Log ("Enter");
	}

	void OnMouseOver() {
		Debug.Log ("Over");
	}
	
	void OnMouseExit() {
		Debug.Log ("Exit");
	}

}
