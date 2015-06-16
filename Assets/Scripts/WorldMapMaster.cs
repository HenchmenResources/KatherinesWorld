using UnityEngine;
using System.Collections;

public class WorldMapMaster : MonoBehaviour {
	private Vector3 mouseLocation;
	//LevelActiveCheck will need to be replaced with code that checks the master level unlocked list.
	private bool LevelActiveCheck = true;
	public GameObject lightManager;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)){
			WorldMapLightup LightScript = lightManager.GetComponent<WorldMapLightup> ();
			if (hit.rigidbody != null){
				//Trigger Dollhouse Lights
				if (hit.collider.gameObject.name.Contains("Level")){
					LightScript.buttonName = hit.collider.gameObject.name;
				}else{
					LightScript.buttonName = "Bob";
				}

			}
		}
		//LOAD APPROPRIATE LEVEL IF IT IS AVAILABLE

		if (Input.GetMouseButtonDown (0) && LevelActiveCheck) {
			if (hit.collider.gameObject.name.Contains("Level")){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
		}
	}


}
