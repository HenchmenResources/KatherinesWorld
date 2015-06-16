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
	// Use this for initialization
	void Start () {
	
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
