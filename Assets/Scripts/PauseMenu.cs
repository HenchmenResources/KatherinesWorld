using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private bool isPaused = false;
	private float winLeft = Screen.width / 2 - 100;
	private float winTop = Screen.height / 2 - 150;
	private Rect MenuWindow  = new Rect(10, 10, 200, 200);


	// Use this for initialization
	void Start () {
		Time.timeScale = 1F;
		MenuWindow  = new Rect(winLeft, winTop, 200, 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
			if(isPaused){
				Time.timeScale = 0;
			}else{
				Time.timeScale = 1;
			}
		}
	}

	void OnGUI () {
		if(isPaused) {
			GUI.Window(0, MenuWindow, ThePauseMenu, "Pause Menu");
		}
	}

	void ThePauseMenu (int windowID) {
		if(GUILayout.Button("Main Menu")){
			Application.LoadLevel("menu");
		}
		if(GUILayout.Button("Restart")){
			Application.LoadLevel(Application.loadedLevelName);
		}
		if(GUILayout.Button("Quit")){
			Application.Quit();
		}
	}
}
