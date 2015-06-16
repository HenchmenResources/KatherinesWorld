using UnityEngine;
using System.Collections;

public class WorldMapMaster : MonoBehaviour {
	private Vector3 mouseLocation;
	//LevelActiveCheck will need to be replaced with code that checks the master level unlocked list.
	private bool LevelActiveCheck = true;
	public GameObject lightManager;
	private string nextLevel;

	//Track Which maps have been Completed
	public bool bActiveLevel1 = true;
	public bool bActiveLevel2 = false;
	public bool bActiveLevel3 = false;
	public bool bActiveLevel4 = false;
	public bool bActiveLevel5 = false;
	public bool bActiveLevel6 = false;
	public bool bActiveLevel7 = false;
	public bool bActiveLevel8 = false;
	public bool bActiveLevel9 = false;
	public bool bActiveLevel10 = false;
	public bool bActiveLevel11 = false;
	public bool bActiveLevel12 = false;


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
		nextLevel = "bActive"+hit.collider.gameObject.name;
		Debug.Log (nextLevel);
		if (Input.GetMouseButtonDown (0)) {
			if (hit.collider.gameObject.name == "Level1" && bActiveLevel1){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level2" && bActiveLevel2){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level3" && bActiveLevel3){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level4" && bActiveLevel4){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level5" && bActiveLevel5){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level6" && bActiveLevel6){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level7" && bActiveLevel7){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level8" && bActiveLevel8){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level9" && bActiveLevel9){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level10" && bActiveLevel10){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level11" && bActiveLevel11 ){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
			if (hit.collider.gameObject.name == "Level12" && bActiveLevel12){
				Application.LoadLevel(hit.collider.gameObject.name);
			}
		}
	}


}
