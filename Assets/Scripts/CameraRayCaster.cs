using UnityEngine;
using System.Collections;

public class CameraRayCaster : MonoBehaviour {
	private Vector3 mouseLocation;
	//LevelActiveCheck will need to be replaced with code that checks the master level unlocked list.
	private bool LevelActiveCheck = true;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		WorldMapMaster levelActiveScript = GameObject.Find ("Main Camera").GetComponent<WorldMapMaster> ();
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				WorldMapLightup LightScript = GameObject.Find ("lightManager").GetComponent<WorldMapLightup> ();
				if (hit.rigidbody != null) {
					//Trigger Dollhouse Lights
					if (hit.collider.gameObject.name.Contains ("Level")) {
						LightScript.buttonName = hit.collider.gameObject.name;
					} else {
						LightScript.buttonName = "Bob";
					}
					
				}
			}
			
			
			
			//LOAD APPROPRIATE LEVEL IF IT IS AVAILABLE

			if (Input.GetMouseButtonDown (0)) {
			if (hit.collider.gameObject.name == "Level1" && levelActiveScript.bActiveLevel1) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level2" && levelActiveScript.bActiveLevel2) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level3" && levelActiveScript.bActiveLevel3) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level4" && levelActiveScript.bActiveLevel4) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level5" && levelActiveScript.bActiveLevel5) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level6" && levelActiveScript.bActiveLevel6) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level7" && levelActiveScript.bActiveLevel7) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level8" && levelActiveScript.bActiveLevel8) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level9" && levelActiveScript.bActiveLevel9) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level10" && levelActiveScript.bActiveLevel10) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level11" && levelActiveScript.bActiveLevel11) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			if (hit.collider.gameObject.name == "Level12" && levelActiveScript.bActiveLevel12) {
					Application.LoadLevel (hit.collider.gameObject.name);
				}
			}
		}

}